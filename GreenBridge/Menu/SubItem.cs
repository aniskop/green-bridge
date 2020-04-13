namespace GreenBridge.Menu
{
    public class SubItem : PlsqlDeveloperMenuEntry
    {
        public SubItem(int id, string name) : base(id, name)
        {
        }

        public override string ToString()
        {
            return "SUBITEM=" + Name;
        }
    }
}
