using System;

public static class RCore
{
    public static int[] GetArrayRange(int sourceArrayLength)
    {
        /* 
        * Returns an int[] equal to the length of another array. 
        * Each element of the new array will contain a number equal to it's index. 
        * allowing -> foreach (int Index in GetArrayRange(Array.GetLength(0))) 
        * 
        */

        int[] temp = new int[sourceArrayLength];
        for (int index = 0; index < sourceArrayLength; index++)
        {
            temp[index] = index;
        }
        return temp;
    }

    public static int[] CalculateArraySize(string source)
    {
        /* 
         * Calculate the size needed for a two dimensional array to contain a string object seperated into chars. 
         * Used when converting strings into two-dimensional arrays.
         * 
         */

        int sizeY = 1;
        int sizeX = 0;
        int maxX = 0;

        foreach (char item in source)
        {
            if (item == '\n')
            {
                sizeY++;
                sizeX = 0;
                continue;
            }
            sizeX++;
			if (sizeX > maxX) { maxX = sizeX; }
        }

        return new int[2] { sizeY, maxX };

    }
	
	public static int CalculateKeyFrames(string animationSource)
	{
		int count = 0;
		
		foreach (char item in animationSource)
		{
			if (item == '\t')
			{
				count++;
			}
		}
		return count;
	}
	
	public static void StringToArray(ref char[,] image, string source)
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
		int indexCountY = 0;
		int indexCountX = 0;
		
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

    public static void FillArray(ref char[,] target, char[,] image)
    {
        int indexY = 0;
        int indexX = 0;
        
        foreach (int Y in GetArrayRange(target.GetLength(0)))
        {
            if (Y != 0)
            {
                indexY++;
                indexX = 0;
            }
            if (indexY == image.GetLength(0))
            {
                indexY = 0;
            }
            foreach (int X in GetArrayRange(target.GetLength(1)))
            {
                if (indexX == image.GetLength(1))
                {
                    indexX = 0;
                }
                target[Y, X] = image[indexY, indexX];
                indexX++;


            }
        }

    }
	
	public static void ListUp<T> (ref T[] targetList, string source)
	{
		if (targetList == null)
		{
			targetList = new T[1];
		}
		else
		{
			Array.Resize(ref targetList, targetList.Length + 1);
		}
		
		targetList[Array.IndexOf(targetList, null)] = (T)Activator.CreateInstance(typeof(T));
		
	}
}



