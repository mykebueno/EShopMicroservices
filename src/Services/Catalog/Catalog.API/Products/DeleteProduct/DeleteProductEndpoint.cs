
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.UpdateProduct;

public record DeleteProductRequest();

public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("products/{guid}", async (Guid guid, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(guid));

            var response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete product");
    }
}
