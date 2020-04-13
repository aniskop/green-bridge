using System;

namespace GreenBridge.Menu
{
    public class MenuEntryClickEventArgs : EventArgs
    {
        public MenuEntryClickEventArgs(int entryIndex)
        {
            Index = entryIndex;
        }

        /// <summary>
        /// Index of the menu entry, which has been clicked by the user.
        /// </summary>
        public int Index
        {
            private set;
            get;
        }
    }
}
