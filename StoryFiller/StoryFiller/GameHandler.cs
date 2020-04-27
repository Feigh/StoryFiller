using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StoryFiller
{
	public class GameHandler
	{
		private GameState _gameState;
		private bool gamerunning;
		public GameHandler(GameState state)
		{
			_gameState = state;
			gamerunning = true;
		}

		public void Run()
		{
			PlayerListener player = new PlayerListener(_gameState);
			Thread thr = new Thread(new ThreadStart(player.StartListening));

			GameListener game = new GameListener(_gameState);
			Thread thrg = new Thread(new ThreadStart(game.StartListening));

			thr.Start();
			thrg.Start();
			//thread for listener
			string printMsg = "";

			while (gamerunning)
			{
				var nameList = _gameState.PlayerList.Select(x => x.name);
				printMsg = $"Medelanden: { nameList.Aggregate(string.Empty, (a, b) => a == string.Empty ? b : a + ", " + b) }";

				Console.WriteLine(printMsg);

				Thread.Sleep(1000);

				Console.Clear();
			}
		}


	}
}
