namespace Domain;

public class Product(int length, int height, int width)
{
    public int Length { get; private set; } = length;
    public int Height { get; private set; } = height;
    public int Width { get; private set; } = width;
    public int Volume => Length * Height * Width;

    public List<(int, int, int)> GetRotations()
    {
        return
        [
            (Length, Height, Width),
            (Length, Width, Height),
            (Height, Length, Width),
            (Height, Width, Length),
            (Width, Length, Height),
            (Width, Height, Length)
        ];
    }
}