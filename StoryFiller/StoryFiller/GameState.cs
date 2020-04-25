using System;
using System.Collections.Generic;
using System.Text;

namespace StoryFiller
{
	public class GameState
	{
		public List<string> MessageList { get => _messagelist; }
		private List<string> _messagelist;
		public List<string> PlayerList { get => _playerlist; }
		private List<string> _playerlist;

		private int counter;
		public GameState()
		{
			_messagelist = new List<string>();
			_playerlist = new List<string>();
			counter = 0;
		}

		public void AddMessage(string msg)
		{
			_messagelist.Add(msg + counter.ToString());
			counter++;
		}
		public void AddPlayer(string plr)
		{
			PlayerList.Add(plr);
		}
	}
}
