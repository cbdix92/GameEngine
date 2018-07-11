using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class Scene
    {
        public Render render;

        public Dictionary<string, Gameobject> gameobjects;

        public Background[] backgrounds;
		
		public Scene()
		{
            gameobjects = new Dictionary<string, Gameobject>();
            render = new Render(this);
		}


        public Gameobject AddGameobject(string name)
        {
			gameobjects.Add(name, new Gameobject(this, name));
            return gameobjects[name];
        }

        public Background AddBackground(int zBuffer, string name)
        {
            Core.ListUp<Background>(ref backgrounds);
            backgrounds[backgrounds.Length - 1] = new Background(this,zBuffer, name);
            return backgrounds[backgrounds.Length - 1];

        }
		
		public void Update()
		{
			// Call Update method on each Gameobject inside of the scene
		}
    }
}
