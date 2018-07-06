using System;

namespace GameEngine
{
	class Background : Gameobject
	{
		public char[,] background;
		private char[,] buffer;
		
		public Background()
		{
		}
		
		public void SetBackground(Image image)
		{
			buffer = image.Get();
			foreach (int Y in RCore.GetArrayRange(buffer.GetLength(0)))
			{
				foreach (int X in RCore.GetArrayRange(buffer.GetLength(1)))
				{
                    if (Y >= background.GetLength(0) || X >= background.GetLength(1))
                    {
                        continue;
                    }
                    background[Y, X] = buffer[Y, X];
				}
			}
		}
		
		public void FillBackground(Image image)
		{
			/* 
			 * Fill the background with Image object.
			 * If the Image object is not large enough to fill the background, it will be tiled.
			 */
			RCore.FillArray(ref this.background, image.Get());
		}
	}
}