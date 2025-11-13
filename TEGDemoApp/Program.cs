using TEGDemoApp.Features.Shared.Configuration;
using TEGDemoApp.Features.Venues;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Using Options Pattern
        builder.Services.AddOptions();
        builder.Services.Configure<ServiceSettings>(builder.Configuration.GetSection("ApplicationSettings"));

        builder.Services.AddHttpClient<IVenueApiClient, VenueApiClient>();

        // Register MemoryCache service so we can cache the results in-memory and serve to client, if the Json endpoint is unreacheable/unreliable (Resilient API Pattern)
        builder.Services.AddMemoryCache();

        // Allow CORS for local React dev
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        // for react app to be served from .Net core (One App serving React + API together)
        app.UseDefaultFiles(); // serve index.html if no file specified
        app.UseStaticFiles(); // serve files from wwwroot

        app.MapVenueDataEndpoint();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors();

        // Fallback to index.html for React routes
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}