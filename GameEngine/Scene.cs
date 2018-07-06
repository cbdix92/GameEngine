using System;
using Syatem.Collections.Generic;


namespace GameEngine
{
    class Scene
    {
        Render render;
		
		public Dictionary<string, Gameobject> gameobjects = new Dictionary<string, Gameobject>();
		
		public Scene()
		{
			render = new Render(this);
		}


        public void AddGameobject(string name)
        {
			gameobjects.Add(name, new Gameobject(name));
        }
		
		publi void Update()
		{
			// Call Update method on each Gameobject inside of the scene
		}
    }
}
