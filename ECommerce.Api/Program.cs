var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets(typeof(Program).Assembly);

builder.Services.AddInfrustructure();

builder.Services.AddApplication();

builder.Services.AddWeb(builder.Configuration);

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
