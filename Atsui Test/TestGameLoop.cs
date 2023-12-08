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
            int t1 = GameLoop.GetGameTimeElapsed();
            Thread.Sleep(1000);
            int t2 = GameLoop.GetGameTimeElapsed();
            Assert.That(t1 < t2, "Game time has not passed: " + t1 + " is not less than " + t2);
        }

        [Test]
        public void GameLoopPauses()
        {
            GameLoop.Start();
            Assert.That(GameLoop.Pause(), "Pause() did not return true");
            Thread.Sleep(1000);
            int t1 = GameLoop.GetGameTimeElapsed();
            Thread.Sleep(1000);
            int t2 = GameLoop.GetGameTimeElapsed();
            Assert.That(t1 == t2, "Game has not paused, " + t1 + " does not equal " + t2);
        }

        [Test]
        public void GameLoopResumes()
        {
            GameLoop.Start();
            GameLoop.Pause();
            Thread.Sleep(1000);
            int t1 = GameLoop.GetGameTimeElapsed();
            Assert.That(GameLoop.Resume(), "Resume() did not return true");
            Thread.Sleep(1000);
            int t2 = GameLoop.GetGameTimeElapsed();
            Assert.That(t1 < t2, "Game has not resumed " + t1 + " is not less than " + t2);
        }
    }
}