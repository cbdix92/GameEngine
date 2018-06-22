namespace GameEngine
{
    static class RenderEngine
    {
		
        private static char[,] screen;
		private static char[,] background;
		
		private static Sprite[] spriteList = new Sprite[1];
		
		
		public static void Init(int ScreenY, int ScreenX)
        {
          if (screen == null && background == null)
          {
            screen = new char[ScreenY, ScreenX];
			background = new char[ScreenY, ScreenX];
			
			// Iterate trough and fill the screen and background with spaces (" ")
			for (int Y = 0; Y < screen.GetLength(0); Y++)
			{
				for (int X = 0; X < screen.GetLength(1); X++)
				{
					screen[Y, X] = ' ';
					background[Y, X] = ' ';
				}
			}
          }
        }
		
        public static void Draw()
        {
			
			Console.Clear();
			// Draw the screen
			for (int Row = 0; Row < screen.GetLength(0); Row++)
			{
				for (int Col = 0; Col < screen.GetLength(1); Col++)
				{
					Console.Write(screen[Row, Col]);
				}
				Console.WriteLine();
			}
        }

		
        public static void UpdateScreen()
        {
			
			// Fill screen with background
			// ...
			
			// Fill screen with Sprites
			// ...
			
			
        }

    }
	public class Sprite
	{
		private Position position;
		
		public Sprite(int posX, int posY)
		{
			this.position = new Position(posX, posY);
			
		}
	}
	
	class Position
	{
		int posX { get; set; }
		int posY { get; set; }
		
		public Position(int X, int Y)
		{
			posX = X;
			posY = Y;
		}
	}
}
