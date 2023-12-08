namespace Atsui.Models
{
    public static class GameLoop
    {
        // States: 0 = stopped, 1 = running, 2 = starting, 3 = stopping, 4 = never started, 5 = paused
        public static int state = 4;
        private static int _loopTime = 6;
        private static int _gameTimeElapsed = 0;

        public static bool Start()
        {
            state = 2;
            // TODO: startup code goes here
            gameLoop();
            return true;
        }

        public static bool Pause()
        {
            state = 5;
            return true;
        }

        public static bool Resume()
        {
            state = 1;
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

        private static async void gameLoop()
        {
            do
            {
                if (state == 2)// starting
                {
                    state = 1;
                }
                while (state == 1)// running
                {
                    await Task.Delay(_loopTime);
                    _gameTimeElapsed += _loopTime;
                }
                if (state == 3) // stopping
                {
                    state = 0; // stopped
                }
            } while(state != 0);
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

        public static int GetGameTimeElapsed()
        {
            return _gameTimeElapsed;
        }
    }
}
