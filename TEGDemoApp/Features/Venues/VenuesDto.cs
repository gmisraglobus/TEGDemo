using TEGDemoApp.Features.Events;

namespace TEGDemoApp.Features.Venues
{
    public class VenueDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public string location { get; set; }
        public List<EventDto> Events { get; set; }
    }
}
