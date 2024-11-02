namespace Domain;

public class Product
{
    public int Length { get; private set; }
    public int Height { get; private set; }
    public int Width { get; private set; }

    public Product(int length, int height, int width)
    {
        Length = length;
        Height = height;
        Width = width;
    }

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