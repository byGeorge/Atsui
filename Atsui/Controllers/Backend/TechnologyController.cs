using Atsui.Models.Technology;

namespace Atsui.Controllers.Backend
{
    public class TechnologyController
    {
        private ResearchTimer[] _researchQueue;
        private int _currentResearch;
        public TechnologyController()
        {
            _researchQueue = new ResearchTimer[5];
            _currentResearch = 0;
        }
        public bool AddResearchToQueue(ResearchItem researchItem)
        {
            ResearchTimer timer = new ResearchTimer(researchItem);
            _researchQueue[0] = timer;
            timer.Start();
            return true;
        }

        public ResearchTimer GetCurrentResearch()
        {
            return _researchQueue[_currentResearch];
        }

        public void RemoveResearchFromQueue()
        {

        }
    }
}
