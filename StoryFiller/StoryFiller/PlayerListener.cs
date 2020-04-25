using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StoryFiller
{
	public class PlayerListener
	{
		private GameState _gameState;
		public PlayerListener(GameState state)
		{
			_gameState = state;
		}

		private void ProcessRequest(HttpListenerContext context)
		{
			var responseString = "";
			int statuscode = 200;
			try
			{
				var body = JsonConvert.DeserializeObject<string>(new StreamReader(context.Request.InputStream).ReadToEnd());
				_gameState.AddMessage(body);
			}
			catch (Exception ex)
			{
				responseString = ex.Message;
				statuscode = 500;
			}
			HttpListenerResponse response = context.Response;
			response.AddHeader("Access-Control-Allow-Origin", "*");
			response.AddHeader("Access-Control-Allow-Headers", "*");
			response.AddHeader("Access-Control-Allow-Methods", "*");
			response.StatusCode = statuscode;
			response.ContentType = "text/plain";

			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
			response.ContentLength64 = buffer.Length;
			System.IO.Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);
		}

		public void StartListening()
		{
			HttpListener listener = new HttpListener();
			listener.Prefixes.Add("http://localhost:4333/player/");
			try
			{
				listener.Start();
			}
			catch (HttpListenerException hlex)
			{
				Console.WriteLine(hlex.Message);
				return;
			}
			while (listener.IsListening)
			{
				var context = listener.GetContext();
				ProcessRequest(context);
			}
			listener.Close();
		}
	}
}
