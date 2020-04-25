using System;
using System.Collections.Generic;
using System.Text;

namespace StoryFiller
{
	public class GameState
	{
		public List<string> MessageList { get => _messagelist; }
		private List<string> _messagelist;

		private int counter;
		public GameState()
		{
			_messagelist = new List<string>();
			counter = 0;
		}

		public void AddMessage(string msg)
		{
			_messagelist.Add(msg + counter.ToString());
			counter++;
		}

	}
}
