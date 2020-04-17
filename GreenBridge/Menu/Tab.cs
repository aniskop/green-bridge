namespace GreenBridge.Menu
{
    public class Tab : PlsqlDeveloperMenuEntry
    {
        internal Tab(int id, string name) : base(id, name)
        {
        }

        public override string ToString()
        {
            return "TAB=" + Name;
        }
    }
}
