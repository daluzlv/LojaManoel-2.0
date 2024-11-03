namespace Application.DTOs;

public class BoxResponseDto(string boxId, List<string> products)
{
    public string BoxId { get; set; } = boxId;
    public List<string> Products { get; set; } = products;
}