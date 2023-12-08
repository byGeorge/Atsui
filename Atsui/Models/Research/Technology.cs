namespace Atsui.Models.Research
{
    public class Technology
    {
        public string Name { get; }
        public string Description { get; }
        public bool CanResearch { get; }
        public bool HasResearched { get; }
        public bool IsArchived { get; }
        public bool BeingUsed { get; }
        public int ResearchTime { get; }
        public List<Technology> Parents { get; }
        public Technology(string name, string description, bool isArchived, bool beingUsed, int researchTime, bool hasResearched, 
            List<Technology> parents)
        {
            Name = name;
            Description = description;
            CanResearch = canResearch;
            HasResearched = hasResearched;
            IsArchived = isArchived;
            BeingUsed = beingUsed;
            ResearchTime = researchTime;
            Parents = parents;
        }
    }
}
