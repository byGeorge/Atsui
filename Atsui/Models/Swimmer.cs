using Atsui.Controllers.DbControllers;

namespace Atsui.Models
{
    public class Swimmer
    {
        public string Name { get; }
        public string Description { get; set; }
        // single digit Swimmer IDs are reserved for testing
        public int ID { get; }
        public List<World> Worlds { get; }
        public Swimmer(string name, string description, int id)
        {

            Name = name;
            Description = description; 
            ID = id;
            Worlds = new List<World>();
        }
    }
}
