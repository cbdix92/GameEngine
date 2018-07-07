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
			scene1.gameobjects["ball"].AddComponet(new Image("O"));
			
		}
	}
}