namespace TEGDemoApp.Features.Venues
{
    public static class VenueDataEndpoint
    {
        public static void MapVenueDataEndpoint(this WebApplication app)
        {
            app.MapGet("/api/venues", async (IVenueApiClient client) =>
            {
                try
                {
                    var venues = await client.GetAllVenuesAsync();

                    if (venues == null)
                    {
                        return Results.Problem(
                            detail: "Bad Data",
                            title: "Bad Request",
                            statusCode: 400);
                    }

                    if (venues.Count == 0)
                    {
                        return Results.Problem(
                            detail: "No Venue was found",
                            title: "Venues not found",
                            statusCode: 404);
                    }

                    return Results.Ok(venues);
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                            detail: "An error has occurred",
                            title: "Internal Server Error",
                            statusCode: 500);
                }
            });
        }
    }
}
