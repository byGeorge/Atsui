namespace Atsui.Models.Resources
{
    public interface IResource
    {
        public string Name { get; }
        public string Description { get; }
        public int Quantity { get; set; }
    }
}
