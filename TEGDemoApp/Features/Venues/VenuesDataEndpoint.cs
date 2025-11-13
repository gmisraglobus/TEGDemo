namespace TEGDemoApp.Features.Venues
{
    public static class VenueDataEndpoint
    {
        public static void MapVenueDataEndpoint(this WebApplication app)
        {
            app.MapGet("/api/venues", async (IVenueApiClient client) =>
            {
                var venues = await client.GetAllVenuesAsync();

                if (venues == null)
                {
                    return Results.BadRequest();
                }

                if (venues.Count == 0) 
                {
                    return Results.NotFound();
                }
                
                return Results.Ok(venues);
            });
        }
    }
}
