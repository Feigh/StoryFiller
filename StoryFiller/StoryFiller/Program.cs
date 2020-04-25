using System;

namespace StoryFiller
{
	class Program
	{
		static void Main(string[] args)
		{
			GameState state = new GameState();

			GameHandler game = new GameHandler(state);

			game.Run();

			/*
			 * Steg 2
			 * olika maskiner, typ olika webbläsare kan logga in mot spelet
			 * spelet visar en lista med alla inloggade
			 * när en spelar trycker på knappen starta spelet så visas en . spelet startat på spel skärmen
			 * steg 3
			 * bara den först spelaren som startade spelet får en knapp att klicka på
			 * 
			 */
		}
	}
}
