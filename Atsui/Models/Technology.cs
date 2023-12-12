using Atsui.Models.Resources;

namespace Atsui.Models
{
    public class Technology : IItem
    {
        public string Name { get; }
        public string Description { get; }
        public int ID { get; }
        public int ItemType { get; }
        public int OwnerID { get; }
        public bool BeingUsed { get; }
        public bool HasResearched { get; }
        public bool IsArchived { get; }
        public List<Milestone> MilestonesRequired { get; }
        public List<Technology> Parents { get; }
        public int ResearchTime { get; }
        public List<IResource> ResourcesRequired { get; }
        public Technology(string name, string description, int id, bool beingUsed, bool hasResearched, 
            bool isArchived, List<Milestone> milestonesRequired, List<Technology> parents, int researchTime, 
            List<IResource> resourcesRequired)
        {
            Name = name;
            Description = description;
            ID = id;
            ItemType = -1;
            BeingUsed = beingUsed;
            HasResearched = hasResearched;
            IsArchived = isArchived;
            MilestonesRequired = milestonesRequired;
            Parents = parents;
            ResearchTime = researchTime;
            ResourcesRequired = resourcesRequired;
        }

        public bool CanResearch()
        {
            bool canResearch = false;
            return canResearch;
        }
    }
}
