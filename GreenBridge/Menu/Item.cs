namespace GreenBridge.Menu
{
    public class Item : PlsqlDeveloperMenuEntry
    {
        public Item(int id, string name) : base(id, name)
        {
        }

        public override string ToString()
        {
            return "ITEM=" + Name;
        }
    }
}
