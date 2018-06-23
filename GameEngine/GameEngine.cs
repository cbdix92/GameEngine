using System;

namespace GameEngine
{

    static class RenderEngine
    {

        private static char[,] screen;
        private static char[,] background;

        private static Sprite[] spriteList = new Sprite[1];


        public static void Init(int ScreenY, int ScreenX)
        {
            if (screen == null || background == null)
            {
                screen = new char[ScreenY, ScreenX];
                background = new char[ScreenY, ScreenX];

                // Iterate trough and fill the background with spaces (" ")
                for (int Y = 0; Y < screen.GetLength(0); Y++)
                {
                    for (int X = 0; X < screen.GetLength(1); X++)
                    {
                        background[Y, X] = ' ';
                    }
                }
            }
        }


        public static void UpdateScreen()
        {

            // Fill screen with background
            for (int Y = 0; Y < background.GetLength(0); Y++)
			{
				for (int X = 0; X < background.GetLength(1); X++)
				{
					screen[Y, X] = background[Y, X];
				}
			}

            // Fill screen with Sprites
            foreach (var sprite in spriteList)
			{
				if (sprite.Active == true)
				{
					screen[sprite.position.PosY, sprite.position.PosX] = sprite.pixel;
				}
			}
        }
		
		public static void Draw()
        {

            Console.Clear();
            // Draw the screen
            for (int Y = 0; Y < screen.GetLength(0); Y++)
            {
                for (int X = 0; X < screen.GetLength(1); X++)
                {
                    Console.Write(screen[Y, X]);
                }
                Console.WriteLine();
            }
        }
		
		public static void AddNewSprite(string name, Position position, char pixel)
		{
			// Increment SpriteList size.
			Array.Resize(ref spriteList, spriteList.Length + 1);
			
			// Replace next null occurence with a new instance of Sprite.
			spriteList[Array.IndexOf(spriteList, null)] = new Sprite(name, position, pixel);
			
		}

    }
	
    class Sprite
    {
		
        private Position position;
		private char pixel;
		private string name;
		private bool active;

		
        public Sprite(Position position, char pixel, string name)
        {
            this.position = position;
			this.pixel = pixel;
			this.name = name;

        }
		public Active
		{
			get { return active; }
			set { active = value; }
		}
    }

    class Position
    {
        int PosX { get; set; }
        int PosY { get; set; }

        public Position(int X, int Y)
        {
            PosX = X;
            PosY = Y;
        }
    }
	
	class Image
	{
		char[,] Image; 
		
		public Image()
		{
			
			
		}
		
		public char[] loadSource(string source)
		{
			// Calculate the neccesary size if the Image array
			// ...
			
			// Instance the Image Array with proper size
			// ...
			
			// convert string onto char array and assign it to the proper position inside of the image array
			foreach (char item in source)
			{
				
			}
			
		}
	}
}
