using System.Diagnostics;

namespace Atsui.Models.Technology
{
    public class ResearchTimer
    {
        public ResearchItem Item { get; set; }
        private int Status; // 0 Not started, 1 Running, 2 Complete, 3 Stopped
        private static int _tickDelay = 10; 
        private Stopwatch _timer { get; set; }
        public ResearchTimer(ResearchItem item)
        {
            Item = item;
            _timer = new Stopwatch();
            Status = 0;
        }

        public void Start()
        {
            Status = 1;
            _timer.Start();
            Run();
        }

        internal void Stop() { 
            _timer.Stop();
            if (_timer.ElapsedMilliseconds >= Item.ResearchTime)
            {
                Status = 2;
                Item.HasResearched = true;
            }
            else
            {
                Status = 3;
            }
        }

        public double GetPercentageComplete()
        {
            if (_timer.ElapsedMilliseconds == 0)
                return 0;
            else if (_timer.ElapsedMilliseconds <= Item.ResearchTime)
            {
                return (_timer.ElapsedMilliseconds * 100) / Item.ResearchTime;
            }
            else
                return 100;
        }

        private async void Run()
        {
            do
            {
                await Task.Delay(_tickDelay);

            } while (_timer.ElapsedMilliseconds <= Item.ResearchTime);
            Item.HasResearched = true;
            Stop();
        }

        public string GetStatus()
        {
            switch (Status)
            {
                case 0:
                    return "Not started";
                case 1:
                    return "Running";
                case 2:
                    return "Complete";
                case 3:
                    return "Stopped";
                default:
                    return "Error";
            }

        }
    }
}
