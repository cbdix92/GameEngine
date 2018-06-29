﻿using System;

namespace GameEngine
{

    public static class Render
    {

        private static char[,] screen;
        private static char[,] background;

        private static Sprite[] spriteList;
		
		// Temporary storage for an image being written to the screen.
		private static char[,] imageBuffer;


        public static void Init(int ScreenY, int ScreenX)
        {
            if (screen == null || background == null)
            {
                screen = new char[ScreenY, ScreenX];
                background = new char[ScreenY, ScreenX];
            }
        }
		
		public static void SetBackground(Image image)
		{
			imageBuffer = image.Get();
			foreach (int Y in RCore.GetArrayRange(imageBuffer.GetLength(0)))
			{
				foreach (int X in RCore.GetArrayRange(imageBuffer.GetLength(1)))
				{
                    if (Y >= background.GetLength(0) || X >= background.GetLength(1))
                    {
                        continue;
                    }
                    background[Y, X] = imageBuffer[Y, X];
				}
			}
		}
		
		public static void FillBackground(Image image)
		{
			
			/* 
			 * Fill the background with Image object.
			 * If the Image object is not large enough to fill the background, it will be tiled.
			 * !!!NOT COMPLETE. DO NOT USE.!!!
			 */
			
			imageBuffer = image.Get();
			 
			RCore.FillArray(ref background, imageBuffer);
		}

        public static void UpdateScreen()
        {

            // Fill screen with background
            foreach (int Y in RCore.GetArrayRange(background.GetLength(0)))
			{
				foreach (int X in RCore.GetArrayRange(background.GetLength(1)))
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
                    imageBuffer = sprite.GetImage();
					
					foreach (int Y in RCore.GetArrayRange(imageBuffer.GetLength(0)))
					{
						foreach (int X in RCore.GetArrayRange(imageBuffer.GetLength(1)))
						{
							if (imageBuffer[Y, X] == '\0' || Char.IsWhiteSpace(imageBuffer[Y, X]) ){ continue; }// skip blank spaces in the image
							try
							{
								screen[sprite.position.PosY + Y, sprite.position.PosX + X] = imageBuffer[Y, X];
							}
							catch (IndexOutOfRangeException)
							{
								// This will skip parts of the sprite that are no longer on the screen.
								continue;
							}
						}
					}
				}
			}
            SkipSpriteCheck:;
        }
		
		public static Sprite NewSprite(int Xpos, int Ypos)
		{
            // Resize the list
            RCore.ListUp<Sprite>(ref spriteList);
			
			// Replace next null occurrence with a new instance of Sprite.
			spriteList[Array.IndexOf(spriteList, null)] = new Sprite(new Position(Xpos, Ypos, screen), screen);
			
			// Return a reference to the Sprite we just created so we can issue commands from the top level.
			return spriteList[spriteList.Length - 1];
			
		}

		public static void Draw()
        {

            Console.Clear();
            // Draw the screen
            foreach (int Y in RCore.GetArrayRange(screen.GetLength(0)))
            {
                foreach (int X in RCore.GetArrayRange(screen.GetLength(1)))
                {
                    Console.Write(screen[Y, X]);
                }
                Console.WriteLine();
            }
        }
    }
	
    public class Sprite
    {
        public bool Active;
        public Position position;
        public State currentState;

        public Image image;
        public Animation animation;

		public Image[] imageList;
		public Animation[] animationList;
        public State[] stateList;


		public char[,] screenRefrence;

		
        public Sprite(Position newPosition, char[,] newScreenRefrence)
        {
            position = newPosition;
			screenRefrence = newScreenRefrence;
            Active = true;

        }
        public State NewState(bool newState, string name)
        {
            // New State with NO Image or Animation

            // Resize the list
            RCore.ListUp<State>(ref stateList);

            stateList[Array.IndexOf(stateList, null)] = new State(newState, name);

            return stateList[stateList.Length - 1];
        }

        public State NewState(Image image, bool newState, string name)
        {
            // New State with Image

            // Resize the list
            RCore.ListUp<State>(ref stateList);

            stateList[Array.IndexOf(stateList, null)] = new State(image, newState, name);

            return stateList[stateList.Length - 1];
        }

        public State NewState(Animation animation, bool newState, string name)
        {
            // New State with Animation

            // Resize the list
            RCore.ListUp<State>(ref stateList);

            stateList[Array.IndexOf(stateList, null)] = new State(animation, newState, name);

            return stateList[stateList.Length - 1];
        }
		
		public Image NewImage(string imageSource)
		{
			if (animation != null)
            {
                animation = null;
            }
			image = new Image(imageSource);
			
			return image;
		}
		
		public Animation NewAnimation(string animationSource)
		{
            if (image != null)
            {
                image = null;
            }

			animation = new Animation(animationSource);
			
			return animation;
			
		}

        public void ChangeState(string name)
        {
            foreach (int index in RCore.GetArrayRange(stateList.Length))
            {
                if (stateList[index].Name == name )
                {
                    stateList[index].state = true;
                    if (currentState != null)
                    {
                        currentState.Reset();
                        currentState = stateList[index];
                    }
                }


            }
        }
		
		public char[,] GetImage()
		{
            /*
			 * Check Sprite's current state. 
			 * Then check if that state has an associated animation or image to be displayed. 
			 * Then return that animation frame or image.
			 *
			 *
			 */


            // Check if Sprite has any States that will yield an image
            if (stateList != null)
            {
                foreach (int index in RCore.GetArrayRange(stateList.Length))
                {
                    if (stateList[index].state == true)
                    {
                        return stateList[index].GetImage().Get();
                    }
                }
            }

            // Check if Sprite has an Animation
            else if (animation != null)
            {
                return animation.GetImage().Get();
            }

            // Finally check if Sprite has an Image
            else if (image != null)
            {
                return image.Get();
            }

            // If Sprite does no contain any images to render then return and empty array.
            return new char[0, 0];

            

			
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
			PosY = Y;
			PosX = X;
		}
    }
	
	public class Image
	{
		private char[,] image;
        private int[] size;
		
		public Image()
		{
			/* EMPTY CONSTRUCTOR METHOD DO NOT REMOVE! */
		}
		public Image(string source)
		{
			/* 
             * Overload constructor method allowing an image to be added at instantiation time 
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
            size = RCore.CalculateArraySize(source);
			image = new char[size[0], size[1]];
			
			// Convert string into char array and assign it to the proper position inside of the image array
			RCore.StringToArray(ref image, source);
		}
		
		public char[,] Get()
		{
			return image;
		}
	}
	
	public class Animation
	{
		/*
		 * Images are stored in the animation array.
		 * The keyFrame is used to index the animation array, returning an Image to be rendered.
		 *
		 */
		
		private int keyFrame = 0;
		private Image[] animation;
		
		private string frameBuffer;
		
		public Animation(string animationSource)
		{
			animation = new Image[RCore.CalculateKeyFrames(animationSource)];
			foreach (char item in animationSource)
			{
				if (item != '\t')
				{
					frameBuffer = String.Concat(frameBuffer, item);
				}
				else if (item == '\t')
				{
					animation[keyFrame] = new Image(frameBuffer);
                    frameBuffer = "";
					keyFrame++;
				}
			}

            keyFrame = 0;
			
		}

        public Image GetImage()
        {
            // Loop the animation
            if (keyFrame == animation.Length)
            {
                keyFrame = 0;
            }

            keyFrame++;
            return animation[keyFrame - 1];
        }

        public void Reset()
        {
            // returns the object back to a starting position.
            keyFrame = 0;
        }
		
	}

    public class State
    {
        // Only references are passed to the State class.
        // The Image and Animation classes are instantiated in the Sprite class.
        public Image imageReference;
        public Animation animationReference;
        public string Name { get; }

        public bool state { get; set; }

        public State(bool newState, string name)
        {
            state = newState;
            Name = name;
        }

        public State(Image image, bool newState, string name)
        {
            imageReference = image;
            state = newState;
            Name = name;
        }

        public State(Animation animation, bool newState, string name)
        {
            animationReference = animation;
            state = newState;
            Name = name;
        }

        public void SetImage(Image image)
        {
            imageReference = image;
        }

        public void SetAnimation(Animation animation)
        {
            animationReference = animation;
        }

        public Image GetImage()
        {
            if (imageReference != null)
            {
                return imageReference;
            }
            else if (animationReference != null)
            {
                return animationReference.GetImage();
            }
            return new Image();
        }

        public void Reset()
        {
            if (animationReference != null)
            {
                animationReference.Reset();
            }
            state = false;

        }




    }

}
