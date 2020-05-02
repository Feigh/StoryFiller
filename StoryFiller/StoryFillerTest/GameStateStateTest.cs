using NUnit.Framework;
using StoryFiller;
using StoryFiller.Entities;
using System.Linq;

namespace StoryFillerTest
{
	public class GameStateStateTest
	{
		private GameState sup;
		[SetUp]
		public void Setup()
		{
			sup = new GameState();
		}

		[Test]
		public void WhenGameStartStateIsWaitingForPlayers()
		{
			Assert.That(sup.CurrentState, Is.EqualTo(GameSessionState.AWAITPLAYERS), "Some useful error message");
		}

		[Test]
		public void WhenPlayerSelectStartStateIsPlayerInput()
		{
			var body = new Player();
			sup.StartGame(body);
			Assert.That(sup.CurrentState, Is.EqualTo(GameSessionState.PLAYERINPUT), "Wrong state");
		}

		[Test]
		public void WhenPlayerAllPlayerSentInSelectionStateIsLeaderSelect()
		{
			var player1 = sup.AddPlayer("Bob");
			var player2 = sup.AddPlayer("Jon");
			var player3 = sup.AddPlayer("Tod");

			player1.player.suggestion = "Katt";
			sup.SubmitInput(player1.player);
			player2.player.suggestion = "Hund";
			sup.SubmitInput(player2.player);
			player3.player.suggestion = "Ödla";
			sup.SubmitInput(player3.player);

			Assert.That(sup.CurrentState, Is.EqualTo(GameSessionState.LEADERINPUT), "Wrong state");
		}

		[Test]
		public void WhenLeaderMadeSelectionStateIsWinningScreen()
		{
			var body = new Player();
			sup.LeaderSubmitInput(body);
			Assert.That(sup.CurrentState, Is.EqualTo(GameSessionState.WINNINGSCREEN), "Wrong state");
		}

		[Test]
		public void WhenLeaderSelectsContiueStateIsPlayerInput()
		{
			var body = new Player();
			sup.StartGame(body);
			Assert.That(sup.CurrentState, Is.EqualTo(GameSessionState.PLAYERINPUT), "Wrong state");
		}
	}
}
