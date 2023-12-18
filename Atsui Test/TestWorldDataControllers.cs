using Atsui.Controllers.DbControllers;
using Atsui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atsui_Test
{
    public class TestWorldDataControllers
    {
        public IWorldDataController[] worldDataControllers;
        public string[] worldDataControllerNames;
        public Swimmer owner1;
        public Swimmer[] swimmers;
        public MockSwimmerDBController swimmerDBController;

        [SetUp]
        public void Setup()
        {
            worldDataControllers = new IWorldDataController[1] {
                new MockWorldDataController()
            };
            worldDataControllerNames = new string[1] { "MockWorldDataController" };
            swimmerDBController = new MockSwimmerDBController();
            swimmers = new Swimmer[10]
            {
                swimmerDBController.GetSwimmer(0),
                swimmerDBController.GetSwimmer(1),
                swimmerDBController.GetSwimmer(2),
                swimmerDBController.GetSwimmer(3),
                swimmerDBController.GetSwimmer(4),
                swimmerDBController.GetSwimmer(5),
                swimmerDBController.GetSwimmer(6),
                swimmerDBController.GetSwimmer(7),
                swimmerDBController.GetSwimmer(8),
                swimmerDBController.GetSwimmer(9)
            };
        }

        [TearDown]
        public void TearDown() 
        { 
            
        }

        [Test]
        public void CreateWorldReturnsWorldID()
        {
            for (var i = 0; i < worldDataControllers.Length; i++)
            {
                var controller = worldDataControllers[i];
                Assert.That(controller.CreateWorld(0) >= 0, "CreateWorld failed to return a world ID for " + worldDataControllerNames[i]);
            }
        }
    }
}
