using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"appsettings.json", optional: false);

builder.Services.AddOcelot();

var app = builder.Build();
await app.RunAsync();
