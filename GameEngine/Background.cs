using System;

namespace GameEngine
{
	public class Background
	{
		public Image background;
		private char[,] buffer;

        Scene parentScene;
        int zBuffer;
        string name;

        public Background(Scene parentScene,int zBuffer, string name)
		{
            this.parentScene = parentScene;
            this.zBuffer = zBuffer;
            this.name = name;
		}
		
		public void SetBackground(Image image)
		{
            background = image;
		}

        public void SetBackground(string source)
        {
            // OVERLOAD METHOD
            background = new Image(source);
        }

        public void FillBackground(Image image)
        {
            /* 
			 * Fill the background with Image object.
			 * If the Image object is not large enough to fill the background, it will be tiled.
			 */
            Core.FillArray(ref this.buffer, image.Get());
            background = new Image() { image = buffer };
		}

        public void FillBackground(string source)
        {
            // OVERLOAD METHOD
            Core.FillArray(ref this.buffer, new Image(source).Get());
            background = new Image() { image = buffer };
        }
	}
}