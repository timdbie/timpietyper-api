using TimpieTyper.Core.Interfaces;
using TimpieTyper.Core.Services;
using TimpieTyper.Persistence.Context;
using TimpieTyper.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connString == null) throw new ArgumentNullException($"Connection string is null");
builder.Services.AddScoped<AppDbContext>(_ => new AppDbContext(connString));

builder.Services.AddScoped<IWordRepository, WordRepository>();

builder.Services.AddScoped<WordService>();

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

app.MapControllers();

app.Run();