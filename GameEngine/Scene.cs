using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class Scene
    {
        public Render render;

        public Dictionary<string, Gameobject> gameobjects;
		
		public Scene()
		{
            gameobjects = new Dictionary<string, Gameobject>();
            render = new Render(this);
		}


        public void AddGameobject(string name)
        {
			gameobjects.Add(name, new Gameobject(this, name));
        }

        public void AddBackground(string name)
        {
            gameobjects.Add(name, new Background(this, name));
        }
		
		public void Update()
		{
			// Call Update method on each Gameobject inside of the scene
		}
    }
}
