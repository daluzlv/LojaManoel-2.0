using Application.DTOs;

namespace Application.Queries.Packing.Queries;

public class GetPackedProducts(List<OrderDto> orders)
{
    public List<OrderDto> Orders { get; set; } = orders;
}