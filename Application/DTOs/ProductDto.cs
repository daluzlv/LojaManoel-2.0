namespace Application.DTOs;

public class ProductDto(string productId, SpaceDto space)
{
    public string ProductId { get; set; } = productId;
    public SpaceDto Space { get; set; } = space;
}
