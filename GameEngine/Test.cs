using System;
using System.Threading;
using GameEngine;

namespace App
{
	class AppClass
	{
		[STAThread]
		static void Main(string[] args)
		{
			Render.TargetFramesPerSecond = 5;
			Render.ShowFpsCounter = true;
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
			int elapsed = 100;
			while(time < elapsed)
			{
				if (time%5 == 0)
				{
					playerSprite.position.Teleport(0,0);
				}
				playerSprite.position.PosY++;
				playerSprite.position.PosX++;
				Render.UpdateScreen();
				Render.Draw();
				time++;
			}
		}
	}
}