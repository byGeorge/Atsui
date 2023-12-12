using Atsui.Models;

namespace Atsui.Controllers.DbControllers
{
    public interface ISwimmerDBController
    {
        public List<Technology> GetTechnologies();
        public int GetID();
    }
}
