using Atsui.Models;

namespace Atsui_Test
{
    public class TestGameLoop
    {

        public static async Task<string> CheckLoopStatus()
        {
            await Task.Delay(1000);
            return GameLoop.GetState();
        }


        [SetUp]
        public void Setup()
        {
        }

        [TearDown] 
        public void TearDown()
        {
            GameLoop.Stop();
        }

        [Test]
        public async Task GameLoopStartsGame()
        {
            Assert.That(GameLoop.Start(), "GameLoop.Start() returns false");
            string state = GameLoop.GetState();
            Assert.That(state == "Starting" || state == "Running", 
                "State is " + state + ", not Starting or Running");
            state = await CheckLoopStatus();
            Assert.That(state == "Running", "Loop never runs");
        }

        [Test]
        public async Task GameLoopEndsGame()
        {
            Assert.That(GameLoop.Start(), "GameLoop.Start() returns false");
            Assert.That(GameLoop.Stop(), "GameLoop.Stop() returns false");
            string state = GameLoop.GetState();
            Assert.That(state == "Stopping" || state == "Stopped",
                "State is " + state + ",  not Stopping or Stopped");
            state = await CheckLoopStatus();
            Assert.That(state == "Stopped", "Loop never stops");
        }

        [Test]
        public void GameTimeElapses()
        {
            GameLoop.Start();
            TimeSpan t1 = GameLoop.GetTotalGameTime();
            Thread.Sleep(1000);
            TimeSpan t2 = GameLoop.GetTotalGameTime();
            Assert.That(t1 < t2, "Game time has not passed: " + t1 + " is not less than " + t2);
        }

        [Test]
        public void RunningTimeInitiallyMatchesGameTime()
        {
            GameLoop.Start();
            Thread.Sleep(1000);
            TimeSpan totalTime = GameLoop.GetTotalGameTime();
            TimeSpan runningTime = GameLoop.GetTotalRunningTime();
            Assert.That(totalTime == runningTime, "Total time should match running time. " + totalTime.Milliseconds + " is not " + runningTime.Milliseconds);
        }

        [Test]
        public void GameLoopPauses()
        {
            GameLoop.Start();
            Assert.That(GameLoop.Pause(), "Pause() did not return true");
            Thread.Sleep(1000);
            TimeSpan t1 = GameLoop.GetTotalRunningTime();
            Thread.Sleep(1000);
            TimeSpan t2 = GameLoop.GetTotalRunningTime();
            Assert.That(t1 == t2, "Game has not paused, " + t1.Milliseconds + " does not equal " + t2.Milliseconds);
        }

        [Test]
        public void GameLoopResumes()
        {
            GameLoop.Start();
            GameLoop.Pause();
            Thread.Sleep(1000);
            TimeSpan t1 = GameLoop.GetTotalRunningTime();
            Assert.That(GameLoop.Resume(), "Resume() did not return true");
            Thread.Sleep(1000);
            TimeSpan t2 = GameLoop.GetTotalRunningTime();
            Assert.That(t1 < t2, "Game has not resumed " + t1.Milliseconds + " is not less than " + t2.Milliseconds);
        }

        [Test]
        public void TotalGameTimeRunsWhenPaused()
        {
            GameLoop.Start();
            GameLoop.Pause();
            Thread.Sleep(1000);
            TimeSpan totalTime = GameLoop.GetTotalGameTime();
            TimeSpan runningTime = GameLoop.GetTotalRunningTime();
            Assert.That(totalTime > runningTime, 
                "Total time should be grater than running time. Total: " + totalTime.Milliseconds + ", Running: " + runningTime.Milliseconds);
        }
    }
}