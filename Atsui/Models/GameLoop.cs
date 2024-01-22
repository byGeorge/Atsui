namespace Atsui.Models
{
    public static class GameLoop
    {
        private static TimeSpan _totalGameTime;
        private static TimeSpan _runningTime;
        private static TimeSpan _loopTime = new TimeSpan(0,0,0,0,6);
        // States: 0 = stopped, 1 = running, 2 = starting, 3 = stopping, 4 = never started, 5 = paused
        public static int state = 4;

        private static async void gameLoop()
        {
            do
            {
                if (state == 2)// starting
                {
                    state = 1;
                }
                if (state == 5)
                {
                    do
                    {
                        await Task.Delay(_loopTime);
                        _totalGameTime = _totalGameTime + _loopTime;
                    } while (state == 5) ;
                }
                while (state == 1)// running
                {
                    DateTime loopStart = DateTime.UtcNow;
                    Update();
                    Render();
                    TimeSpan elapsed = DateTime.UtcNow - loopStart;
                    TimeSpan waitTime = _loopTime - elapsed;
                    if (waitTime < TimeSpan.Zero)
                        waitTime = TimeSpan.Zero;
                    await Task.Delay(waitTime + _loopTime);
                    _totalGameTime = _totalGameTime + _loopTime;
                    _runningTime = _runningTime + _loopTime;
                }
                if (state == 3) // stopping
                {
                    state = 0; // stopped
                }
            } while (state != 0);
        }

        public static TimeSpan GetTotalGameTime()
        {
            return _totalGameTime;
        }

        public static TimeSpan GetTotalRunningTime()
        {
            return _runningTime;
        }

        public static String GetState()
        {
            switch (state)
            {
                case 0:
                    return "Stopped";

                case 1:
                    return "Running";

                case 2:
                    return "Starting";

                case 3:
                    return "Stopping";

                case 4:
                    return "Never Started";

                case 5:
                    return "Paused";

                default:
                    return "Error";
            }
        }

        public static void Load()
        {

        }

        public static bool Pause()
        {
            state = 5;
            return true;
        }

        public static void Render()
        {
            //Update the UI
            /** crickets **/
        }

        public static bool Resume()
        {
            state = 1;
            return true;
        }

        public static bool Start()
        {
            state = 2;
            // TODO: startup code goes here
            _totalGameTime = new TimeSpan();
            _runningTime= new TimeSpan();
            Load();
            gameLoop();
            return true;
        }

        public static bool Stop()
        {
            state = 3;
            //TODO: teardown code goes here
            Unload();
            //TODO: close connections here
            return state == 0;
        }

        public static void Unload()
        {
            // wait for loop to finish
            Thread.Sleep(_loopTime * 4);
            // TODO: async teardown code goes here
        }

        public static void Update()
        {
            // Update the game state here. 
            /** crickets**/
        }
    }
}
