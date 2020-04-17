using GreenBridge.Menu;
using System;

namespace GreenBridge.Core
{
    public class PlsqlDeveloperPlugin
    {
        protected PlsqlDeveloperPlugin()
        {
            PlsqlDeveloper = new PlsqlDeveloperFacade();
            RequiredCallbacks = new int[0];
        }

        protected PlsqlDeveloperPlugin(int id, string name)
        {
            PlsqlDeveloper = new PlsqlDeveloperFacade();
            RequiredCallbacks = new int[0];
            Id = id;
            Name = name;
        }

        public int Id
        {
            get;
            protected set;
        }
        public string Name
        {
            get;
            protected set;
        }

        public string ShortName
        {
            get;
            protected set;
        }

        public PlsqlDeveloperFacade PlsqlDeveloper
        {
            get;
            protected set;
        }

        public PlsqlDeveloperMenu Menu
        {
            get;
            protected set;
        }

        public int[] RequiredCallbacks
        {
            get;
            protected set;
        }

        public void RegisterRequiredCallback(int callbackIndex, IntPtr func)
        {
            if (callbackIndex == Callback.SYS_VERSION)
            {
                // Version callback is always required since some functionality depends on the PL/SQL Developer version.
                PlsqlDeveloper.RegisterCallback(callbackIndex, func);
            }
            else
            {
                PlsqlDeveloper.RegisterCallback(callbackIndex, func, match: RequiredCallbacks);
            }
        }
    }
}
