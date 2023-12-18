using Atsui.Models;
using Atsui.Models.Resources;
using Humanizer.Localisation;

namespace Atsui.Controllers.DbControllers
{
    public interface IWorldDataController
    {
        // single digit world IDs are reserved for testing
        public int CreateWorld(int creatorSwimmerID);
        public World GetWorld(int worldID, int swimmerID);
        public bool DeleteWorld(int worldID, int swimmerID);
        public List<IResource> GetItems(int worldID);
        public bool CreateItem(IItem item, int worldID);
        public bool UpdateItem(int itemID, int worldID);
        public bool DeleteItem(int itemID);
        public List<Swimmer> GetSwimmers(int worldID);
        // adds and deletes swimmers from world
        public bool AddSwimmer(int swimmerID, int worldID);
        public bool DeleteSwimmer(int swimmerID, int itemID);
        public Swimmer GetOwner(int worldID);
        public bool TransferOwnership(int swimmerID, int worldID);
    }
}
