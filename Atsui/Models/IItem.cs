namespace Atsui.Models
{
    public interface IItem
    {
        public string Name { get; }
        public string Description { get; }
        public int ID { get; }
        public int ItemType { get; }
        public int OwnerID { get; }
    }
}
