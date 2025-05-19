using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdRequest();

public record GetProductByIdResponse( Product Product );

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("products/{id}", async (Guid id, ISender sender) =>
        {
            GetProductByIdResult result = await sender.Send(new GetProductByIdQuery(id));

            GetProductByIdResponse response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductsById")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products by Id")
        .WithDescription("Get Products by Id"); 
    }
}
