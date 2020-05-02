using NUnit.Framework;
using StoryFiller;
using StoryFiller.Entities;
using System.Linq;
using System.Xml.XPath;

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
		public void SaveInputToTheRightPlayer()
		{
			var plr = sup.AddPlayer("Bob");
			sup.AddPlayer("Jon");

			var input = new Player() { id = plr.player.id, suggestion = "boop" };

			sup.SubmitInput(input);

			var result = sup.PlayerList.Find(x => x.name == "Bob");

			Assert.That(result.suggestion, Is.EqualTo("boop"), "wrong suggestion");

			result = sup.PlayerList.Find(x => x.name == "Jon");
			Assert.That(result.suggestion, Is.EqualTo(null), "The State did not change");
		}
	}
}