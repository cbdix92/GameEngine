using System;
using GameEngine;

namespace App
{
	class AppClass
	{
		static void Main(string[] args)
		{
			
			RenderPipe.Init(10, 10);
			
			
			// Background image
			string backgroundString = "........\n........\n........\n........";
			Image background = new Image(backgroundString);
			
			RenderPipe.SetBackground(background);
			
			// Create a Sprite
			string playerImageAsString = "O\n>>\n/\\";
			Image playerImage = new Image(playerImageAsString);
			Sprite TestSprite = RenderPipe.NewSprite(1, 1, playerImage);
			
			
			
			
			RenderPipe.UpdateScreen();
			RenderPipe.Draw();
			Console.ReadKey();
		}
	}
}