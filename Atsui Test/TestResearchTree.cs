using Atsui.Controllers.DbControllers;
using Atsui.Models;
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
    public class TestResearchTree
    {
        List<Technology>[] technologies;
        string[] controllers;
        [SetUp]
        public void Setup() {
            technologies = new List<Technology>[1];
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
                foreach (Technology tech in technologies[i])
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
                List<Technology> reachableTechnologies = new List<Technology>();
                List<Technology> unreachedTechnologies = technologies[i];
                int lastCount = 0;
                int curCount = 0;

                Technology curItem = unreachedTechnologies[0];
                do
                {
                    //copy list instead of reference
                    List<Technology> curUnreached = unreachedTechnologies.ToList<Technology>();
                    curCount = lastCount;
                    foreach (Technology t in unreachedTechnologies)
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
                        foreach(Technology parent in curItem.Parents)
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
                foreach (Technology tech in technologies[i])
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
                foreach (Technology tech in technologies[i])
                {
                    if (tech.CanResearch())
                    {
                        foreach(Technology parent in tech.Parents)
                        {
                            Assert.That(parent.HasResearched, "Technology " + tech.Name + " in " + controllers[i] + " has an unresearched parent, " +
                                "but claims to be researchable.");
                        }
                    }
                }
            }
        }
    }
}
