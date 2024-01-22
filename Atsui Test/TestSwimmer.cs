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
