using TEGDemoApp.Features.Events;
using TEGDemoApp.Features.Shared.Models;
using TEGDemoApp.Features.Venues;

namespace TEGDemoApp.Features.Shared.Extensions
{
    public static class VenueExtensions
    {
        public static VenueDto MapTo(this Venue venueModel, List<EventDto> eventDto)
        {
            return new VenueDto()
            {
                id = venueModel.id,
                name = venueModel.name,
                capacity = venueModel.capacity,
                location = venueModel.location,
                Events = eventDto
            };
        }
    }
}
