namespace Atsui.Models.Structures
{
    public class ResearchStructure : IStructure
    {
        public IItem Item { get; }
        public string ItemType { get; }
        public int BuildTime { get; }
        public int StorageCapacity { get; private set; }
        public string StructureType { get; }
        public double WeightCapacity { get; private set; }
        public ResearchStructure(IItem item, int buildTime, int storageCapacity, 
            double weightCapacity)
        {
            Item = item;
            ItemType = "Structure";
            BuildTime = buildTime;
            StructureType = "Research";
            StorageCapacity = storageCapacity;
            WeightCapacity = weightCapacity;
        }

        public double GetEfficiencyMultiplyer()
        {
            return -1;
        }

        public bool Upgrade()
        {
            return false;
        }
    }
}
