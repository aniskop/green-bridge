namespace GreenBridge.Menu
{
    public class Item : PlsqlDeveloperMenuEntry
    {
        internal Item(int id, string name) : base(id, name)
        {
        }

        public override string ToString()
        {
            return "ITEM=" + Name;
        }
    }
}
