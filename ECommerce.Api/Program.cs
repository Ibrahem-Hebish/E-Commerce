using ECommerce.Infrustructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrustructure();

builder.Services.AddWeb(builder.Configuration);

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
