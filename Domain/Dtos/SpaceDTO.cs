namespace Domain.Dtos;

public class SpaceDTO
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public SpaceDTO(int length, int width, int height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
}