using System;
using Utils;

namespace GameEngine
{

    public static class RenderEngine
    {

        private static char[,] screen;
        private static char[,] background;

        private static Sprite[] spriteList;
		
		private static char[,] imageBuffer;


        public static void Init(int ScreenY, int ScreenX)
        {
            if (screen == null || background == null)
            {
                screen = new char[ScreenY, ScreenX];
                background = new char[ScreenY, ScreenX];
            }
        }
		
		public static void SetBackgroundImage(Image image)
		{
			imageBuffer = image.Get();
			// Iterate trough and fill the background with spaces (" ")
			for (int Y = 0; Y < imageBuffer.GetLength(0); Y++)
			{
				for (int X = 0; X < imageBuffer.GetLength(1); X++)
				{
					try
					{
						background[Y, X] = imageBuffer[Y, X];
					}
					catch (IndexOutOfRangeException) // Image to large for background. Tile the image
					{
						background[Y, X] = imageBuffer[imageBuffer.GetLength(0) - 1, imageBuffer.GetLength(1) - 1];
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
                    if (background[Y, X] != '\0')
                    {
					    screen[Y, X] = background[Y, X];
                    }
				}
			}

            // Check is a Sprite object was ever instantiated. If not, skip the sprite check.
            if (spriteList == null) { goto SkipSpriteCheck; }

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
							if (imageBuffer[Y, X] == '\0'){ continue; }// skip blank spaces in the image
							try
							{
								screen[sprite.position.PosY + Y, sprite.position.PosX + X] = imageBuffer[Y, X];
							}
							catch (IndexOutOfRangeException)
							{
								continue;
							}
						}
					}
				}
			}
            SkipSpriteCheck:;
        }
		
		public static Sprite NewSprite(int Xpos, int Ypos, Image image)
		{
			if (spriteList == null)
			{
				spriteList = new Sprite[1];
			}
			else
			{
				// Increment SpriteList size.
				Array.Resize(ref spriteList, spriteList.Length + 1);
			}
			
			// Replace next null occurence with a new instance of Sprite.
			spriteList[Array.IndexOf(spriteList, null)] = new Sprite(new Position(Xpos, Ypos, screen), image, screen);
			
			// Return a reference to the Sprite we just created so we can issue commands from the top level.
			return spriteList[spriteList.Length - 1];
			
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
    }
	
    public class Sprite
    {
		
        public Position position;
		public Image image;
		public bool Active;
		public char[,] screenRefrence;

		
        public Sprite(Position position, Image image, char[,] screenRefrence)
        {
            this.position = position;
			this.image = image;
			this.screenRefrence = screenRefrence;
			this.Active = true;

        }
		
    }

    public class Position
    {
        public int PosY { get; set; }
        public int PosX { get; set; }
		public char[,] screenRefrence;

        public Position(int X, int Y, char[,] screenRefrence)
        {
            PosY = Y;
			PosX = X;
			this.screenRefrence = screenRefrence;
        }
		
		public void Teleport(int X, int Y)
		{
			
			if (Y > screenRefrence.GetLength(0))
			{
				Teleport(X, Y - screenRefrence.GetLength(0) - 1);
			}
			else if (X > screenRefrence.GetLength(1))
			{
				Teleport(X - screenRefrence.GetLength(1) - 1, Y);
			}
			else
			{
				PosY = Y;
				PosX = X;
			}
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
		
		public Image()
		{
			/* EMPTY CONSTRUCTOR METHOD DO NOT REMOVE! */
		}
		public Image(string source)
		{
			/* Overload contructor method allowing an image to be added at instantiation time */
			Convert(source);
		}
		
		
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
