namespace GreenBridge.Menu
{
    /// <summary>
    /// Represents PL/SQL Developer menu with tabs, groups, menu items, large items etc.
    /// Also contains reference to the menu click handlers.
    /// Internal structure is optimized for usage within PL/SQL Developer (draw menu and handle click event).
    /// To build menu use <see cref="PlsqlDeveloperMenuBuilder"/>.
    /// <seealso cref="Tab"/>
    /// <seealso cref="Group"/>
    /// <seealso cref="Item"/>
    /// <seealso cref="MenuItem"/>
    /// <seealso cref="LargeItem"/>
    /// <seealso cref="SubItem"/>
    /// </summary>
    public class PlsqlDeveloperMenu
    {
        private PlsqlDeveloperMenuEntry[] menuEntries;

        /// <summary>
        /// Creates an instance of PL/SQL Developer menu. 
        /// Use <see cref="PlsqlDeveloperMenuBuilder"/> to create the menu.
        /// <seealso cref="PlsqlDeveloperMenuBuilder"/>
        /// </summary>
        internal PlsqlDeveloperMenu(PlsqlDeveloperMenuEntry[] entries)
        {
            menuEntries = entries;
        }

        /// <summary>
        /// Calls click event handler, if any, on the appropriate menu entry.
        /// When creating menu entries with <see cref="PlsqlDeveloperMenuBuilder"/>, be sure to specify click event handler on the entry.
        /// This method is intended to be called from plug-in's <c>OnMenuClick</c> exported function.
        /// </summary>
        /// <param name="menuIndex">Index of the menu entry, which has been clicked. The value is passed from PL/SQL Developer.</param>
        /// <example>This example demonstrates the usage of the method.
        /// <code>
        /// public static void OnMenuClick(int index) {
        ///     pluginMenu.HandleClick(index);
        /// }
        /// </code>
        /// </example>
        public void HandleClick(int menuIndex)
        {
            // Menu index starts from 1.
            if (menuIndex >= 1 && menuIndex <= menuEntries.Length)
            {
                PlsqlDeveloperMenuEntry menuEntry = menuEntries[menuIndex - 1];
                menuEntry.HandleClick(new MenuEntryClickEventArgs(menuIndex));
            }
        }

        public PlsqlDeveloperMenuEntry Entry(int menuIndex)
        {
            if (menuIndex >= 1 && menuIndex <= menuEntries.Length)
            {
                return menuEntries[menuIndex - 1];
            } else
            {
                return PlsqlDeveloperMenuEntry.Empty;
            }
        }
    }
}
