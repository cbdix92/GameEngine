using System;
using System.Threading;
using System.Diagnostics;

namespace GameEngine
{

    static class LoopController
    {
        private static int waitInMilliseconds = 10;
        private static int actualLoopsPerSecond = 0;

        // Used to slow the main Game Loop
        private static Stopwatch loopTimer = new Stopwatch();

        public static void MainWait(int targetLoopsPerSecond)
        {
            /* 
             * Used inside of the Render.Draw() Method since it should be the last thing done inside of the Game Loop.
             */
             
            actualLoopsPerSecond++;
            // Slow GameLoop
            Thread.Sleep(waitInMilliseconds);
            // Check stopWatch to if one second has passed yet
            if (loopTimer.ElapsedMilliseconds >= 1000)
            {
                // Reset loopTimer
                loopTimer.Reset();
                loopTimer.Start();

                // Adjust refreshRate
                if (actualLoopsPerSecond > targetLoopsPerSecond)
                {
                    waitInMilliseconds += 10;
                }
                else
                {
                    waitInMilliseconds -= 10;
                }
                actualLoopsPerSecond = 0;
            }
        }
    }
}
