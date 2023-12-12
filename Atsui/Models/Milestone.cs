namespace Atsui.Models
{
    public class Milestone
    {
        public IItem Item { get; }
        public bool HasAchieved { get; set; }
        public Milestone(IItem item, bool hasAchieved)
        {
            Item = item;
            HasAchieved = hasAchieved;

        }
    }
}
