using System;

namespace GameEngine
{
	class Background : Gameobject
	{
		public Image background;
		private char[,] buffer;

        public Background(Scene parentScene, string name) : base(parentScene, name)
		{
		}
		
		public void SetBackground(Image image)
		{
            background = image;
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
	}
}