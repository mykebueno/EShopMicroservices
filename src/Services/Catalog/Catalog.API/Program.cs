using Catalog.API.Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var programAssembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(programAssembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(programAssembly);

builder.Services.AddCarter(new DependencyContextAssemblyCatalogCustom());

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions(); 

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
