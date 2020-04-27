using NUnit.Framework;
using StoryFiller;
using System.Linq;

namespace StoryFillerTest
{
	public class GameStateTest
	{
		private GameState sup;
		[SetUp]
		public void Setup()
		{
			sup = new GameState();
		}

		[Test]
		public void AddNewPlayerWillReturnPlayerWithNewID()
		{
			var result = sup.AddPlayer("Bob");

			Assert.That(result.player.name, Is.EqualTo("Bob"), "Wrong Name");
			Assert.That(result.player.id, Is.EqualTo(0), "Wrong ID");
		}

		[Test]
		public void AddNewPlayerWillAddPlayerToList()
		{
			sup.AddPlayer("Bob");

			var result = sup.PlayerList.First();

			Assert.That(result.name, Is.EqualTo("Bob"), "Wrong Name");
			Assert.That(result.id, Is.EqualTo(0), "Wrong ID");
		}

		[Test]
		public void AddTwoNewPlayerWillReturnPlayerWheretheLastPlayerHasID1()
		{
			sup.AddPlayer("Bob");
			sup.AddPlayer("Jon");

			var result = sup.PlayerList.Last();

			Assert.That(result.name, Is.EqualTo("Jon"), "Wrong Name");
			Assert.That(result.id, Is.EqualTo(1), "Wrong ID");
		}
		[Test]
		public void StartGameWillChangeTheStateOfTheGame()
		{
			Assert.That(sup.CurrentState, Is.EqualTo(GameSessionState.AWAITPLAYERS), "Wrong State");
			sup.StartGame("Bob");
			Assert.That(sup.CurrentState, Is.EqualTo(GameSessionState.PLAYERINPUT), "The State did not change");
		}
		[Test]
		public void TestMethod()
		{
			var answer = 42;
			Assert.That(answer, Is.EqualTo(42), "Some useful error message");
		}
	}
}