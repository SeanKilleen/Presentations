namespace Shared
{
    public class WriteSomethingMessage
    {
        public string ThingToWrite { get; }

        public WriteSomethingMessage(string thingToWrite)
        {
            ThingToWrite = thingToWrite;
        }
    }
}