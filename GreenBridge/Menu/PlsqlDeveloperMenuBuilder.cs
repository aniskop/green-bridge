using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenBridge.Menu
{
    public class PlsqlDeveloperMenuBuilder
    {

        private LinkedList<PlsqlDeveloperMenuEntry> menuEntries;
        private int recentId = 1;

        /// <summary>
        /// Creates an instance of the <c>PlsqlDeveloperMenuBuilder</c>.
        /// </summary>
        public PlsqlDeveloperMenuBuilder()
        {
            menuEntries = new LinkedList<PlsqlDeveloperMenuEntry>();
        }

        /// <summary>
        /// Performs common actions on the creation of each menu entry.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="clickHandler"></param>
        private void add(PlsqlDeveloperMenuEntry entry, EventHandler<MenuEntryClickEventArgs> clickHandler)
        {
            if (clickHandler != null)
            {
                entry.Click += clickHandler;
            }
            menuEntries.AddLast(entry);
            recentId++;
        }

        public PlsqlDeveloperMenuBuilder Tab(string name, EventHandler<MenuEntryClickEventArgs> clickHandler)
        {
            add(new Tab(recentId, name), clickHandler);
            return this;
        }

        public PlsqlDeveloperMenuBuilder Tab(string name)
        {
            return Tab(name, null);
        }

        //TODO: which menu entries can be clicked? does group or tab can be clicked?
        public PlsqlDeveloperMenuBuilder Group(string name, EventHandler<MenuEntryClickEventArgs> clickHandler)
        {
            add(new Group(recentId, name), clickHandler);
            return this;
        }

        public PlsqlDeveloperMenuBuilder Group(string name)
        {
            return Group(name, null);
        }

        public PlsqlDeveloperMenuBuilder Item(string name, EventHandler<MenuEntryClickEventArgs> clickHandler)
        {
            add(new Item(recentId, name), clickHandler);
            return this;
        }

        public PlsqlDeveloperMenuBuilder Item(string name)
        {
            return Item(name, null);
        }

        public PlsqlDeveloperMenuBuilder LargeItem(string name, EventHandler<MenuEntryClickEventArgs> clickHandler)
        {
            add(new LargeItem(recentId, name), clickHandler);
            return this;
        }

        public PlsqlDeveloperMenuBuilder LargeItem(string name)
        {
            return LargeItem(name, null);
        }

        public PlsqlDeveloperMenuBuilder MenuItem(string name, EventHandler<MenuEntryClickEventArgs> clickHandler)
        {
            add(new MenuItem(recentId, name), clickHandler);
            return this;
        }

        public PlsqlDeveloperMenuBuilder MenuItem(string name)
        {
            return MenuItem(name, null);
        }

        public PlsqlDeveloperMenuBuilder SubItem(string name, EventHandler<MenuEntryClickEventArgs> clickHandler)
        {
            add(new SubItem(recentId, name), clickHandler);
            return this;
        }
        public PlsqlDeveloperMenuBuilder SubItem(string name)
        {
            return SubItem(name, null);
        }

        /// <summary>
        /// Creates an instance of <see cref="PlsqlDeveloperMenu"/>, which represents the menu structure of the plug-in along with click event handlers.
        /// After this method is called, internal state is not reset, so subsequent calls to this method can be made.
        /// </summary>
        /// <returns></returns>
        public PlsqlDeveloperMenu Build()
        {
            return new PlsqlDeveloperMenu(menuEntries.ToArray<PlsqlDeveloperMenuEntry>());
        }
    }
}
