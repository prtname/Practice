using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS
{
    public class MenuItem
    {
        public MenuItem(string title, string description, Uri uri)
        {
            Title = title;
            Description = description;
            Uri = uri;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Uri { get; set; }
    }
}
