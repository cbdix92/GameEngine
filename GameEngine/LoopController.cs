using System;
using System.Threading;
using System.Diagnostics;

namespace GameEngine
{

    public static class LoopController
    {
        private static int waitInMilliseconds { get; set; }
        private static int actualLoopsPerSecond = 0;
		public static int displayFPS { get; set; }

        // Used to slow the main Game Loop
        private static Stopwatch loopTimer = new Stopwatch();
		
		public static void Init()
		{
			// Start the timer and determine a starting waitInMilliseconds value !!!INCOMPLETE, STILL NEED TO CODE THIS!!!
			// This method is called inside of the Render.Init() method for now, but will eventually be called at the start of the game loop.
			loopTimer.Start();
			displayFPS = 0;
			waitInMilliseconds = 200; // TEMP VALUE UNTIL CODE IS WRITTEN TO DETERMINE THIS BEFORE THE GAME STARTS.
		}

        public static void MainWait(int targetLoopsPerSecond)
        {
            /* 
             * Used inside of the Render.Draw() Method since it should be the last thing done inside of the Game Loop.
             */
            // Count the loops. This is reset after one second has passed.
            actualLoopsPerSecond++;
            // Slow GameLoop
			//Console.WriteLine("BEFORE WAIT - TIME: {0}, ACTUAL_LOOPS: {1}", loopTimer.ElapsedMilliseconds, actualLoopsPerSecond);
            Thread.Sleep(waitInMilliseconds);
			//Console.WriteLine("AFTER WAIT - TIME: {0}, ACTUAL_LOOPS: {1}", loopTimer.ElapsedMilliseconds, actualLoopsPerSecond);
            // Check stopWatch to if one second has passed yet
            if (loopTimer.ElapsedMilliseconds >= 1000)
            {
				displayFPS = actualLoopsPerSecond;
                // Reset loopTimer
                loopTimer.Reset();
                loopTimer.Start();

                // Adjust refreshRate
				/* Where (w) = waitInMilliseconds , (t) = targetLoopsPerSecond , (a) = actualLoopsPerSecond
				 * TOO SLOW w=w(a/t) Find the percentage diffrence of the (t)arget and (a)ctual then decrease it from the (w)ait time.
				 * TOO FAST w=w/(a/t)) This does the same thing, but instead of decreasing, it increases the (w)ait time, making the loop slower.
				 * 
				 */
				// Loop too fast, must increase the wait time.
                if (actualLoopsPerSecond > targetLoopsPerSecond)
                {
					//Console.WriteLine("TOO FAST - wait{0}, actual {1}, target{2}", waitInMilliseconds, actualLoopsPerSecond, targetLoopsPerSecond);
                    waitInMilliseconds = Convert.ToInt32((double)waitInMilliseconds/((double)actualLoopsPerSecond/(double)targetLoopsPerSecond));
					//Console.WriteLine("WAIT AFTER CONVERSION {0}", waitInMilliseconds);
                }
				// Loop to slow, must lower the wait time.
                else if (actualLoopsPerSecond < targetLoopsPerSecond)
                {
					//Console.WriteLine("TOO SLOW - wait{0}, actual {1}, target{2}", waitInMilliseconds, actualLoopsPerSecond, targetLoopsPerSecond);
					waitInMilliseconds = Convert.ToInt32((double)waitInMilliseconds*((double)actualLoopsPerSecond/(double)targetLoopsPerSecond));
					//Console.WriteLine("WAIT AFTER CONVERSION {0}", waitInMilliseconds);
                }
                actualLoopsPerSecond = 0;
            }
        }
    }
}
