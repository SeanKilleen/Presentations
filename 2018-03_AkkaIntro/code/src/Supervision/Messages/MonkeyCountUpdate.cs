namespace Supervision.Messages
{
    public class MonkeyCountUpdate
    {
        public int NumberMonkeys { get; }

        public MonkeyCountUpdate(int numMonkeys)
        {
            NumberMonkeys = numMonkeys;
        }
    }
}