using System;

namespace GameEngine
{
	public static class Display
	{
		public static int ScreenX { get; set; }
		public static int ScreenY { get; set; }
		
		public static void Init(int screenX, int screenY)
		{
			ScreenX = screenX;
			ScreenY = screenY;
            Render.Init();
		}
	}
}