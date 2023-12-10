using Atsui.Models.Resources;

namespace Atsui.Models.Structures
{
    public interface IStructure
    {
        public string Name { get; }
        public string Description { get; }
        public int ID { get; }
        public int BuildTime { get; }
        public int StorageCapacity { get; }
        public string Type { get; }
        public double WeightCapacity { get; }

    }
}
