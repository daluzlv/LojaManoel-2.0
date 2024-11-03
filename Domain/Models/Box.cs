namespace Domain.Models;

public class BoxSpace
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public BoxSpace(int length, int width, int height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
}

public class Box
{
    private readonly List<BoxSpace> _availableSpace;
    private readonly List<Product> _products;
    public int Volume => _availableSpace.Sum(a => a.Height * a.Width * a.Length);

    public Box(int length, int width, int height, List<Product>? products = null)
    {
        _availableSpace = [new BoxSpace(length, width, height)];
        _products = products ?? [];
    }

    
    public bool AddProduct(Product product)
    {
        var productRotations = product.GetRotations();
        foreach (var availableSpace in _availableSpace)
        {
            foreach (var (rotatedLength, rotatedWidth, rotatedHeight) in productRotations)
            {
                if (!FitsInSpace(availableSpace, rotatedLength, rotatedWidth, rotatedHeight)) continue;
                
                _products.Add(product);
                UpdateAvailableSpace(availableSpace, product);
                return true;
            }
        }
        return false;
    }

    private static bool FitsInSpace(BoxSpace space, int length, int width, int height) => 
        length <= space.Length && width <= space.Width && height <= space.Height;

    private void UpdateAvailableSpace(BoxSpace space, Product product)
    {
        List<BoxSpace> newSpace = [];
        if (space.Length > product.Length)
            newSpace.Add(new BoxSpace(space.Length - product.Length, space.Width, space.Height));
        if (space.Width > product.Width)
            newSpace.Add(new BoxSpace(product.Length, space.Width - product.Width, space.Height));
        if (space.Height > product.Height)
            newSpace.Add(new BoxSpace(product.Length, product.Width, space.Height - product.Height));

        _availableSpace.Remove(space);
        _availableSpace.AddRange(newSpace);
    }
}
