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
        ISwimmerDBController[] swimmerDBControllers;
        string[] swimmerControllerNames;
        [SetUp]
        public void SetUp() 
        {
            swimmerDBControllers = new ISwimmerDBController[1]
            {
                new MockSwimmerDBController()
            };
            swimmerControllerNames = new string[1] { "MockSwimmerDBController" };
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
            for (var i = 0; i < swimmerDBControllers.Length; i++)
            {
                Thread.Sleep(1000);
                Swimmer swimmer = new Swimmer("Swim1", "Testing... testing... annnyyybooddddyyyyyy???", 0);
                int startTime = swimmer.StartTime;
                Assert.That(startTime > 0, "Initial GameTime is " + startTime);
                Assert.That(startTime >= 1000 && startTime <= 2000,
                    "Initial GameTime is " + startTime +
                    " and should be between 1000 and 2000 for " + swimmerControllerNames[i]);
            }
        }

        [Test]
        public void TimePlayedIsAccurate()
        {
            for (var i = 0; i < swimmerDBControllers.Length; i++)
            {
                Swimmer swimmer = new Swimmer("Swim1", "Testing... testing... annnyyybooddddyyyyyy???", 0);
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

        [Test]
        public void GetSwimmerReturnsValidSwimmer()
        {
            for (var i = 0; i < swimmerDBControllers.Length; i++)
            {
                Swimmer swim1 = swimmerDBControllers[i].GetSwimmer(0);
                Assert.That(!(swim1 is null), "GetSwimmer returns a null value in " + swimmerControllerNames[i]);
            }
        }

        [Test]
        public void GetSwimmerReturnsCorrectSwimmer()
        {
            for (var i = 0; i < swimmerDBControllers.Length; i++)
            {
                Swimmer swim1 = swimmerDBControllers[i].GetSwimmer(0);
                Assert.That(swim1.ID == 0, "GetSwimmer does not return the correct swimmer in " + swimmerControllerNames[i]);
            }
        }

        [Test]
        public void GetSwimmerWithInvalidIDReturnsNull()
        {
            for (var i = 0; i < swimmerDBControllers.Length; i++)
            {
                Swimmer swim1 = swimmerDBControllers[i].GetSwimmer(-1);
                Assert.That(swim1 is null, "GetSwimmer with id of -1 does not return null " + swimmerControllerNames[i]);
            }
        }
    }
}
