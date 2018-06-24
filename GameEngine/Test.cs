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
			string backgroundString = "..\n";
			Image background = new Image();
			background.Convert(backgroundString);
			
			RenderEngine.Init(10, 10);
			
			Sprite TestSprite = RenderEngine.NewSprite(2, 1, imageConvert);
			TestSprite.position.Teleport(1, 20);
			
			RenderEngine.SetBackgroundImage(background);
			
			RenderEngine.UpdateScreen();
			RenderEngine.Draw();
			Console.ReadKey();
		}
	}
}