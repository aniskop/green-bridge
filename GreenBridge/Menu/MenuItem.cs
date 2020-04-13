namespace GreenBridge.Menu
{
    public class MenuItem : PlsqlDeveloperMenuEntry
    {
        public MenuItem(int id, string name) : base(id, name)
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
