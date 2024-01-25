using Atsui.Models.Resources;

namespace Atsui.Models.Technology
{
    public class ResearchItem : IItem
    {
        public string Name { get; }
        public string Description { get; }
        public int ID { get; }
        public int ItemType { get; }
        public int OwnerID { get; }
        public bool BeingUsed { get; set; }
        public bool HasResearched { get; set; }
        public bool IsArchived { get; set; }
        public bool IsResearching { get; set; }
        public List<Milestone> MilestonesRequired { get; }
        public List<ResearchItem> Parents { get; }
        public int ResearchTime { get; } // Milliseconds
        public List<IResource> ResourcesRequired { get; }
        public ResearchItem(string name, string description, int id, bool beingUsed, bool hasResearched,
            bool isArchived, bool isResearching, List<Milestone> milestonesRequired, List<ResearchItem> parents, int researchTime,
            List<IResource> resourcesRequired)
        {
            Name = name;
            Description = description;
            ID = id;
            ItemType = -1;
            BeingUsed = beingUsed;
            HasResearched = hasResearched;
            IsArchived = isArchived;
            IsResearching = isResearching;
            MilestonesRequired = milestonesRequired;
            Parents = parents;
            ResearchTime = researchTime;
            ResourcesRequired = resourcesRequired;
        }

        public bool CanResearch()
        {
            bool canResearch = true;
            // no reinventing the wheel here
            if (HasResearched)
                canResearch = false;
            foreach (ResearchItem parent in Parents)
            {
                if (!parent.HasResearched)
                    canResearch = false;
            }
            return canResearch;
        }
    }
}
