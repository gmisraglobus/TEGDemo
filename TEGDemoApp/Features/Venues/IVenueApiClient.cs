namespace TEGDemoApp.Features.Venues
{
    public interface IVenueApiClient
    {
        Task<List<VenueDto>> GetAllVenuesAsync();
    }
}
