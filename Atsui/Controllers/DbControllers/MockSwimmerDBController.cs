using Atsui.Models;
using Atsui.Models.Resources;
using Atsui.Models.Technology;
using Humanizer.Localisation;

namespace Atsui.Controllers.DbControllers
{
    public class MockSwimmerDBController : ISwimmerDBController
    {
        private List<Swimmer> swimmers;
        public MockSwimmerDBController() {
            swimmers = new List<Swimmer>()
            {
                new Swimmer("Testy 1", "Test swimmer 0", 0),
                new Swimmer("Testy 2", "Test swimmer 1", 1),
                new Swimmer("Testy 3", "Test swimmer 2", 2),
                new Swimmer("Testy 4", "Test swimmer 3", 3),
                new Swimmer("Testy 5", "Test swimmer 4", 4),
                new Swimmer("Testy 6", "Test swimmer 5", 5),
                new Swimmer("Testy 7", "Test swimmer 6", 6),
                new Swimmer("Testy 8", "Test swimmer 7", 7),
                new Swimmer("Testy 9", "Test swimmer 8", 8)
            };
        }

        public int CreateSwimmer(Swimmer swimmer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSwimmer(int id)
        {
            throw new NotImplementedException();
        }

        public Swimmer GetSwimmer(int id)
        {
            foreach(Swimmer swimmer in  swimmers)
            {
                if (swimmer.ID == id)
                {
                    return swimmer;
                }
            }
            // not found, return null
            return null;
        }

        public List<ResearchItem> GetTechnologies()
        {
            // well-behaved code for mock development
            ResearchItem one = new ResearchItem("one", "Is it a lonely number because it's" +
                "unimaginative?", 1, true, true, true, false, new List<Milestone>(), new List<ResearchItem>(),
                10000, new List<IResource>());
            ResearchItem two = new ResearchItem("two", "The Twoth fairy is less horrifying " +
                "than the threeth fairy",1, false, false, false, false, new List<Milestone>(),
                new List<ResearchItem>(), 1000, new List<IResource>());
            ResearchItem three = new ResearchItem("three", "Beware. BEWAAAARE!", 3, true,
                false, false, false, new List<Milestone>(), new List<ResearchItem>(), 10, new List<IResource>());
            ResearchItem four = new ResearchItem("four", "We Go! by Hiroshi Kitadani is " +
                "adorable.", 4, false, false, false, false, new List<Milestone>(),
                new List<ResearchItem>(), 1000, new List<IResource>());
            ResearchItem five = new ResearchItem("five", "Even Eris would acknowledge that five " +
                "is just another number.", 5, false, false, false, false, new List<Milestone>(),
                new List<ResearchItem>(), 1000, new List<IResource>());
            ResearchItem six = new ResearchItem("six", "Still just a number, even when repeated " +
                "thrice.", 6, false, false, true, false, new List<Milestone>(), new List<ResearchItem>(), 1000, 
                new List<IResource>());
            ResearchItem seven = new ResearchItem("seven", "Calling them deadly sins seems a bit " +
                "overkill, if you ask me.", 7, true, false, false, false, new List<Milestone>(),
                new List<ResearchItem>(), 1000, new List<IResource>());
            ResearchItem eight = new ResearchItem("eight", "If you figure out how to fold a path " +
                "this many times, you may receive enlightenment", 8, true, false, false, false,
                new List<Milestone>(), new List<ResearchItem>(), 1000, new List<IResource>());
            ResearchItem nine = new ResearchItem("nine", "This is the last base technology. All " +
                "others have parents", 9, true, false, false, false, new List<Milestone>(),
                new List<ResearchItem>(), 1000, new List<IResource>());
            ResearchItem ten = new ResearchItem("ten", "It's 2 in binary!", 10, true, true,
                true, false, new List<Milestone>(), new List<ResearchItem>() { one }, 1000, new List<IResource>());
            ResearchItem eleven = new ResearchItem("eleven", "Super cool kid", 11, 
                true, false, false, false, new List<Milestone>(), new List<ResearchItem>() { two, three },
                1000, new List<IResource>());
            ResearchItem twelve = new ResearchItem("twelve", "I love the word \"puerile\" because " +
                "it comes from puer (pronounced \"poo-er\"), the Latin word for \"boy.\"", 12, true,
                false, false, false, new List<Milestone>(), new List<ResearchItem> { four, five, six }, 1000,
                new List<IResource>());
            ResearchItem thirteen = new ResearchItem("thirteen", "Still just a number, but I'm " +
                "fond of it.", 13, true, false, false, false, new List<Milestone>(), 
                new List<ResearchItem>() { six, seven }, 1000, new List<IResource>());
            ResearchItem fourteen = new ResearchItem("fourteen", "Ten four, good buddy!", 14, true,
                false, false, false, new List<Milestone>(), new List<ResearchItem>() { seven, eight }, 1000,
                new List<IResource>());
            ResearchItem fifteen = new ResearchItem("fifteen", "Aww, she's all grown up now.", 15,
                false, false, false, false, new List<Milestone>(), new List<ResearchItem>() { nine }, 1000,
                new List<IResource>());
            ResearchItem sixteen = new ResearchItem("sixteen", "How many candles down the drain?", 16,
                false, false, false, false, new List<Milestone>(), new List<ResearchItem>() { ten }, 200,
                new List<IResource>());
            ResearchItem seventeen = new ResearchItem("seventeen", "Not an adult yet.", 17, false,
                false, false, false, new List<Milestone>(), new List<ResearchItem>() { eleven, twelve }, 200,
                new List<IResource>());
            ResearchItem eighteen = new ResearchItem("eighteen", "Seems arbitrary to me.", 18, false,
                false, false, false, new List<Milestone>(), new List<ResearchItem>() { twelve, thirteen, fourteen },
                200, new List<IResource>());
            ResearchItem nineteen = new ResearchItem("nineteen", "Highest teen possible.", 19,
                false, false, false, false, new List<Milestone>(), new List<ResearchItem>() { nine, fourteen, fifteen },
                200, new List<IResource>());
            ResearchItem twenty = new ResearchItem("twenty", "This is where our numbering system " +
                "becomes more logical.", 20, false, false, false, false, new List<Milestone>(), 
                new List<ResearchItem>() { sixteen }, 400, new List<IResource>());
            ResearchItem twentyone = new ResearchItem("twentyone", "Now with new arbitrary " +
                "permissions!", 21, false, false, false, false, new List<Milestone>(), new List<ResearchItem>(),
                400, new List<IResource>());
            ResearchItem twentytwo = new ResearchItem("twentytwo", "Nothing special", 22, false, false,
                false, false, new List<Milestone>(), new List<ResearchItem>(), 400, new List<IResource>());
            ResearchItem twentythree = new ResearchItem("twentythree", "Bottleneck technology!", 23, false,
                false, false, false, new List<Milestone>(), new List<ResearchItem>() { fifteen, seventeen, eighteen, twenty, twentyone, twentytwo },
                10000, new List<IResource>());
            ResearchItem twentyfour = new ResearchItem("twentyfour", "An easily divided number.", 24, false,
                false, false, false, new List<Milestone>(), new List<ResearchItem>() { twentythree }, 2000,
                new List<IResource>());
            ResearchItem twentyfive = new ResearchItem("twentyfive", "Its square root is nothing special",
                25, false, false, false, false, new List<Milestone>(), new List<ResearchItem>() { twentyfour },
                4000, new List<IResource>());
            ResearchItem twentysix = new ResearchItem("twentysix", "Thirteen twice. Yup, I can do maths.",
                26, false, false, false, false, new List<Milestone>(), new List<ResearchItem> { twentyfour },
                4000, new List<IResource>());
            ResearchItem twentyseven = new ResearchItem("twentyseven", "Taco fact: Tacos are healthier " +
                "than crystal meth.", 27, false, false, false, false, new List<Milestone>(),
                new List<ResearchItem>() { twentyfour, twentyfive, twentysix }, 8000,
                new List<IResource>());
            ResearchItem twentyeight = new ResearchItem("twentyeight", "Taco fact: Tacos fall apart " +
                "sometimes, but we still love them. Don't be so hard on yourself", 28, false, false,
                false, false, new List<Milestone>(), new List<ResearchItem>() { twentysix }, 8000,
                new List<IResource>());
            ResearchItem victory = new ResearchItem("victory", "This is the highest technology in the " +
                "mock research controller.", 29, false, false, false, false, new List<Milestone>(),
                new List<ResearchItem>() { twentyseven, twentyeight }, 18000,
                new List<IResource>());
            List<ResearchItem> technologies = new List<ResearchItem>() { one, two, three, four,
                five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen,
                fifteen, sixteen, seventeen, eighteen, nineteen, twenty, twentyone, twentytwo,
                twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeight, victory };

            // ill-behaved code for making tests fail. Used only when tests are modified or created
            /**List<ResearchItem> existingParent = new List<ResearchItem>();
            List<Milestone> impossibleMilestone = new List<Milestone>();
            List<IResource> impossibleResources = new List<IResource>();
            ResearchItem circular1 = new ResearchItem("circular1", "This should make tests fail.", 1, false, false, false, true,
                impossibleMilestone, existingParent, 1, impossibleResources);
            ResearchItem circular2 = new ResearchItem("circular2", "Used for testing tests. How meta!", 1, false, false, false, true,
                impossibleMilestone, new List<ResearchItem>() { circular1 }, 1, impossibleResources);
            existingParent.Add(circular2);
            technologies.Add(circular1);
            technologies.Add(circular2);**/

            return technologies;
        }
    }
}
