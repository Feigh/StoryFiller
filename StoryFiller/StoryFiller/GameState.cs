using StoryFiller.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StoryFiller
{

	public class GameState
	{
		public List<Player> PlayerList { get => _playerlist; }
		private List<Player> _playerlist;
		public GameSessionState CurrentState { get => _currentstate; }
		private GameSessionState _currentstate;
		public List<PromptLine> Prompt { get; set; }
		private List<PromptLine> _promptList;
		public GameState()
		{
			_playerlist = new List<Player>();
			_currentstate = GameSessionState.AWAITPLAYERS;
			_promptList = new List<PromptLine>();
			_promptList.Add(new PromptLine() { id = 0, order = 1, prompt = "Katten heter __" });
			_promptList.Add(new PromptLine() { id = 1, order = 2, prompt = "__ Sa hunden" });
		}

		public PlayerResponse AddPlayer(string plr)
		{
			var newid = _playerlist.Any() ? (_playerlist.Last().id + 1) : 0;
			var player = new Player() { id = newid, name = plr };
			_playerlist.Add(player);
			return new PlayerResponse() { player = player, status = _currentstate };
		}

		public PlayerResponse LeaderSubmitInput(Player body)
		{
			var curPrompt = _promptList.OrderBy(o => o.order).Where(x => x.playerchoise == null).FirstOrDefault();
			curPrompt.playerchoise = body.suggestion;
			_currentstate = GameSessionState.WINNINGSCREEN;
			return new PlayerResponse() { player = body, status = _currentstate };
		}

		public PlayerResponse StartGame(Player body)
		{
			_currentstate = GameSessionState.PLAYERINPUT;

			return new PlayerResponse() { player = body, status = _currentstate };
		}

		public PlayerResponse SubmitInput(Player body)
		{
			var player = _playerlist.Find(x => x.id == body.id);
			player.suggestion = body.suggestion;

			if(_playerlist.Any(x => x.suggestion == null))
			{
				_currentstate = GameSessionState.LEADERINPUT;
			}

			return new PlayerResponse() { player=player };
		}

	}
}
