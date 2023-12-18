using Atsui.Models.Resources;

namespace Atsui.Models
{
    public class World
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; }
        public List<Swimmer> Swimmers { get; set; }
        public List<IItem> Items { get; set; }
        public World(string name, string description, int id, List<Swimmer> swimmers, List<IItem> items)
        {
            Name = name;
            Description = description;
            ID = id;
            Swimmers = swimmers;
            Items = items;
        }
    }
}
