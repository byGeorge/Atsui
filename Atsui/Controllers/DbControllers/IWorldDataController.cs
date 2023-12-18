using Atsui.Models;
using Atsui.Models.Resources;
using Humanizer.Localisation;

namespace Atsui.Controllers.DbControllers
{
    public interface IWorldDataController
    {
        public List<IResource> GetItems(int worldID);
        public bool CreateItem(IItem item, int worldID);
        public bool UpdateItem(int itemID, int worldID);
        public bool DeleteItem(int itemID);
        public List<Swimmer> GetSwimmers(int worldID);
        public bool AddSwimmer(int swimmerID, int worldID);
        public bool DeleteSwimmer(int swimmerID, int itemID);
    }
}
