using System.IO;
using System.Xml.Linq;

namespace Comm2Tender.Logic.Models
{
    public class UserMenuItem
    {
        public UserMenuItem(string name, string path, string icon)
        {
            Name = name;
            Path = path;
            Icon = icon;
        }
        public string Name { get; private set; }

        public string Path { get; private set; }

        public string Icon { get; private set; }
    }
}
