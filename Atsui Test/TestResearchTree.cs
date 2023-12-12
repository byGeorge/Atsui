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
    public class TestResearchTree
    {
        List<Technology>[] technologies;
        string[] controllers;
        [SetUp] 
        public void Setup() {
            technologies = new List<Technology>[1];
            ISwimmerDBController mock = new MockDBController();
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
                foreach(Technology tech in technologies[i])
                {
                    if (!tech.Parents.IsNullOrEmpty() && tech.Parents.Count > 0)
                        parentExists = true;
                }
                Assert.That(parentExists, "No parent exists in " + controllers[i]);
            }
        }

        //helper function
        private bool checkTree(List<Technology> parents, Technology curTech)
        {
            if (curTech.Parents.IsNullOrEmpty())
            {
                return true;
            }
            else if (parents.Contains(curTech))
            {
                return false;
            }
            else
            {
                parents.Add(curTech);
                foreach(Technology tech in curTech.Parents)
                {
                    return checkTree(parents, tech);
                }
            }
            return false; // this is only here to make the code compile.
        }
        [Test]
        public void EnsureResearchIsNotCircular()
        {
            for (var i = 0; i < technologies.Length; i++)
            {
                foreach(Technology tech in technologies[i])
                {
                    Assert.That(checkTree(new List<Technology>(), tech), 
                        "Circular research reference found in " + controllers[i] + "for " + tech.Name);
                }
            }
        }

        [Test]
        public void CanResearchChecksRequirements()
        {
            for (var i = 0; i < technologies.Length; i++)
            {
                foreach(Technology tech in technologies[i])
                {
                    if (tech.CanResearch())
                    {
                        //parent technology must be researched before child technologies
                        foreach(Technology parent in tech.Parents)
                        {
                            Assert.That(parent.HasResearched, "Technology " + tech.Name + " has an " +
                                "unresearched parent");
                        }
                        // prerequisite milestones must also be achieved
                        foreach(Milestone milestone in tech.MilestonesRequired)
                        {
                            Assert.That(milestone.HasAchieved, "Technology " + tech.Name + " has an " +
                                "unresearched milestone");
                        }
                    }
                    else
                    {
                        // one of the prerequisites should not be met
                        bool meetsRequiremets = true;
                        foreach (Technology parent in tech.Parents)
                        {
                            if (!parent.HasResearched)
                            {
                                meetsRequiremets = false;
                            }
                        }

                        foreach (Milestone milestone in tech.MilestonesRequired)
                        {
                            if (!milestone.HasAchieved)
                            {
                                meetsRequiremets = false;
                            }
                        }

                        Assert.That(!meetsRequiremets, "Technology " + tech.Name + " meets requirements " +
                            "but cannot be researched");
                    }
                }
            }
        }
    }
}
