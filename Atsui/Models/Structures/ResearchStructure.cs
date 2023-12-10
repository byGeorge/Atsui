namespace Atsui.Models.Structures
{
    public class ResearchStructure : IStructure
    {
        public string Name { get; set; }
        public string Description { get; }
        public int ID { get; }
        public int BuildTime { get; }
        public int StorageCapacity { get; private set; }
        public string Type { get; }
        public double WeightCapacity { get; private set; }
        public ResearchStructure(string name, string description, int id, int buildTime, int storageCapacity, 
            double weightCapacity)
        {
            Name = name;
            Description = description;
            ID = id;
            BuildTime = buildTime;
            Type = "Research";
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
