using System;

namespace GameEngine
{
    static class GameLoop
    {
        public static bool quit = false;
		
		public static Scene[] scenes;
		
        static void Start()
        {
			Render.Init();
            Updates.Init();

            while (!quit)
            {
                // User Input
                // See System.Windows.Input.AddKeyDownHandler() => GameEngine.Input.Update(). This is how we will check input whenever ANY key is pressed ...

                // Update Gameobjects

                // Render the Scene

                // Timestep
                Updates.Wait();
            }

        }
    }
}
