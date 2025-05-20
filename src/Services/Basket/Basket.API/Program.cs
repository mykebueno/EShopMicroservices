using Basket.API.Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter(new DependencyContextAssemblyCatalogCustom());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();
