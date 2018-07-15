using System;

namespace GameEngine
{
	public static class Display
	{
		public static int ScreenX { get; set; }
		public static int ScreenY { get; set; }
		
		public static void DisplaySize(int screenX, int screenY)
		{
			ScreenX = screenX;
			ScreenY = screenY;
			Console.SetBufferSize(ScreenX, ScreenY);
			Console.SetWindowSize(ScreenX, ScreenY);
		}
	}
}