using Atsui.Models.Resources;

namespace Atsui.Models
{
    public class Technology
    {
        public string Name { get; }
        public string Description { get; }
        public bool HasResearched { get; }
        public bool IsArchived { get; }
        public bool BeingUsed { get; }
        public int ResearchTime { get; }
        public List<Technology> Parents { get; }
        public List<Milestone> MilestonesRequired { get; }
        public List<IResource> ResourcesRequired { get; }
        public Technology(string name, string description, bool isArchived, bool beingUsed, int researchTime, bool hasResearched,
            List<Technology> parents, List<Milestone> milestonesRequired, List<IResource> resourcesRequired)
        {
            Name = name;
            Description = description;
            HasResearched = hasResearched;
            IsArchived = isArchived;
            BeingUsed = beingUsed;
            ResearchTime = researchTime;
            Parents = parents;
            MilestonesRequired = milestonesRequired;
            ResourcesRequired = resourcesRequired;
        }

        public bool CanResearch()
        {
            bool canResearch = false;
            return canResearch;
        }
    }
}
