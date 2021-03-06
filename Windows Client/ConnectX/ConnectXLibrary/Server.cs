﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
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
        ThreadLocal<AI> threadAI;
        ThreadLocal<int> threadDifficulty;
        bool formClosing = false;
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

                listenThread = new Thread(new ParameterizedThreadStart(startlistener));
                listenThread.Start();
                Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../Webclient/index.html"));
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
            try { 
            var result = listener.BeginGetContext(ListenerCallback, listener);
            result.AsyncWaitHandle.WaitOne();

            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Listen aborted");
            }
        }

        private void ListenerCallback(IAsyncResult result)
        {
            try {
            // Data inlezen
            var context = listener.EndGetContext(result);
            var data_text = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();
            var cleaned_data = System.Web.HttpUtility.UrlDecode(data_text);
            string callback = context.Request.QueryString["callback"];

            Dictionary<string, string> request = new Dictionary<string, string>();

            request["action"] = context.Request.QueryString["action"];

            // Input verwerken

            ResponseForWebClient response;

            if (request["action"] == "startGame")
            {
                request["rows"] = context.Request.QueryString["rows"];
                request["columns"] = context.Request.QueryString["columns"];
                request["streak"] = context.Request.QueryString["streak"];
                request["difficulty"] = context.Request.QueryString["difficulty"];

                response = startGame(request);

            }
            else if (request["action"] == "insertToken")
            {
                request["player"] = context.Request.QueryString["player"];
                request["column"] = context.Request.QueryString["column"];
                response = insertToken(request);

            }
            else if (request["action"] == "insertTokenByAI")
            {

                AI ai = threadAI.Value;
                int difficulty = threadDifficulty.Value;
                request["player"] = 2.ToString();

                switch (difficulty)
                {
                case 1:
                    request["column"] = ai.chooseRandomSpot().ToString();
                    break;
                case 2:
                    request["column"] = ai.makeTurn(2).ToString();
                    break;
                case 3:
                    request["column"] = ai.makeTurn(4).ToString();
                    break;
                case 4:
                    request["column"] = ai.makeTurn(8).ToString();
                    break;
                }

                response = insertToken(request);

            }
            else if (request["action"] == "nextGame")
            {

                ConnectX game = threadGame.Value;

                response = nextGame(request);


            }
            else response = null;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string JSONstring = js.Serialize(response);
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
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Listen aborted");
			}
			catch (HttpListenerException)
			{
				Console.WriteLine("Listen aborted");
			}
        }

        private ResponseForWebClient insertToken(Dictionary<string, string> request)
        {
            ConnectX game = threadGame.Value;

            int player = int.Parse(request["player"]);
            int column = int.Parse(request["column"]);
            int row = game.getLowestAvailableRowInColumn(column);
            int rows = game.getRows();
            bool status = false;

            if (0 <= row && row < rows)
            {
                 status = game.insertToken(column, row, player);
            }

            bool won = game.hasWinner();
            bool full = game.isTie();

            Dictionary<string, string> responseDictionary = new Dictionary<string, string>();

            responseDictionary["row"] = row.ToString();
            responseDictionary["column"] = column.ToString();
            responseDictionary["player"] = player.ToString();
            responseDictionary["status"] = status.ToString();
            responseDictionary["won"] = won.ToString();
            responseDictionary["full"] = full.ToString();

            ResponseForWebClient response = new ResponseForWebClient(status, request, responseDictionary);

            game.switchPlayerAtTurn();

            return response;
        }

        private ResponseForWebClient nextGame(Dictionary<string, string> request)
        {
            ConnectX game = threadGame.Value;

            bool status = game.nextGame();
            Dictionary<string, string> response = new Dictionary<string, string>();
            return new ResponseForWebClient(status, request, response);
        }

        private ResponseForWebClient startGame(Dictionary<string, string> request)
        {

            int rows = Convert.ToInt32(request["rows"]);
            int columns = Convert.ToInt32(request["columns"]);
            int streak = Convert.ToInt32(request["streak"]);
            int difficulty = Convert.ToInt32(request["difficulty"]);

            ConnectX game = new ConnectX(rows, columns, streak);
            AI ai = new AI(game);

            threadGame = new ThreadLocal<ConnectX>(() => { return game; });
            threadAI = new ThreadLocal<AI>(() => { return ai; });
            threadDifficulty = new ThreadLocal<int>(() => { return difficulty; });

            bool status = true;

            Dictionary<string, string> response = new Dictionary<string, string>();
            
            return new ResponseForWebClient(status, request, response);

        }
		private void btnStopServer_Click(object sender, EventArgs e)
        {
            listenThread.Abort();
            try
            {
                listener.Stop();
            }
            catch (ObjectDisposedException) { }
            listener.Close();

            formClosing = true;
            this.Close();
		}//btnStopServer_Click

		private void Server_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (!formClosing)
            { 
			    listenThread.Abort();
                try
                {
                    listener.Stop();
                }
                catch (ObjectDisposedException) { this.Close(); }
			
			    listener.Close();
            }
		}//Server_FormClosing
    }
}