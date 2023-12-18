using Atsui.Models;
using Atsui.Models.Resources;

namespace Atsui.Controllers.DbControllers
{
    public class MockWorldDataController : IWorldDataController
    {
        private List<World> Worlds;

        private void SetUpWorlds()
        {

        }

        public bool AddSwimmer(int swimmerID, int worldID)
        {
            throw new NotImplementedException();
        }

        public bool CreateItem(IItem item, int worldID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int itemID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSwimmer(int swimmerID, int itemID)
        {
            throw new NotImplementedException();
        }

        public List<IResource> GetItems(int worldID)
        {
            throw new NotImplementedException();
        }

        public Swimmer GetOwner(int worldID)
        {
            throw new NotImplementedException();
        }

        public List<Swimmer> GetSwimmers(int worldID)
        {
            throw new NotImplementedException();
        }

        public bool TransferOwnership(int swimmerID, int worldID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(int itemID, int worldID)
        {
            throw new NotImplementedException();
        }

        public int CreateWorld(int creatorSwimmerID)
        {
            return 0;
        }

        public World GetWorld(int worldID, int swimmerID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWorld(int worldID, int swimmerID)
        {
            throw new NotImplementedException();
        }
    }
}
