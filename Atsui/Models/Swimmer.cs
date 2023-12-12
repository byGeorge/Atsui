using Atsui.Controllers.DbControllers;

namespace Atsui.Models
{
    public class Swimmer
    {
        public string Name { get; }
        public string Description { get; set; }
        public int ID { get; }
        public ISwimmerDBController DBController { get; }
        public int StartTime { get; }
        public List<World> Worlds { get; }
        public Swimmer(string name, string description, ISwimmerDBController dBController)
        {

            Name = name;
            Description = description; 
            ID = dBController.GetID();
            DBController = dBController;
            StartTime = GameLoop.GetGameTimeElapsed();
            Worlds = new List<World>();
        }

        public int GetTimePlayed()
        {
            return GameLoop.GetGameTimeElapsed() - StartTime;
        }
    }
}
