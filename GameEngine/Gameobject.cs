using System;


namespace GameEngine
{
    class Gameobject
    {
        string name;
        Componet[] componets;
        Scene parentScene = null;

        public Gameobject()
        {
            componets = new Componet[1] { new Transform() };
        }

        public void NewComponet(Componet componet)
        {
			RCore.ListUp<Componet>(ref componets);
			componets[componets.Length - 1] = componet;
        }

        public void ParentScene(Scene parentScene)
        {
            this.parentScene = parentScene;
        }
    }
}
