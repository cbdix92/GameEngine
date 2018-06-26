using System;
using System.Threading;
using GameEngine;

namespace App
{
	class AppClass
	{
		static void Main(string[] args)
		{
			int playerPosY = 0;
			int playerPosX = 0;
			
			Render.Init(10, 10);
			
			string animationTest = "O\n>>\n/\\n\tO\n<<\n/\\n\t";
			
			// Fill Background
			Image backgroundFillTest = new Image("_");
			Render.FillBackground(backgroundFillTest);
			
			// Create a Sprite
			string playerImageAsString = "O\n>>\n/\\";
			Image playerImage = new Image(playerImageAsString);
			Sprite TestSprite = Render.NewSprite(playerPosY, playerPosX, playerImage);
			
			
			
			
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			TestSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			TestSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			TestSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			TestSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			
			Console.ReadKey();
		}
	}
}