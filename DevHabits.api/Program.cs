using DevHabits.api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Logs;
using OpenTelemetry.Exporter;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerDatabase"),
        sqlServerOptions => sqlServerOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Application));
    options.UseSnakeCaseNamingConvention();
});

// NOTE: Logging is registered via .WithLogging(...) below (not builder.Logging.AddOpenTelemetry),
// so that the single UseOtlpExporter() call handles export for tracing, metrics, AND logging.
// Mixing signal-specific AddOtlpExporter/builder.Logging.AddOpenTelemetry with the cross-cutting
// UseOtlpExporter() throws: "Signal-specific AddOtlpExporter methods and the cross-cutting
// UseOtlpExporter method being invoked on the same IServiceCollection is not supported."
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(builder.Environment.ApplicationName))
    .WithTracing(tracing => tracing
        .AddHttpClientInstrumentation()
        .AddAspNetCoreInstrumentation())
    .WithMetrics(metrics => metrics
        .AddHttpClientInstrumentation()
        .AddAspNetCoreInstrumentation()
        .AddRuntimeInstrumentation())
    .WithLogging(logging =>
    {
        logging.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName));
    }, options =>
    {
        options.IncludeScopes = true;
        options.IncludeFormattedMessage = true;
        options.ParseStateValues = true;
    })
    .UseOtlpExporter();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
