using System;

namespace GameEngine
{
    public class Image : Componet
    {
		
        public char[,] image;
        private int[] size;
        private Gameobject parentObject; // Passed into Render Event as the source object allowing the renderer to get cordinates

        public Image()
        {
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
            size = Core.CalculateArraySize(source);
            image = new char[size[0], size[1]];

            // Convert string into char array and assign it to the proper position inside of the image array
            Core.StringToArray(ref image, source);
        }

        public void Parent(Gameobject newParent)
        {
            parentObject = newParent;
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
