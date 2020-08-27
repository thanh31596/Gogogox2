using System;
using System.IO;
using System.Text;

namespace Stephen
{
	class Program
	{
		Game game;
		static void Main(string[] args)
		{
			
			var stillPlaying = true;
			const int w = 10;
			var comp = new Computer();
			var fist = new HumanFirst();
			var sec = new HumanSecond();
			var game = new Game(new Board(w, w, 5));
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("-----------------------");
			Console.WriteLine("Vu Kim Thanh - Stephen Vu 10648771!");
			Console.WriteLine("-----------------------\n");
			Console.ResetColor();

			while (stillPlaying)
			{
				Console.WriteLine("What would you like to do:");
				Console.WriteLine("1. Start a new single-player game");
				Console.WriteLine("2. Start a new multiplayer game");
				Console.WriteLine("3. Quit");
				Console.WriteLine("4. Open Saved Game\n");

				Console.Write("Choose your option please: ");

				var choice = GetUserInput("[1234]");

				switch (choice)
				{
					case "1":
						game.start_play(comp, fist, 0);
						Console.Clear();
						break;
					case "2":
						game.start_play(fist, sec, 0);
						break;
					case "3":
						stillPlaying = false;
						break;
					case "4":
						using (FileStream fs = new FileStream(Player.path, FileMode.Open, FileAccess.Read))
						{
							using (BinaryReader r = new BinaryReader(fs))
							{
								for (int i = 0; i < 11; i++)
								{
									Console.WriteLine(r.ReadInt32());
								}
							}
						}
						break;

				}
			}



		}
		public static string GetUserInput(string validPattern = null)
		{
			var input = Console.ReadLine();
			input = input.Trim();

			if (validPattern != null && !System.Text.RegularExpressions.Regex.IsMatch(input, validPattern))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("\"" + input + "\" is not valid.\n");
				Console.ResetColor();
				return null;
			}

			return input;
		}

	}
}

