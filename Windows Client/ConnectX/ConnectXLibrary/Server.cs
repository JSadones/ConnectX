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
            var context = listener.EndGetContext(result);
            var data_text = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();

            var cleaned_data = System.Web.HttpUtility.UrlDecode(data_text);

            context.Response.ContentType = "application/json";
            string callback = context.Request.QueryString["callback"];
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["action"] = context.Request.QueryString["action"];
            string Param2 = context.Request.QueryString["Param2"];
            string Param3 = context.Request.QueryString["Param3"];
            string Param4 = context.Request.QueryString["Param4"];

            var Response = new List<ResponseForWebClient>();

            if (parameters["action"] == "startGame")
                {
                    int rows = Convert.ToInt32(Param2);
                    int columns = Convert.ToInt32(Param3);
                    int streak = Convert.ToInt32(Param4);
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
                int column = int.Parse(Param2);
                int player = int.Parse(Param3);

                int row = game.getLowestAvailableRowInColumn(Convert.ToInt32(Param2));

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
            //context.Response. Write(JSONPstring);
            if (context.Request.HttpMethod == "OPTIONS")
            {
                context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With");
                context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                context.Response.AddHeader("Access-Control-Max-Age", "1728000");
            }
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(JSONPstring);
            // Get a response stream and write the response to it.
            context.Response.ContentLength64 = buffer.Length;
            System.IO.Stream output = context.Response.OutputStream;
            // You must close the output stream.
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            

            //use this line to get your custom header data in the request.
            //var headerText = context.Request.Headers["mycustomHeader"];

            //use this line to send your response in a custom header
            //context.Response.Headers["mycustomResponseHeader"] = "mycustomResponse";
         
            context.Response.Close();
        }
    }
}