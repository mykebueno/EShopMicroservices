using Catalog.API.Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter(new DependencyContextAssemblyCatalogCustom());
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
}); 

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();
