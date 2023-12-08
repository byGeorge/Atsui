namespace Atsui.Models
{
    public class Swimmer
    {
        public string Name { get; }
        public int StartTime { get; }
        public List<World> Worlds { get; }
        public Swimmer(string name)
        {

            Name = name;
            StartTime = GameLoop.GetGameTimeElapsed();
            Worlds = new List<World>();
        }

        public int GetTimePlayed()
        {
            return GameLoop.GetGameTimeElapsed() - StartTime;
        }
    }
}
