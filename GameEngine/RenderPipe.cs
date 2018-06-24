using System;

namespace GameEngine
{

    public static class RenderPipe
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
			foreach (int Y in Utils.GetArrayRange(imageBuffer.GetLength(0)))
			{
				foreach (int X in Utils.GetArrayRange(imageBuffer.GetLength(1)))
				{
                    if (Y >= background.GetLength(0) || X >= background.GetLength(1))
                    {
                        continue;
                    }
                    background[Y, X] = imageBuffer[Y, X];
				}
			}	
		}

        public static void UpdateScreen()
        {

            // Fill screen with background
            foreach (int Y in Utils.GetArrayRange(background.GetLength(0)))
			{
				foreach (int X in Utils.GetArrayRange(background.GetLength(1)))
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
					
					foreach (int Y in Utils.GetArrayRange(imageBuffer.GetLength(0)))
					{
						foreach (int X in Utils.GetArrayRange(imageBuffer.GetLength(1)))
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
            foreach (int Y in Utils.GetArrayRange(screen.GetLength(0)))
            {
                foreach (int X in Utils.GetArrayRange(screen.GetLength(1)))
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
        int[] size;
		
		public Image()
		{
			/* EMPTY CONSTRUCTOR METHOD DO NOT REMOVE! */
		}
		public Image(string source)
		{
			/* 
             * Overload contructor method allowing an image to be added at instantiation time 
             */
			Convert(source);
		}
		
		
		public void Convert(string source)
		{
            /*
             * Convert a string into a two-dimensional char array.
             * string "  @  \n @@@ \n@@@@@"
             * 
             *         |___@___|
             *         |__@@@__|
             * becomes:|_@@@@@_| Inside of a two-dimensional matrix
             * 
             * This makes it easier to draw to the screen buffer and subsequently be displayed to the user.
             */

            // Instance the Image Array with proper size
            size = Utils.CalculateArraySize(source);
			image = new char[size[0], size[1]];
			
			// Convert string into char array and assign it to the proper position inside of the image array
			Utils.StringToArray(ref image, source);
		}
		
		public char[,] Get()
		{
			return image;
		}
	}
}
