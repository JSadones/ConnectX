﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Server : Form
    {
        #region State
        static HttpListener listener;
        private Thread listenThread;
        ThreadLocal<ConnectX> threadGame;
        #endregion State

        #region Constructor
        public Server()
        {
            InitializeComponent();
        }
        #endregion

        private void Server_Load(object sender, EventArgs e)
        {
            try
            {
                listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:8000/");
                listener.Prefixes.Add("http://127.0.0.1:8000/");
                listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

                listener.Start();

                this.listenThread = new Thread(new ParameterizedThreadStart(startlistener));
                listenThread.Start();
            }
            catch (HttpListenerException)
            {
                DialogResult dialogResult = MessageBox.Show("Run ConnectX as admin or server is already listening.", "Error");
                this.Close();
            }
        }

        private void startlistener(object s)
        {
            while (true)
            {
                ProcessRequest();
            }
        }

        private void ProcessRequest()
        {
            var result = listener.BeginGetContext(ListenerCallback, listener);
            result.AsyncWaitHandle.WaitOne();
        }

        private void ListenerCallback(IAsyncResult result)
        {
            // Data inlezen
            var context = listener.EndGetContext(result);
            var data_text = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();
            var cleaned_data = System.Web.HttpUtility.UrlDecode(data_text);
            string callback = context.Request.QueryString["callback"];

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["action"] = context.Request.QueryString["action"];
            parameters["option1"] = context.Request.QueryString["option1"];
            parameters["option2"] = context.Request.QueryString["option2"];
            parameters["option3"] = context.Request.QueryString["option3"];

            // Input verwerken

            var Response = new List<ResponseForWebClient>();

            if (parameters["action"] == "startGame")
            {
                    int rows = Convert.ToInt32(parameters["option1"]);
                    int columns = Convert.ToInt32(parameters["option2"]);
                    int streak = Convert.ToInt32(parameters["option3"]);
                    ConnectX game = new ConnectX(rows, columns, streak);
                    
                    threadGame = new ThreadLocal<ConnectX>(() =>
                    {
                        return game;
                    });

                    ResponseForWebClient response = new ResponseForWebClient();
                    response.type = "startGame";
                    response.status = true.ToString();
                    
                    Response.Add(response);
            }
            else if (parameters["action"] == "insertToken")
            {

                ConnectX game = threadGame.Value;
                int column = int.Parse(parameters["option1"]);
                int player = int.Parse(parameters["option2"]);

                int row = game.getLowestAvailableRow(Convert.ToInt32(parameters["option1"]));

                ResponseForWebClient response = new ResponseForWebClient();
        
                response.type = "insertToken";
                response.row = row.ToString();
                response.column = column.ToString();
                response.player = player.ToString();
                response.status = game.insertToken(column, row, player).ToString();
                response.won = game.isCurrentGameWon(row, column).ToString();
                response.full = game.isRasterFull().ToString();
            
                game.switchPlayerAtTurn();

                Response.Add(response);

            } else if (parameters["action"] == "nextGame")
            {

                ConnectX game = threadGame.Value;

                ResponseForWebClient response = new ResponseForWebClient();

                response.type = "nextGame";
                response.status = game.nextGame().ToString(); ;

                Response.Add(response);

            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string JSONstring = js.Serialize(Response);
            string JSONPstring = string.Format("{0}({1});", callback, JSONstring);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(JSONPstring);
            
            //context.Response. Write(JSONPstring);
            context.Response.ContentType = "application/json";
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.ContentLength64 = buffer.Length;
            if (context.Request.HttpMethod == "OPTIONS")
            {
                context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With");
                context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                context.Response.AddHeader("Access-Control-Max-Age", "1728000");
            }

            System.IO.Stream output = context.Response.OutputStream;

            output.Write(buffer, 0, buffer.Length);
            output.Close();
        
            context.Response.Close();
        }
    }
}