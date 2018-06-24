using System;
using GameEngine;

namespace App
{
	class AppClass
	{
		static void Main(string[] args)
		{
			// sprite Image
			string image = "@@@\n@@@@\n@@@@@\n@@@";
			Image imageConvert = new Image(image);
			//imageConvert.Convert(image);
			
			// Background image
			string backgroundString = "....\n....\n....\n..........";
			Image background = new Image(backgroundString);
			//background.Convert(backgroundString);
			
			RenderPipe.Init(10, 10);
			
			Sprite TestSprite = RenderPipe.NewSprite(2, 1, imageConvert);
			//TestSprite.position.Teleport(1, 20);
			
			RenderPipe.SetBackgroundImage(background);
			
			
			
			RenderPipe.UpdateScreen();
			RenderPipe.Draw();
			Console.ReadKey();
		}
	}
}