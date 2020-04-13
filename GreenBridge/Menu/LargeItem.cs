namespace GreenBridge.Menu
{
    public class LargeItem : PlsqlDeveloperMenuEntry
    {
        public LargeItem(int id, string name) : base(id, name)
        {
        }

        public override string ToString()
        {
            return "LARGEITEM=" + Name;
        }
    }
}
