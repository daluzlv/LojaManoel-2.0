namespace Application.DTOs;

public class OrderDto(int orderId, IEnumerable<ProductRequestDto> products)
{
    public int OrderId { get; set; } = orderId;
    public IEnumerable<ProductRequestDto> Products { get; set; } = products;
}

public class OrderResponseDto(int orderId, IEnumerable<BoxResponseDto> boxes)
{
    public int OrderId { get; set; } = orderId;
    public IEnumerable<BoxResponseDto> Boxes { get; set; } = boxes;
}