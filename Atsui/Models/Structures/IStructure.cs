using Atsui.Models.Resources;

namespace Atsui.Models.Structures
{
    public interface IStructure
    {
        public string Type { get; }
        public int ID { get; }
        public List<IResource> ResourcesInside { get; set; }
    }
}
