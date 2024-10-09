using TimpieTyper.Persistence;
using TimpieTyper.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connString == null) throw new ArgumentNullException($"Connection string is null");
builder.Services.AddScoped<AppDbContext>(_ => new AppDbContext(connString));

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