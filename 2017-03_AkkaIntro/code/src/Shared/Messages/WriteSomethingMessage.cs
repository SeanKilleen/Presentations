namespace Shared.Messages
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