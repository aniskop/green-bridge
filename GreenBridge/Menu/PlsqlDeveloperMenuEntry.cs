using System;

namespace GreenBridge.Menu
{
    public class PlsqlDeveloperMenuEntry
    {
        /// <summary>
        /// Event handlers for the click event on the menu items (large items, subitems, items etc).
        /// <seealso cref="MenuEntryClickEventArgs"/>
        /// </summary>
        internal event EventHandler<MenuEntryClickEventArgs> Click;
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

        /// <summary>
        /// Invokes all <see cref="Click"/> event handlers for this item, if any.
        /// </summary>
        /// <param name="e">Event arguments, containing menu index.</param>
        internal void HandleClick(MenuEntryClickEventArgs e)
        {
            Click?.Invoke(this, e);
        }


    }
}
