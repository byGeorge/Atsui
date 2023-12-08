namespace Atsui.Models
{
    public class Milestone
    {
        public string Name { get; }
        public string Description { get; }
        public bool HasAchieved { get; set; }
        public Milestone(string name, string description, bool hasAchieved)
        {
            Name = name;
            Description = description;
            HasAchieved = hasAchieved;

        }
    }
}
