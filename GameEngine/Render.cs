using System;
using System.Diagnostics;


namespace GameEngine
{

    public static class Render
    {
        private static char[,] screen;
		
		private static Image[] renderQueue;

		// Flags
		public static bool showStats = false;

		
		public static void Init()
		{
            screen = new char[Display.ScreenY, Display.ScreenX];
		}

        public static void UpdateScreen()
        {
			// Check renderQueue and write each Image to the screen.
			// ...
			
			
			
			
			
			
			//*******************************************************************************************
            /*
             * Updates the screen buffer and prepares it to be written to the screen by the Draw() method
             * 
             */

            // Fill screen with background
            /*foreach (int Y in Core.GetArrayRange(background.GetLength(0)))
			{
				foreach (int X in Core.GetArrayRange(background.GetLength(1)))
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
					
					foreach (int Y in Core.GetArrayRange(imageBuffer.GetLength(0)))
					{
						foreach (int X in Core.GetArrayRange(imageBuffer.GetLength(1)))
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
            SkipSpriteCheck:;*/
        }

		public static void Draw()
        {
            Console.Clear();
			
            if (showStats) { DrawStats(); }
			
            // Draw the screen
            foreach (int Y in Core.GetArrayRange(screen.GetLength(0)))
            {
                foreach (int X in Core.GetArrayRange(screen.GetLength(1)))
                {
                    Console.Write(screen[Y, X]);
                }
                Console.WriteLine();
            }
        }
		
		public static void DrawStats()
		{
			Console.WriteLine(" FPS: {0} WaitTime: {1} ", Updates.statFPS, Updates.statDeltaTime);
		}
    }
	
    /*public class Sprite
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
        public State NewState(string name)
        {
            // New State with NO Image or Animation

            // Resize the list
            Core.ListUp<State>(ref stateList);

            stateList[Array.IndexOf(stateList, null)] = new State(name);

            return stateList[stateList.Length - 1];
        }

        public State NewImageState(string imageSource, string name)
        {
            // New State with Image

            // Resize the imageList and add a new instance of Image
            Core.ListUp<Image>(ref imageList);
            imageList[Array.IndexOf(imageList, null)] = new Image(imageSource);

            // Resize the stateList and add a new instance of State
            Core.ListUp<State>(ref stateList);
            stateList[Array.IndexOf(stateList, null)] = new State(imageList[imageList.Length - 1], name);

            // Return a reference of the State instance to the top level
            return stateList[stateList.Length - 1];
        }

        public State NewAnimationState(string animationSource, string name)
        {
            // New State with Animation

            // Resize the animationList and add a new instance of Animation
            Core.ListUp<Animation>(ref animationList);
            animationList[Array.IndexOf(animationList, null)] = new Animation(animationSource);

            // Resize the stateList and add a new instance of State
            Core.ListUp<State>(ref stateList);
            stateList[Array.IndexOf(stateList, null)] = new State(animationList[animationList.Length - 1], name);

            // Return a reference of the State instance to the top level
            return stateList[stateList.Length - 1];
        }
		
		public Image NewStaticImage(string imageSource)
		{
            // New Image without a state attached. This will be dispayed at all times.

            // Delete Animation if one exist. Can only have Image or Animation without a state system. Not both.
			if (animation != null)
            {
                animation = null;
            }
			image = new Image(imageSource);
			
			return image;
		}
		
		public Animation NewStaticAnimation(string animationSource)
		{
            // New Animation without a state attached. This will be displayed at all times.

            // Delete Image if one exist. Can only have Image or Animation without a state system. Not both.
            if (image != null)
            {
                image = null;
            }

			animation = new Animation(animationSource);
			
			return animation;
			
		}

        public void ChangeState(string name)
        {
            // Change currentState = State.name if State.name exist in the stateList.
            foreach (int index in Core.GetArrayRange(stateList.Length))
            {
                if (stateList[index].Name == name )
                {
                    stateList[index].state = true;
                    if (currentState != null)
                    {
                        currentState.Reset();
                        currentState = stateList[index];
                    }
                    else if (currentState == null)
                    {
                        currentState = stateList[index];
                    }
                }
            }
        }
		
		public char[,] GetImage()
		{
			 // Check Sprite's current state. 
			 // Then check if that state has an associated animation or image to be displayed. 
			 // Then return that animation frame or image


            // Check if Sprite has any States that will yield an image
            if (stateList != null)
            {
                foreach (int index in Core.GetArrayRange(stateList.Length))
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
    }*/
}
