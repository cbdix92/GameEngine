using System;

namespace GameEngine
{
    class Image : Componet
    {
        private char[,] image;
        private int[] size;

        public Image()
        {
            /* EMPTY CONSTRUCTOR METHOD DO NOT REMOVE! */
        }
        public Image(string source)
        {
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

		public void Update()
		{
			// Raise Render Event.
			// ...
		}
    }
}
