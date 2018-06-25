using System;
using GameEngine;

namespace App
{
	class AppClass
	{
		static void Main(string[] args)
		{
			
			Render.Init(10, 10);
			
			
			// Background image
			//string backgroundString = "........\n........\n........\n........";
			//Image background = new Image(backgroundString);
			
			//Render.SetBackground(background);
			Image backgroundFillTest = new Image("_");
			Render.FillBackground(backgroundFillTest);
			// Create a Sprite
			string playerImageAsString = "O\n>>\n/\\";
			Image playerImage = new Image(playerImageAsString);
			Sprite TestSprite = Render.NewSprite(1, 1, playerImage);
			
			
			
			
			Render.UpdateScreen();
			Render.Draw();
			Console.ReadKey();
		}
	}
}