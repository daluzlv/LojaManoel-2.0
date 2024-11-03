using Application.DTOs;

namespace Application.Queries.Packing.Queries;

public class GetPackedProductsQuery(List<OrderDto> orders)
{
    public List<OrderDto> Orders { get; set; } = orders;
}