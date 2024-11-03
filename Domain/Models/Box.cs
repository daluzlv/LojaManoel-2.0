namespace Domain.Models;

public class BoxSpace(int length, int width, int height)
{
    public int Length { get; set; } = length;
    public int Width { get; set; } = width;
    public int Height { get; set; } = height;
}

public class Box(string? boxId, int length, int width, int height, List<Product>? products = null)
{
    private readonly List<BoxSpace> _availableSpace = [new BoxSpace(length, width, height)];
    public string? BoxId { get; set; } = boxId;
    public List<Product> Products { get; set; }  = products ?? [];
    private string? _observation = null;
    public int Volume => _availableSpace.Sum(a => a.Height * a.Width * a.Length);

    public void AddObservation(string observation) => _observation = observation;

    public bool AddProduct(Product product)
    {
        var productRotations = product.GetRotations();
        foreach (var availableSpace in _availableSpace)
        {
            foreach (var (rotatedLength, rotatedWidth, rotatedHeight) in productRotations)
            {
                if (!FitsInSpace(availableSpace, rotatedLength, rotatedWidth, rotatedHeight)) continue;
                
                Products.Add(product);
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
