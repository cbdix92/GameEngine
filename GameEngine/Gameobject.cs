using System;


namespace GameEngine
{
    class Gameobject
    {
		Dictionary<string, Componet> componets = new Dictionary<string, Componet>();
		
		string name;
        Scene parentScene = null;

        public Gameobject()
        {
            componets = new Componet[1] { new Transform() };
        }

        public void NewComponet(string name, Componet componet)
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
    }
	
	class Componet
	{
		// Base class used by componets of the Gameobject class.
	}
}
