using Atsui.Controllers.DbControllers;
using Atsui.Models.Technology;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atsui_Test
{
    /** Tests Technology class as well as Technologies imported by SwimmerDBControllers **/
    public class TestTechnology
    {
        List<ResearchItem>[] technologies;
        string[] controllers;
        [SetUp]
        public void Setup() {
            technologies = new List<ResearchItem>[1];
            ISwimmerDBController mock = new MockSwimmerDBController();
            technologies[0] = mock.GetTechnologies();
            controllers = new string[1];
            controllers[0] = "MockResearchController";
        }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void TechnologiesReturnsAtLeastOneTechnology()
        {
            for (int i = 0; i < technologies.Length; i++)
            {
                Assert.That(!technologies[i].IsNullOrEmpty(),
                    "No technology found for " + controllers[i]);
            }
        }

        [Test]
        public void SomeTechnologiesHaveParents()
        {
            for (int i = 0; i < technologies.Length; i++)
            {
                bool parentExists = false;
                foreach (ResearchItem tech in technologies[i])
                {
                    if (!tech.Parents.IsNullOrEmpty() && tech.Parents.Count > 0)
                        parentExists = true;
                }
                Assert.That(parentExists, "No parent exists in " + controllers[i]);
            }
        }

        [Test]
        public void EnsureResearchNodesCanBeReached()
        { // checks for orphans and circular research
            for (var i = 0; i < technologies.Length; i++)
            {
                List<ResearchItem> reachableTechnologies = new List<ResearchItem>();
                List<ResearchItem> unreachedTechnologies = technologies[i];
                int lastCount = 0;
                int curCount = 0;

                ResearchItem curItem = unreachedTechnologies[0];
                do
                {
                    //copy list instead of reference
                    List<ResearchItem> curUnreached = unreachedTechnologies.ToList<ResearchItem>();
                    curCount = lastCount;
                    foreach (ResearchItem t in unreachedTechnologies)
                    {
                        curItem = t;
                        // it is the parent technology, and is researchable
                        if (curItem.Parents.IsNullOrEmpty() && reachableTechnologies.Contains(curItem))
                        {
                            reachableTechnologies.Add(curItem);
                            curUnreached.Remove(curItem);
                            lastCount++;
                        }
                        // can all parents be reached?
                        bool allParentsThere = true;
                        foreach(ResearchItem parent in curItem.Parents)
                        {
                            if (!reachableTechnologies.Contains(parent))
                            {
                                allParentsThere = false;
                            }
                        }
                        if (allParentsThere && !reachableTechnologies.Contains(curItem))
                        { // yes they can, and it hasn't been added yet
                            reachableTechnologies.Add(curItem);
                            curUnreached.Remove(curItem);
                            lastCount++;
                        }
                    }
                    // 
                    unreachedTechnologies = curUnreached;
                } while (curCount > lastCount); // we haven't added any more items
                Assert.That(reachableTechnologies.Count == technologies[i].Count,
                    reachableTechnologies.Count + " out of " + technologies[i].Count + " could be added. " + curItem.Name
                    + "was the last item checked" + " in " + controllers[i]);
            }
        }

        [Test]
        public void CanResearchCantResearchMoreThanOnce()
        {
            for (var i = 0; i < technologies.Length; i++)
            {
                foreach (ResearchItem tech in technologies[i])
                {
                    if (tech.CanResearch())
                    {
                        Assert.That(!tech.HasResearched, "Technology " + tech.Name + " in " + controllers[i] + " has already been researched");
                    }
                }
            }
        }

        [Test]
        public void CanResearchParentsAreResearchedFirst()
        {
            for (var i = 0; i < technologies.Length; i++)
            {
                foreach (ResearchItem tech in technologies[i])
                {
                    if (tech.CanResearch())
                    {
                        foreach(ResearchItem parent in tech.Parents)
                        {
                            Assert.That(parent.HasResearched, "Technology " + tech.Name + " in " + controllers[i] + " has an unresearched parent, " +
                                "but claims to be researchable.");
                        }
                    }
                }
            }
        }

        // only mock db required, testing functionality of technologycontroller and researchtimer
        [Test]
        public void ResearchStarts()
        {
            ResearchItem researchable = null;
            for (var i = 0; i < technologies[0].Count; i++)
            {
                if (technologies[0][i].CanResearch())
                {
                    researchable = technologies[0][i];
                    break;
                }
            }
            ResearchTimer timer = new ResearchTimer(researchable);
            timer.Start();
            Assert.That(timer.GetStatus() == "Running" || timer.GetStatus() == "Complete", 
                "Research should be running or already completed, but was " + timer.GetStatus());
        }

        [Test]
        public void ResearchCompletes()
        {
            ResearchItem researchable = null;
            for (var i = 0; i < technologies[0].Count; i++)
            {
                if (technologies[0][i].CanResearch())
                {
                    researchable = technologies[0][i];
                    break;
                }
            }
            ResearchTimer timer = new ResearchTimer(researchable);
            timer.Start();
            Thread.Sleep(researchable.ResearchTime);
            Assert.That(timer.GetStatus() == "Complete", "Research should be completed, but was " + timer.GetStatus());
        }

        [Test]
        public void ResearchDoesNotInstantlyComplete()
        {
            ResearchItem researchable = null;
            for (var i = 0; i < technologies[0].Count; i++)
            {
                if (technologies[0][i].CanResearch())
                {
                    researchable = technologies[0][i];
                    break;
                }
            }
            ResearchTimer timer = new ResearchTimer(researchable);
            timer.Start();
            Assert.That(timer.GetStatus() != "Complete", "Research should not complete instantly");
        }

        [Test]
        public void GetPercentageCompleteReportsAccurately()
        {
            ResearchItem researchable = null;
            for (var i = 0; i < technologies[0].Count; i++)
            {
                if (technologies[0][i].CanResearch())
                {
                    researchable = technologies[0][i];
                    break;
                }
            }
            ResearchTimer timer = new ResearchTimer(researchable);
            double percent = timer.GetPercentageComplete();
            Assert.That(percent == 0, "Research should be at 0%, but is " + percent);
            timer.Start();
            Thread.Sleep(researchable.ResearchTime / 2);
            percent = timer.GetPercentageComplete();
            Assert.That(percent >= 49 && percent <= 51, "Research should be at around 50%, but is " + percent + "% of " + researchable.ResearchTime + " ms");
            Thread.Sleep(researchable.ResearchTime / 2);
            percent = timer.GetPercentageComplete();
            Assert.That(percent == 100, "Research should be at 100%, but is " + percent);
        }
    }
}
