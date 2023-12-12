namespace Atsui.Models.Resources
{
    public interface IResource
    {
        public IItem Item { get; set; }
        //Key: LocationId (foreign key), Value: quantity
        public Dictionary<int, int> LocationId { get; set; }
        // i.e. "Liquid" "Personnel" "Adult" "Livestock" etc
        public List<string> Qualities { get; }
        public int Quantity { get; set; }
        public double WeightPerUnit { get; }
    }
}
