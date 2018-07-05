using System;

namespace GameEngine
{
    class Scene
    {
        Gameobject[] gameobjects;


        public void AddGameobject()
        {
			RCore.ListUp<Gameobject>(ref gameobjects);
            gameobjects[Array.IndexOf(gameobjects, null)] = new Gameobject();
        }
    }
}
