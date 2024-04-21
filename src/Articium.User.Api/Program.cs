using Articium.DbConnector;
using Articium.EventServices;
using Articium.Services;
using Articium.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration["Postgres:ConnectionString"];
builder.Services.AddDbContext<ArticiumDbContext>(options =>
          options.UseNpgsql(conn));

var logger = SerilogConfigExtension.CreateLogger(builder.Configuration, "user-api");
builder.Services.AddSingleton<Serilog.ILogger>(logger);

builder.Services.AddUserService();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CacheInvalidationEvent).Assembly));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();

app.Run();
