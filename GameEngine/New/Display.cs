using System;

namespace GameEngine
{
	class static Display
	{
		public int ScreenX { get; }
		public int ScreenY { get; }
		
		public void Init(int screenX, int screenY)
		{
			ScreenX = screenX;
			screenY = screenY;
		}
	}
}