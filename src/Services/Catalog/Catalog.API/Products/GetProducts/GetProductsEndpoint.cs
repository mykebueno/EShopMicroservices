namespace Catalog.API.Products.GetProducts;

public record GetProductsRequest();

public record GetProductsResposne(
        IEnumerable<Product> Products
    );

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapGet("products", async (ISender sender) =>
            {
                GetProductsResult result = await sender.Send(new GetProductsQuery());

                GetProductsResposne response = result.Adapt<GetProductsResposne>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResposne>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}
