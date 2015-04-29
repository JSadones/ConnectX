using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq; 
using System.Net;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Web.Script.Serialization;

namespace ConnectXLibrary
{
    public partial class Server : Form
    {
        static HttpListener listener;
        private Thread listenThread1;
        public Server()
        {
            InitializeComponent();
        }
        
        
        private void Server_Load(object sender, EventArgs e)
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8000/");
            listener.Prefixes.Add("http://127.0.0.1:8000/");
            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

            listener.Start();
            this.listenThread1 = new Thread(new ParameterizedThreadStart(startlistener));
            listenThread1.Start();
           
        }


        private void startlistener(object s)
        {

            while (true)
            {
               
                ////blocks until a client has connected to the server
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
            Thread.Sleep(100);
            var data_text = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();

            //functions used to decode json encoded data.
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //var data1 = Uri.UnescapeDataString(data_text);
            //string da = Regex.Unescape(data_text);
            // var unserialized = js.Deserialize(data_text, typeof(String));

            var cleaned_data = System.Web.HttpUtility.UrlDecode(data_text);

            context.Response.ContentType = "application/json";
            string callback = context.Request.QueryString["callback"];
            string Param1 = context.Request.QueryString["Param1"];
            var RegisteredUsers = new List<ResponseForWebClient>();
            RegisteredUsers.Add(new ResponseForWebClient("a"));
            RegisteredUsers.Add(new ResponseForWebClient("b"));
            RegisteredUsers.Add(new ResponseForWebClient("c"));
            RegisteredUsers.Add(new ResponseForWebClient("d"));
            JavaScriptSerializer js = new JavaScriptSerializer();
            string JSONstring = js.Serialize(RegisteredUsers);
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
