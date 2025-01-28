
using Catalog.API.Products.GetProducts;
using Mapster;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryRequest();

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("products/category/{category}", async (string category, ISender sender) =>
        {
            GetProductByCategoryResult result = await sender.Send(new GetProductByCategoryQuery(category));
            
            GetProductByCategoryResponse response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductsByCategory")
        .Produces<GetProductsResposne>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products by category")
        .WithDescription("Get Products by category"); ;
    }
}
