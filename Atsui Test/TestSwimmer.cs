using Atsui.Controllers.DbControllers;
using Atsui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atsui_Test
{
    internal class TestSwimmer
    {
        [SetUp]
        public void SetUp() 
        {
            GameLoop.Start();
        }
        [TearDown] 
        public void TearDown() 
        {
            GameLoop.Stop();
        }

        [Test]
        public void InitialGameTimeIsAccurate()
        {
            Thread.Sleep(1000);
            Swimmer swimmer = new Swimmer("Swim1", "Testing... testing... annnyyybooddddyyyyyy???", new MockSwimmerDBController());
            int startTime = swimmer.StartTime;
            Assert.That(startTime > 0, "Initial GameTime is " + startTime);
            Assert.That(startTime >= 1000 && startTime <= 2000, 
                "Initial GameTime is " + startTime +
                " and should be between 1000 and 2000");
        }

        [Test]
        public void TimePlayedIsAccurate()
        {
            Swimmer swimmer = new Swimmer("Swim1", "Testing... testing... annnyyybooddddyyyyyy???", new MockSwimmerDBController());
            int startTime = swimmer.StartTime;
            Thread.Sleep(1000);
            int played = swimmer.GetTimePlayed();
            Assert.That((GameLoop.GetGameTimeElapsed() - startTime) >= played,
                "Time played is " + played + ". Start time: " + startTime +
                "GameTime should continue counting after Swimmer creation");
            Thread.Sleep(1000);
            int timePassed = GameLoop.GetGameTimeElapsed() - played;
            Assert.That(timePassed > 0,
                "GameTime should continue counting. Time passed: " + timePassed);
            Assert.That(timePassed >= 1000 && timePassed <= 2000,
                "Time Passed should be between 1000 and 2000 ms.");
            Console.WriteLine("Test TimePlayedIsAccurate time passed: " + timePassed);
        }
    }
}
