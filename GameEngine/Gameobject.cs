using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class Gameobject
    {
		public Dictionary<string, Componet> componets = new Dictionary<string, Componet>();
		
		public string name;
        private Scene parentScene = null;
        public Transform transform;

        public Gameobject(Scene parentScene, string name)
        {
            transform = new Transform();
            this.name = name;
            this.parentScene = parentScene;
        }

        public void AddComponet(string name, Componet componet)
        {
			componets.Add(name, componet);
        }
		
		public void RemoveComponet(string name)
		{
			componets.Remove(name);
		}

        public void ParentScene(Scene parentScene)
        {
            this.parentScene = parentScene;
        }
		
		public void Update()
		{
			// Call Update method on each Componet of the Gameobject.
		}

        public void FillBackground(Image image)
        {
        }
    }
	
	public class Componet
	{
	}
}
