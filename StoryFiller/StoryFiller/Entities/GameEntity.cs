using System;
using System.Collections.Generic;
using System.Text;

namespace StoryFiller.Entities
{
	class GameEntity
	{
	}

	public class GamePrompt
	{

	}
	public class Player
	{
		public int id;
		public string name;
		public bool leader;
		public int score;
		public string suggestion;
	}
	public enum GameSessionState
	{
		AWAITPLAYERS,
		PLAYERINPUT,
		LEADERINPUT
	}
	public class PlayerResponse
	{
		public GameSessionState status;
		public Player player;
	}
	public class PlayerRequest
	{
		public string action;
		public Player player;

		public PlayerRequest()
		{
			player = new Player();
		}
	}
	public class GameResponse
	{
		public GameSessionState status;
		public List<Player> players;
		public string prompt;
	}
	public class GameRequest
	{
	}
}
