using Articium.Utils;
using Articium.Clients;
using Articium.DbConnector;
using Microsoft.EntityFrameworkCore;
using Articium.Services;
using Articium.EventServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region injections
var conn = builder.Configuration["Postgres:ConnectionString"];
builder.Services.AddDbContext<ArticiumDbContext>(options =>
          options.UseNpgsql(conn));

var logger = SerilogConfigExtension.CreateLogger(builder.Configuration, "review-api");
builder.Services.AddSingleton<Serilog.ILogger>(logger);
builder.Services.AddExternalServices(builder.Configuration);

builder.Services.AddReviewService();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CacheInvalidationEvent).Assembly));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.UseMiddleware<LoggingMiddleware>();
app.Run();

