using Atsui.Models;
using Atsui.Models.Resources;
using Humanizer.Localisation;

namespace Atsui.Controllers.DbControllers
{
    public class MockSwimmerDBController : ISwimmerDBController
    {
        public MockSwimmerDBController() { }

        public int GetID()
        {
            return -1;
        }

        public List<Technology> GetTechnologies()
        {
            // well-behaved code for mock development
            Technology one = new Technology("one", "Is it a lonely number because it's" +
                "unimaginative?", 1, true, true, true, new List<Milestone>(), new List<Technology>(),
                1, new List<IResource>());
            Technology two = new Technology("two", "The Twoth fairy is less horrifying " +
                "than the threeth fairy",1, false, false, false, new List<Milestone>(),
                new List<Technology>(), 10, new List<IResource>());
            Technology three = new Technology("three", "Beware. BEWAAAARE!", 3, true,
                false, false, new List<Milestone>(), new List<Technology>(), 10, new List<IResource>());
            Technology four = new Technology("four", "We Go! by Hiroshi Kitadani is " +
                "adorable.", 4, false, false, false, new List<Milestone>(),
                new List<Technology>(), 10, new List<IResource>());
            Technology five = new Technology("five", "Even Eris would acknowledge that five " +
                "is just another number.", 5, false, false, false, new List<Milestone>(),
                new List<Technology>(), 10, new List<IResource>());
            Technology six = new Technology("six", "Still just a number, even when repeated " +
                "thrice.", 6, false, false, true, new List<Milestone>(), new List<Technology>(), 10, 
                new List<IResource>());
            Technology seven = new Technology("seven", "Calling them deadly sins seems a bit " +
                "overkill, if you ask me.", 7, true, false, false, new List<Milestone>(),
                new List<Technology>(), 10, new List<IResource>());
            Technology eight = new Technology("eight", "If you figure out how to fold a path " +
                "this many times, you may receive enlightenment", 8, true, false, false,
                new List<Milestone>(), new List<Technology>(), 10, new List<IResource>());
            Technology nine = new Technology("nine", "This is the last base technology. All " +
                "others have parents", 9, true, false, false, new List<Milestone>(),
                new List<Technology>(), 10, new List<IResource>());
            Technology ten = new Technology("ten", "It's 2 in binary!", 10, true, true,
                true, new List<Milestone>(), new List<Technology>() { one }, 100, new List<IResource>());
            Technology eleven = new Technology("eleven", "Super cool kid", 11, 
                true, false, false, new List<Milestone>(), new List<Technology>() { two, three },
                100, new List<IResource>());
            Technology twelve = new Technology("twelve", "I love the word \"puerile\" because " +
                "it comes from puer (pronounced \"poo-er\"), the Latin word for \"boy.\"", 12, true,
                false, false, new List<Milestone>(), new List<Technology> { four, five, six }, 100,
                new List<IResource>());
            Technology thirteen = new Technology("thirteen", "Still just a number, but I'm " +
                "fond of it.", 13, true, false, false, new List<Milestone>(), 
                new List<Technology>() { six, seven }, 100, new List<IResource>());
            Technology fourteen = new Technology("fourteen", "Ten four, good buddy!", 14, true,
                false, false, new List<Milestone>(), new List<Technology>() { seven, eight }, 100,
                new List<IResource>());
            Technology fifteen = new Technology("fifteen", "Aww, she's all grown up now.", 15,
                false, false, false, new List<Milestone>(), new List<Technology>() { nine }, 100,
                new List<IResource>());
            Technology sixteen = new Technology("sixteen", "How many candles down the drain?", 16,
                false, false, false, new List<Milestone>(), new List<Technology>() { ten }, 200,
                new List<IResource>());
            Technology seventeen = new Technology("seventeen", "Not an adult yet.", 17, false,
                false, false, new List<Milestone>(), new List<Technology>() { eleven, twelve }, 200,
                new List<IResource>());
            Technology eighteen = new Technology("eighteen", "Seems arbitrary to me.", 18, false,
                false, false, new List<Milestone>(), new List<Technology>() { twelve, thirteen, fourteen },
                200, new List<IResource>());
            Technology nineteen = new Technology("nineteen", "Highest teen possible.", 19,
                false, false, false, new List<Milestone>(), new List<Technology>() { nine, fourteen, fifteen },
                200, new List<IResource>());
            Technology twenty = new Technology("twenty", "This is where our numbering system " +
                "becomes more logical.", 20, false, false, false, new List<Milestone>(), 
                new List<Technology>() { sixteen }, 400, new List<IResource>());
            Technology twentyone = new Technology("twentyone", "Now with new arbitrary " +
                "permissions!", 21, false, false, false, new List<Milestone>(), new List<Technology>(),
                400, new List<IResource>());
            Technology twentytwo = new Technology("twentytwo", "Nothing special", 22, false, false,
                false, new List<Milestone>(), new List<Technology>(), 400, new List<IResource>());
            Technology twentythree = new Technology("twentythree", "Bottleneck technology!", 23, false,
                false, false, new List<Milestone>(), new List<Technology>() { fifteen, seventeen, eighteen, twenty, twentyone, twentytwo },
                1000, new List<IResource>());
            Technology twentyfour = new Technology("twentyfour", "An easily divided number.", 24, false,
                false, false, new List<Milestone>(), new List<Technology>() { twentythree }, 2000,
                new List<IResource>());
            Technology twentyfive = new Technology("twentyfive", "Its square root is nothing special",
                25, false, false, false, new List<Milestone>(), new List<Technology>() { twentyfour },
                4000, new List<IResource>());
            Technology twentysix = new Technology("twentysix", "Thirteen twice. Yup, I can do maths.",
                26, false, false, false, new List<Milestone>(), new List<Technology> { twentyfour },
                4000, new List<IResource>());
            Technology twentyseven = new Technology("twentyseven", "Taco fact: Tacos are healthier " +
                "than crystal meth.", 27, false, false, false, new List<Milestone>(),
                new List<Technology>() { twentyfour, twentyfive, twentysix }, 8000,
                new List<IResource>());
            Technology twentyeight = new Technology("twentyeight", "Taco fact: Tacos fall apart " +
                "sometimes, but we still love them. Don't be so hard on yourself", 28, false, false,
                false, new List<Milestone>(), new List<Technology>() { twentysix }, 8000,
                new List<IResource>());
            Technology victory = new Technology("victory", "This is the highest technology in the " +
                "mock research controller.", 29, false, false, false, new List<Milestone>(),
                new List<Technology>() { twentyseven, twentyeight }, 18000,
                new List<IResource>());
            List<Technology> technologies = new List<Technology>() { one, two, three, four,
                five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen,
                fifteen, sixteen, seventeen, eighteen, nineteen, twenty, twentyone, twentytwo,
                twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeight, victory };

            // ill-behaved code for making tests fail. Used only when tests are modified or created
            /**List<Technology> existingParent = new List<Technology>();
            List<Milestone> impossibleMilestone = new List<Milestone>();
            List<IResource> impossibleResources = new List<IResource>();
            Technology circular1 = new Technology("circular1", "This should make tests fail.", 1, false, false, false,
                impossibleMilestone, existingParent, 1, impossibleResources);
            Technology circular2 = new Technology("circular2", "Used for testing tests. How meta!", 1, false, false, false,
                impossibleMilestone, new List<Technology>() { circular1 }, 1, impossibleResources);
            existingParent.Add(circular2);
            technologies.Add(circular1);
            technologies.Add(circular2);**/

            return technologies;
        }
    }
}
