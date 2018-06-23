using System;

namespace GameEngine
{

    public static class RenderEngine
    {

        private static char[,] screen;
        private static char[,] background;

        private static Sprite[] spriteList = new Sprite[1];
		
		private static char[,] imageBuffer;


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
				if (sprite == null){continue;}
				if (sprite.Active == true)
				{
					imageBuffer = sprite.image.Get();
					
					for (int Y = 0; Y < imageBuffer.GetLength(0); Y++)
					{
						for (int X = 0; X < imageBuffer.GetLength(1); X++)
						{
							screen[sprite.position.PosY + Y, sprite.position.PosX + X] = imageBuffer[Y, X];
						}
					}
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
		
		public static void AddNewSprite(Position position, Image image,  string name)
		{
			// Increment SpriteList size.
			Array.Resize(ref spriteList, spriteList.Length + 1);
			
			// Replace next null occurence with a new instance of Sprite.
			spriteList[Array.IndexOf(spriteList, null)] = new Sprite(position, image, name);
			
		}
		
		public static void SetBackgroundImage(Image image)
		{
			imageBuffer = image.Get();
			// Iterate trough and fill the background with spaces (" ")
			for (int Y = 0; Y < background.GetLength(0); Y++)
			{
				for (int X = 0; X < background.GetLength(1); X++)
				{
					try
					{
						background[Y, X] = imageBuffer[Y, X];
					}
					catch (IndexOutOfRangeException e) // Image to large for background. Tile the image
					{
						background[Y, X] = imageBuffer[imageBuffer.GetLength(0) - 1, imageBuffer.GetLength(1) - 1];
					}
				}
			}
			
		}

    }
	
    public class Sprite
    {
		
        public Position position;
		public Image image;
		public string Name;
		public bool Active;

		
        public Sprite(Position position, Image image, string name)
        {
            this.position = position;
			this.image = image;
			this.Name = name;
			this.Active = true;

        }
		
    }

    public class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Position(int X, int Y)
        {
            PosX = X;
            PosY = Y;
        }
    }
	
	public class Image
	{
		char[,] image;
		int sizeY = 1;
		int sizeX = 0;
		int maxX = 0;
		int indexCountY = 0;
		int indexCountX = 0;
		
		
		public void Convert(string source)
		{
			// Calculate the neccesary size if the Image array
			foreach (char item in source)
			{
				if (item == '\n')
				{
					sizeY++;
					if (sizeX > maxX) { maxX = sizeX; }
					sizeX = 0;
					continue;
				}
				sizeX++;
			}
			
			// Instance the Image Array with proper size
			image = new char[sizeY, maxX];
			
			// convert string onto char array and assign it to the proper position inside of the image array
			foreach (char item in source)
            {
                if (item == '\n')
                {
                    indexCountY++;
                    indexCountX = 0;
                }
                else
                {
                    image[indexCountY, indexCountX] = item;
                    indexCountX++;
                }
            }
		}
		
		public char[,] Get()
		{
			return image;
		}
	}
}
