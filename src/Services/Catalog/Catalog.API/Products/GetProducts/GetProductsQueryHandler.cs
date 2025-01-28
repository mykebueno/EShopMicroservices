using Catalog.API.Models;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(): IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);
    
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        if (products == null || products.Count == 0)
        {
            throw new ProductNotFoundException();
        }

        return new GetProductsResult(products);
    }
}
