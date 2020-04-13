using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenBridge.Menu
{
    public class PlsqlDeveloperMenuEntry
    {
        protected PlsqlDeveloperMenuEntry(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id
        {
            protected set;
            get;
        }

        public string Name
        {
            protected set;
            get;
        }
    }
}
