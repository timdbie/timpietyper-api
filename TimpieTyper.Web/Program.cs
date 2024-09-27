var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var words = new[]
{
    "at", "home", "can", "those", "keep", "what", "part", "up", "move", "change"
};

app.MapGet("/words", () =>
    {
        var random = new Random();
        
        var shuffledWords = words.OrderBy(_ => random.Next()).ToList();
        
        var randomWords = Enumerable.Range(0, 50)
            .Select(i => shuffledWords[i % shuffledWords.Count])
            .ToList();

        return randomWords;
    })
.WithName("GetRandomWords")
.WithOpenApi();

app.Run();