using System;

namespace GameEngine
{
    class Scene
    {
        Gameobject[] gameobjects;


        public void AddGameobject()
        {
            if (gameobjects == null)
            { gameobjects = new Gameobject[1]; }

            gameobjects[Array.IndexOf(gameobjects, null)] = new Gameobject();
        }
    }
}
