using System;
using System.Net;

namespace VierOpEenRijWebServer
{
	class Program
	{
		static void Main(string[] args)
		{
			WebServer server = new WebServer(SendResponse, "http://localhost:8080/test/");
			server.Run();
		
			Console.WriteLine("Webserver for Connect Four. Press q to quit.");
			ConsoleKeyInfo keyinfo;
			do
			{
				keyinfo = Console.ReadKey();
			}
			while (keyinfo.Key != ConsoleKey.Q);
			server.Stop();
		}

		public static string SendResponse(HttpListenerRequest request)
		{
			return string.Format("");
		}
	}
}