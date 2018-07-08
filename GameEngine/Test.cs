using System;
using System.Threading;
using GameEngine;

namespace App
{
	class AppClass
	{
		
		static void Main(string[] args)
		{
			Display.Init(20, 20);
			
			Scene scene1 = new Scene();
			
			scene1.AddGameobject("ball");
			scene1.gameobjects["ball"].AddComponet("ball_image", new Image("O"));
            scene1.gameobjects["ball"].transform.Teleport(5, 5);
            scene1.AddBackground("background1");
            scene1.gameobjects["background1"].FillBackground(new Image("_"));
			
		}
	}
}