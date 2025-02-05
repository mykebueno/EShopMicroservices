using BuildingBlocks.Behaviours;
using Catalog.API.Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var programAssembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(programAssembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(programAssembly);

builder.Services.AddCarter(new DependencyContextAssemblyCatalogCustom());

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions(); 

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();
