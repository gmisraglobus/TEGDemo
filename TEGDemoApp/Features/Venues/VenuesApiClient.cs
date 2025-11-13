using Microsoft.Extensions.Options;
using TEGDemoApp.Features.Shared.Models;
using TEGDemoApp.Features.Shared.Extensions;
using TEGDemoApp.Features.Shared.Configuration;

namespace TEGDemoApp.Features.Venues
{
    public class VenueApiClient : IVenueApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceSettings _serviceSettings;
        public VenueApiClient(HttpClient httpClient, IOptions<ServiceSettings> serviceSettings)
        {
            _httpClient = httpClient;
            _serviceSettings = serviceSettings.Value;
        }

        public async Task<List<VenueDto>> GetAllVenuesAsync()
        {
            List<VenueDto> getAllVenues = new List<VenueDto>();

            _httpClient.BaseAddress = new Uri(_serviceSettings.EventsDataBaseUrl);
            var response = await _httpClient.GetFromJsonAsync<EventRoot>(_httpClient.BaseAddress);

            if (response == null)
            {
                // serialization error
                return null;
            }

            if (!response.Venues.Any())
            {
                // no venues found (404)
                return getAllVenues;
            }

            var venues = response.Venues;
            var events = response.Events;

            getAllVenues = venues.Select(m =>
            {
                var eventsDTO = events.Where(e => e.venueId == m.id).Select(m => m.MapTo()).ToList();
                return m.MapTo(eventsDTO);
            }).ToList();

            return getAllVenues;
        }
    }
}
