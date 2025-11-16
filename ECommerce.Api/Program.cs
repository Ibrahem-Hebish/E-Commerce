using ECommerce.Application;
using ECommerce.Infrustructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets(typeof(Program).Assembly);

builder.Services.AddInfrustructure();

builder.Services.AddApplication();

builder.Services.AddWeb(builder.Configuration);

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
