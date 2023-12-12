using Atsui.Models.Resources;

namespace Atsui.Models.Structures
{
    public interface IStructure
    {
        public IItem Item { get; }
        public int BuildTime { get; }
        public int StorageCapacity { get; }
        public string StructureType { get; }
        public double WeightCapacity { get; }

    }
}
