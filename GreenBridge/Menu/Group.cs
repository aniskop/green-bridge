using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenBridge.Menu
{
    public class Group : PlsqlDeveloperMenuEntry
    {
        public Group(int id, string name) : base(id, name)
        {
        }

        public override string ToString()
        {
            return "GROUP=" + Name;
        }
    }
}
