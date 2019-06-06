namespace Shared.Messages
{
    public class HelloWorldMessage
    {
        public HelloWorldMessage(string name)
        {
            Name = name;
        }
        public string Name { get; }

    }
}