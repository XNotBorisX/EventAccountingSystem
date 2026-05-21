using EventAccountingSystemAPI.Repositories;
using EventAccountingSystemAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "events.json");
builder.Services.AddSingleton<IEventRepository>(new JsonEventRepository(dataPath));
builder.Services.AddScoped<IEventService, EventService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();