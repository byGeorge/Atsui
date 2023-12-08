using Atsui.Models.Research;

namespace Atsui.Controllers.DbControllers
{
    public interface IResearchController
    {
        public List<Technology> GetTechnologies();
    }
}
