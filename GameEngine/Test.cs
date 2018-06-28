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

            // Fill Background
            Image backgroundFillTest = new Image("_");
            Render.FillBackground(backgroundFillTest);

            string animationTest = "O\n>>\n/\\n\tO\n<<\n/\\n\t";
            Animation playerAnimation = new Animation(animationTest);
			

			
			// Create a Sprite
			string playerImageAsString = "O\n>>\n/\\";
			Sprite playerSprite = Render.NewSprite(playerPosY, playerPosX);
            Image playerImage = playerSprite.NewImage(playerImageAsString);
			
			
			
			
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			playerSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			playerSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			playerSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			Thread.Sleep(200);
			playerSprite.position.Teleport(playerPosY++, playerPosX++);
			Render.UpdateScreen();
			Render.Draw();
			
			Console.ReadKey();
		}
	}
}