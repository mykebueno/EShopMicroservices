﻿namespace Catalog.API.Products.GetProducts;

public record GetProcutsRequest(int? PageNumber = 1, int? PageSize = 10);

public record GetProductsResponse(
        IEnumerable<Product> Products
    );

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapGet("products", async ([AsParameters] GetProcutsRequest request, ISender sender) =>
            {
                GetProductsQuery query = request.Adapt<GetProductsQuery>();

                GetProductsResult result = await sender.Send(query);

                GetProductsResponse response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}
