using System;
using System.Threading;
using GameEngine;

namespace App
{
	class AppClass
	{
		
		static void Main(string[] args)
		{
			Updates.FrameCap = 10;
			Render.showStats = true;
			int playerPosY = 0;
			int playerPosX = 0;
			
			Render.Init(25, 25);

            // Fill Background
            string backgroundFiller = "_";
            Render.FillBackground(backgroundFiller);

			

			
			// Create a Sprite
			Sprite playerSprite = Render.NewSprite(playerPosY, playerPosX);
            string playerImageAsString = "O\n>>\n/\\";
            playerSprite.NewStaticImage(playerImageAsString);
            //string animationTest = "~~~\tPPP\t<<<\t~~~\tLLL\t555\t";
            //playerSprite.NewStaticAnimation(animationTest);
			
			int time = 0;
			int endOfTime = 1000;
			while(time < endOfTime)
			{
                // teleport the sprite back every five loops
				if (time%5 == 0)
				{
					playerSprite.position.Teleport(0,0);
				}
                // move sprite across screen
				playerSprite.position.PosY++;
				playerSprite.position.PosX++;

				Render.UpdateScreen();
				Render.Draw();

				time++;

                Updates.Wait();
			}
		}
	}
}