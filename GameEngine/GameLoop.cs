using System;

namespace GameEngine
{
    static class GameLoop
    {
        static bool quit = false;
		
        static void Start()
        {
            while(!quit)
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
