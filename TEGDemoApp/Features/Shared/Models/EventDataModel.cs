namespace TEGDemoApp.Features.Shared.Models
{
    // used https://json2csharp.com/ to convert JSON Data Schema to C# classes.
    // Alternatively, we could use a Nuget Package and DotNet CLI tool to scaffold the classes
    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public int venueId { get; set; }
        public string description { get; set; }
    }

    public class EventRoot
    {
        public List<Event> Events { get; set; }
        public List<Venue> Venues { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public string location { get; set; }
    }
}
