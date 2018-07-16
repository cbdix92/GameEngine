using System;

namespace GameEngine
{
	public static class Display
	{
		public static int ScreenX { get; set; }
		public static int ScreenY { get; set; }
		
		public static int bufferBackY = Console.BufferWidth;
		public static int bufferBackX = Console.BufferHeight;
		public static int windowBackY = Console.WindowWidth;
		public static int windowBackX = Console.WindowHeight;
		
		public static void DisplaySize(int screenX, int screenY)
		{
			ScreenX = screenX;
			ScreenY = screenY;
			try
			{
				Console.SetWindowSize(1, 1);
				Console.SetBufferSize(ScreenX, ScreenY);
				Console.SetWindowSize(5, 5);
				Console.WriteLine("Success!!!!");
			}
			catch(ArgumentOutOfRangeException e)
			{
				Reset();
				DefaultSet();
				Console.WriteLine(e.Message);
			}
		}
		
		public static void DefaultSet()
		{
			ScreenX = Console.BufferHeight;
			ScreenY = Console.BufferWidth;
		}
		
		public static void Reset()
		{
			Console.SetBufferSize(bufferBackY, bufferBackX);
			Console.SetWindowSize(windowBackY, windowBackX);
		}
	}
}