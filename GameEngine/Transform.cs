﻿using System;

namespace GameEngine
{
    public class Transform : Componet
    {
        private Vector2 position;

        public Transform()
        {
            position = new Vector2(0,0);
        }
		
		public void move(int x, int y)
		{
			position.X += x;
			position.Y += y;
		}
		
		public void Teleport(int x, int y)
		{
			position.X = x;
			position.Y = y;
		}
		
    }

    class Vector2
    {
        public int X;
        public int Y;
		
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
