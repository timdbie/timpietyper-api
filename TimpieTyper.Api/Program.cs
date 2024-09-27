var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() 
            .AllowAnyMethod()  
            .AllowAnyHeader(); 
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

var words = new[]
{
    "at", "home", "can", "those", "keep", "what", "part", "up", "move", "change"
};

app.MapGet("/words", () =>
    {
        var random = new Random();
    
        var shuffledWords = words.OrderBy(_ => random.Next()).ToList();
        
        var randomWords = Enumerable.Range(0, 80)
            .Select(i => shuffledWords[i % shuffledWords.Count])
            .ToList();

        return randomWords;
    })
    .WithName("GetRandomWords")
    .WithOpenApi();

app.Run();