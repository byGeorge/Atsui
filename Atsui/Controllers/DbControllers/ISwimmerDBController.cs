using Atsui.Models;

namespace Atsui.Controllers.DbControllers
{
    public interface ISwimmerDBController
    {
        public Swimmer GetSwimmer(int id);
        public int CreateSwimmer(Swimmer swimmer);
        public bool DeleteSwimmer(int id);
        public List<Technology> GetTechnologies();
    }
}
