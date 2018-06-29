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
			
			Render.Init(20, 20);

            // Fill Background
            string backgroundFillTest = "_";
            Render.FillBackground(backgroundFillTest);

			

			
			// Create a Sprite
			Sprite playerSprite = Render.NewSprite(playerPosY, playerPosX);
            //string playerImageAsString = "O\n>>\n/\\";
            //Image playerImage = playerSprite.NewImage(playerImageAsString);
            string animationTest = "~~~\tPPP\t<<<\t~~~\tLLL\t555\t";
            playerSprite.NewStaticAnimation(animationTest);
			
			
			
			
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