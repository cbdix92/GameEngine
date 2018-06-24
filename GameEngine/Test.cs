using System;
using GameEngine;
using Utils;

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
			string backgroundString = "....\n....\n....\n....";
			Image background = new Image(backgroundString);
			//background.Convert(backgroundString);
			
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