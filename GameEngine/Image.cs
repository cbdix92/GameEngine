using System;

namespace GameEngine
{
    class Image : Componet
    {
		public delegate void RenderCallEventHandler(object source, EventArgs args);
		public event RenderCallEventHandler RenderCall;
		
        private char[,] image;
        private int[] size;

        public Image()
        {
        }
        public Image(string source)
        {
            Convert(source);
        }
		
		protected virtual void OnRenderCall()
		{
			if (RenderCall != null)
			{
				RenderCall(this, new RenderCallEventArgs() { image = this.image; })
			}
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
			// Used by the Background methods. Do not remove.
			return image;
		}

		public void Update()
		{
			// Raise Render Event.
			// ...
		}
    }
}
