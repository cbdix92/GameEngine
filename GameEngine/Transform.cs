using System;

namespace GameEngine
{
    class Transform : Componet
    {
        Vector2 position;

        public Transform()
        {
            position = new Vector2(0,0);
        }
    }

    class Vector2
    {
        int X;
        int Y;
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
