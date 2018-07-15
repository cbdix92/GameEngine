using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class Scene
    {

        public Dictionary<string, Gameobject> gameobjects;

        public Background[] backgrounds;
		
		public Scene()
		{
            gameobjects = new Dictionary<string, Gameobject>();
			
			// Add current instance of Scene to GameLoop
			Core.ListUp<Scene>(GameLoop.scenes);
			GameLoop.scenes[GameLoop.scenes.Length - 1] = this;
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
			// Call Update method on each Background and then Gameobject inside of the scene
			foreach (int index in Core.GetArrayRange(backgrounds.Length))
			{
				backgrounds[index].Update();
			}
			
			foreach (string key in gameobjects.Keys)
			{
				gameobjects[key].Update();
			}
		}
    }
}
