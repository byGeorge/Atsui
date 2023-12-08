using Atsui.Models;

namespace Atsui.Controllers.DbControllers
{
    public class MockDBController : IDBController
    {
        public MockDBController() { }

        public List<Technology> GetTechnologies()
        {
            Technology one = new Technology("one", "Is it a lonely number because it's" +
                "unimaginative?", true, true, 10, true, new List<Technology>(),
                new List<Milestone>());
            Technology two = new Technology("two", "The Twoth fairy is less horrifying " +
                "than the threeth fairy",true, false, 1, false, new List<Technology>(),
                new List<Milestone>());
            Technology three = new Technology("three", "Beware. BEWARE!", true,
                false, 1, false, new List<Technology>(), new List<Milestone>());
            Technology four = new Technology("four", "We Go! by Hiroshi Kitadani is " +
                "adorable.", false, false, 1, false, new List<Technology>(),
                new List<Milestone>());
            Technology five = new Technology("five", "Even Eris would acknowledge that five " +
                "is just another number.", true, false, 1, false, new List<Technology>(),
                new List<Milestone>());
            Technology six = new Technology("six", "Still just a number, even when repeated " +
                "thrice.", true, false, 1, true, new List<Technology>(), new List<Milestone>());
            Technology seven = new Technology("seven", "Calling them deadly sins seems a bit " +
                "overkill, if you ask me.", true, false, 1, false, new List<Technology>(),
                new List<Milestone>());
            Technology eight = new Technology("eight", "If you figure out how to fold a path " +
                "this many times, you may receive enlightenment", true, false, 1, false,
                new List<Technology>(), new List<Milestone>());
            Technology nine = new Technology("nine", "This is the last base technology. All " +
                "others have parents", true, false, 0, false, new List<Technology>(),
                new List<Milestone>());
            Technology ten = new Technology("ten", "It's 2 in binary!", true, true,
                10, true, new List<Technology>() { one }, new List<Milestone>());
            Technology eleven = new Technology("eleven", "Super cool kid", 
                true, false, 10, false, new List<Technology>() { two, three },
                new List<Milestone>());
            Technology twelve = new Technology("twelve", "I love the word \"puerile\" because " +
                "it comes from puer (pronounced \"poo-er\"), the Latin word for \"boy.\"", true,
                false, 10, false, new List<Technology> { four, five, six },
                new List<Milestone>());
            Technology thirteen = new Technology("thirteen", "Still just a number, but I'm " +
                "fond of it.", true, false, 10, false, new List<Technology>() { six, seven },
                new List<Milestone>());
            Technology fourteen = new Technology("fourteen", "Ten four, good buddy!", true,
                false, 10, false, new List<Technology>() { seven, eight },
                new List<Milestone>());
            Technology fifteen = new Technology("fifteen", "Aww, she's all grown up now.",
                false, false, 10, false, new List<Technology>() { nine },
                new List<Milestone>());
            Technology sixteen = new Technology("sixteen", "How many candles down the drain?",
                false, false, 100, false, new List<Technology>() { ten },
                new List<Milestone>());
            Technology seventeen = new Technology("seventeen", "Not an adult yet.", false,
                false, 100, false, new List<Technology>() { eleven, twelve },
                new List<Milestone>());
            Technology eighteen = new Technology("eighteen", "Seems arbitrary to me.", false,
                false, 100, false, new List<Technology>() { twelve, thirteen, fourteen },
                new List<Milestone>());
            Technology nineteen = new Technology("nineteen", "Highest teen possible.",
                false, false, 100, false, new List<Technology>() { nine, fourteen, fifteen },
                new List<Milestone>());
            Technology twenty = new Technology("twenty", "This is where our numbering system " +
                "becomes more logical.", false, false, 200, false, new List<Technology>() { sixteen },
                new List<Milestone>());
            Technology twentyone = new Technology("twentyone", "Now with new arbitrary " +
                "permissions!", false, false, 200, false, new List<Technology>(),
                new List<Milestone>());
            Technology twentytwo = new Technology("twentytwo", "Nothing special", false, false,
                200, false, new List<Technology>(), new List<Milestone>());
            Technology twentythree = new Technology("twentythree", "Bottleneck technology!", false,
                false, 300, false, new List<Technology>() { fifteen, seventeen, eighteen, twenty, twentyone, twentytwo },
                new List<Milestone>());
            Technology twentyfour = new Technology("twentyfour", "An easily divided number.", false,
                false, 400, false, new List<Technology>() { twentythree },
                new List<Milestone>());
            Technology twentyfive = new Technology("twentyfive", "Its square root is nothing special",
                false, false, 500, false, new List<Technology>() { twentyfour },
                new List<Milestone>());
            Technology twentysix = new Technology("twentysix", "Thirteen twice. Yup, I can do maths.",
                false, false, 600, false, new List<Technology> { twentyfour },
                new List<Milestone>());
            Technology twentyseven = new Technology("twentyseven", "Taco fact: Tacos are healthier " +
                "than crystal meth.", false, false, 700, false, 
                new List<Technology>() { twentyfour, twentyfive, twentysix },
                new List<Milestone>());
            Technology twentyeight = new Technology("twentyeight", "Taco fact: Tacos fall apart " +
                "sometimes, but we still love them. Don't be so hard on yourself", false, false,
                800, false, new List<Technology>() { twentysix },
                new List<Milestone>());
            Technology victory = new Technology("victory", "This is the highest technology in the " +
                "mock research controller.", false, false, 1000, false, 
                new List<Technology>() { twentyseven, twentyeight },
                new List<Milestone>());
            
            List<Technology> technologies = new List<Technology>() { one, two, three, four, 
                five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, 
                fifteen, sixteen, seventeen, eighteen, nineteen, twenty, twentyone, twentytwo,
                twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeight, victory };
            return technologies;
        }
    }
}
