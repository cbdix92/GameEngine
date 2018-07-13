using System;
using System.Threading;
using System.Diagnostics;

namespace GameEngine
{

    public static class Updates
    {

        // Wait method Variables
        public static int deltaTime = 100;
        private static int lastUpdate = 0;
        private static long currentTime = 0;
        private static int fpsCounter;

        private static int frameCap;
        public static int FrameCap
        {
            get { return frameCap; }
            set { frameCap = 1000 / value; }
        }

        // Stat outputs
        public static int statFPS;
        public static int statDeltaTime;
        public static int statMainLoop; // Deprecated. Do not use.

        // Stopwatch instances
        private static Stopwatch loopTimer = new Stopwatch();
        private static Stopwatch statTimer = new Stopwatch();
		
		public static void Init()
		{
			loopTimer.Start();
            statTimer.Start();
		}
        public static void Wait() // Better alternative to LoopController.
        {
            /*
             * Where F = FrameCap, C = currentTime, L = lastUpdate, W = The wait time that is passed into Thread.Sleep(W)
             * W = F-(C-L) (W) is the remainder of time needed to spend on the current loop before proceeding to the next one, in order to remain under the frameCap.
             */
            
            fpsCounter++;

            currentTime = loopTimer.ElapsedMilliseconds;

            deltaTime = Math.Abs(FrameCap - ((int)currentTime - lastUpdate));

            statDeltaTime = deltaTime;

            Thread.Sleep(deltaTime);

            if (loopTimer.ElapsedMilliseconds > 600000) // Reset the Clock every 10 minutes
            {
                loopTimer.Reset();
                loopTimer.Start();
            }

            lastUpdate = (int)loopTimer.ElapsedMilliseconds;

            // Update the stats
            if (statTimer.ElapsedMilliseconds > 1000)
            {
                // Update the stats every second then reset the timer and the counter variables.
                statFPS = fpsCounter;
                fpsCounter = 0;
                statTimer.Reset();
                statTimer.Start();
            }


        }

        /*public static void LoopController() // Deprecated. Do not use.
        {
               //
              // Limit the speed of th main game loop to only update equal to @mainLoopCap per second.
             //
            // Count the loops. This is reset after one second has passed.
            actualLoopsPerSecond++;
            // Slow GameLoop
			//Console.WriteLine("BEFORE WAIT - TIME: {0}, ACTUAL_LOOPS: {1}", loopTimer.ElapsedMilliseconds, actualLoopsPerSecond);
            Thread.Sleep(deltaTime);
			//Console.WriteLine("AFTER WAIT - TIME: {0}, ACTUAL_LOOPS: {1}", loopTimer.ElapsedMilliseconds, actualLoopsPerSecond);
            // Check stopWatch to if one second has passed yet
            if (loopTimer.ElapsedMilliseconds >= 1000)
            {
                // Update the screen stats
                statMainLoop = actualLoopsPerSecond;

                // Reset loopTimer
                loopTimer.Reset();
                loopTimer.Start();

                // Adjust refreshRate
				// Where (w) = waitInMilliseconds , (m) = mainLoopCap , (a) = actualLoopsPerSecond
			    // TOO SLOW w=w(a/m) Find the percentage difference of the (m)ainLoopCap and (a)ctual then decrease it from the (w)ait time.
				// TOO FAST w=w/(a/m)) This does the same thing, but instead of decreasing, it increases the (w)ait time, making the loop slower.
			    // 
				//
				// Loop too fast, must increase the wait time.
                if (actualLoopsPerSecond > mainLoopCap)
                {
					//Console.WriteLine("TOO FAST - wait{0}, actual {1}, mainLoopCap{2}", waitInMilliseconds, actualLoopsPerSecond, mainLoopCap);
                    deltaTime = Convert.ToInt32((double)deltaTime/((double)actualLoopsPerSecond/(double)mainLoopCap));
					//Console.WriteLine("WAIT AFTER CONVERSION {0}", waitInMilliseconds);
                }
				// Loop to slow, must lower the wait time.
                else if (actualLoopsPerSecond < mainLoopCap)
                {
					//Console.WriteLine("TOO SLOW - wait{0}, actual {1}, mainLoopCap{2}", waitInMilliseconds, actualLoopsPerSecond, mainLoopCap);
					deltaTime = Convert.ToInt32((double)deltaTime*((double)actualLoopsPerSecond/(double)mainLoopCap));
					//Console.WriteLine("WAIT AFTER CONVERSION {0}", waitInMilliseconds);
                }
                actualLoopsPerSecond = 0;
            }
            if (statTimer.ElapsedMilliseconds > 1000)
            {
                // Update the stats every second then reset the timer and the counter variables.
                statFPS = fpsCounter;
                fpsCounter = 0;
                statTimer.Reset();
                statTimer.Start();
            }
        }*/
    }
}
