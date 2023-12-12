namespace Atsui.Models
{
    public interface IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; }
        public int ItemType { get; }
    }
}
