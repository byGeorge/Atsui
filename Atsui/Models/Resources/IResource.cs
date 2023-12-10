namespace Atsui.Models.Resources
{
    public interface IResource
    {
        public string Name { get; }
        public string Description { get; }
        //Key: LocationId, Value: quantity
        public Dictionary<int, int> LocationId { get; set; }
        // i.e. "Liquid" "Personnel" "Adult" "Livestock" etc
        public List<string> Qualities { get; }
        public int Quantity { get; set; }
        public double WeightPerUnit { get; }
    }
}
