using System;

namespace Utils
{
    static class Utils
    {
        public static int[] GetArrayRange(int sourceArrayLength)
        {
            /* 
            Returns an int[] equal to the length of another array. 
            Each element of the new array will contain a number equal to it's index. 
            allowing -> foreach (int Index in GetArrayRange(Array.GetLength(0))) 
            */
            int[] temp = new int[sourceArrayLength];
            for (int count = 0; count < sourceArrayLength; count++)
            {
                temp[count] = count;
            }
            return temp;
        }

        public static int[] CalculateArraySize(string source)
        {
            /* Calculate the size needed for a two dimensional array to contain a string object seperated into chars. */

            int sizeY = 1;
            int sizeX = 0;
            int maxX = 0;

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

            return new int[2] { maxX, sizeY };

        }
    }
}