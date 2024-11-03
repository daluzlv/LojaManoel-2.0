namespace Application.DTOs;

public class OrderDto(List<ProductDto> products)
{
    public Guid OrderId { get; set; }
    public List<ProductDto> Products { get; set; } = products;
}