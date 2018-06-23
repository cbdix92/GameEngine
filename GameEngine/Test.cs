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
			Image imageConvert = new Image();
			imageConvert.Convert(image);
			
			// Background image
			string backgroundString = ".....\n.....\n.....\n.....";
			Image background = new Image();
			background.Convert(backgroundString);
			
			Position testSpritePos = new Position(2, 1);
			
			RenderEngine.Init(10, 10);
			
			RenderEngine.AddNewSprite(new Position(2, 1), imageConvert, "Test_Sprite");
			
			RenderEngine.SetBackgroundImage(background);
			
			RenderEngine.UpdateScreen();
			RenderEngine.Draw();
			Console.ReadKey();
		}
	}
}