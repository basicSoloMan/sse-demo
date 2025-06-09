using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using sss_demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/sse-demo", (CancellationToken cancellationToken) =>
{
    return TypedResults.ServerSentEvents(GetData(cancellationToken));
    
    async IAsyncEnumerable<SseItem<MockDataModel>> GetData([EnumeratorCancellation] CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), ct);
            yield return new SseItem<MockDataModel>(DataGenerator.CreateMockData(), "mock-data")
            {
                ReconnectionInterval = TimeSpan.FromMinutes(5),
            };
        }
    } 
});

app.Run();
