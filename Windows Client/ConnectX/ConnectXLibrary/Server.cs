using System;
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

                ResponseForWebClient response = new ResponseForWebClient("startGame",0,0,0,true,false,false);
                
                    
                Response.Add(response);
            }
            else if (parameters["action"] == "insertToken")
            {
                
                int column = int.Parse(parameters["option1"]);
                int player = int.Parse(parameters["option2"]);

                ConnectX game = threadGame.Value;

                ResponseForWebClient response =  insertToken(game, column, player);

                Response.Add(response);

            } else if (parameters["action"] == "nextGame")
            {

                ConnectX game = threadGame.Value;

                bool status = game.nextGame();
                ResponseForWebClient response = new ResponseForWebClient("nextGame",0,0,0,status, 0, 0);

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

        private ResponseForWebClient insertToken(ConnectX game, int column, int player)
        {
            int row = game.getLowestAvailableRowInColumn(column);

            string type = "insertToken";
            bool status = game.insertToken(column, row, player);
            bool won = game.isCurrentGameWon(row, column);
            bool full = game.isRasterFull();

            ResponseForWebClient response = new ResponseForWebClient("insertToken",row, column, player, status, won, full);

            game.switchPlayerAtTurn();

            return response;
        }

    }
}