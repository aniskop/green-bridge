namespace GreenBridge.Menu
{
    public class MenuItem : PlsqlDeveloperMenuEntry
    {
        internal MenuItem(int id, string name) : base(id, name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return "MENUITEM=" + Name;
        }
    }
}
