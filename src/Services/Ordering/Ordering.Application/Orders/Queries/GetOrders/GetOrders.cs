using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest RequesPaginationRequest) : IQuery<GetOrdersResult>;

public record GetOrdersResult(PaginationResult<OrderDto> PaginationResult);