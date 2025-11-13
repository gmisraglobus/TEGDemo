using TEGDemoApp.Features.Events;
using TEGDemoApp.Features.Shared.Models;

namespace TEGDemoApp.Features.Shared.Extensions
{
    public static class EventExtensions
    {
        public static EventDto MapTo(this Event eventModel)
        {
            return new EventDto() 
            {
                id = eventModel.id, 
                description = eventModel.description, 
                venueId = eventModel.venueId, 
                name = eventModel.name, 
                startDate = eventModel.startDate
            };
        }
    }
}
