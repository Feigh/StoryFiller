using StoryFiller.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace StoryFiller
{

	public class GameState
	{
		public List<Player> PlayerList { get => _playerlist; }
		private List<Player> _playerlist;
		public GameSessionState CurrentState { get => _currentstate; }
		private GameSessionState _currentstate;

		public GameState()
		{
			_playerlist = new List<Player>();
			_currentstate = GameSessionState.AWAITPLAYERS;
		}

		public PlayerResponse AddPlayer(string plr)
		{
			var newid = _playerlist.Any() ? (_playerlist.Last().id + 1) : 0;
			var player = new Player() { id = newid, name = plr };
			_playerlist.Add(player);
			return new PlayerResponse() { player = player, status = _currentstate };
		}

		public PlayerResponse StartGame(string playername)
		{
			_currentstate = GameSessionState.PLAYERINPUT;
			var player = _playerlist.Where(x => x.name == playername).FirstOrDefault();
			return new PlayerResponse() { player = player, status = _currentstate };
		}
	}
}
