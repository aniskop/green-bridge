namespace GreenBridge.Menu
{
    public class LargeItem : PlsqlDeveloperMenuEntry
    {
        internal LargeItem(int id, string name) : base(id, name)
        {
        }

        public override string ToString()
        {
            return "LARGEITEM=" + Name;
        }
    }
}
