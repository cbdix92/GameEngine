using System;
using System.Threading;
using GameEngine;

namespace App
{
	class AppClass
	{
		
		static void Main(string[] args)
		{
			Display.DisplaySize(80, 80);
			
			Scene scene1 = new Scene();
			
			Gameobject ball = scene1.AddGameobject("ball");
			ball.AddComponet("ball_image", new Image("O"));
            ball.transform.Teleport(5, 5);
            Background background1 = scene1.AddBackground(0, "background1");
            background1.FillBackground(new Image("_"));
			
		}
	}
}