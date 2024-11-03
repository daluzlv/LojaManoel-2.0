namespace Application.DTOs;

public class ProductRequestDto(string productId, SpaceDto space)
{
    public string ProductId { get; set; } = productId;
    public SpaceDto Space { get; set; } = space;
}

public class ProductResponseDto(string productId)
{
    public string ProductId { get; set; } = productId;
}
