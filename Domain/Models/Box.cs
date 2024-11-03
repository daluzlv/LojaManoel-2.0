using Domain.Dtos;

namespace Domain.Models;

public class Box
{
    private readonly List<SpaceDTO> _availableSpace;
    private readonly List<Product> _products;
    public int Volume => _availableSpace.Sum(a => a.Height * a.Width * a.Length);

    public Box(int length, int width, int height, List<Product>? products = null)
    {
        _availableSpace = [new SpaceDTO(length, width, height)];
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

    private static bool FitsInSpace(SpaceDTO space, int length, int width, int height) => 
        length <= space.Length && width <= space.Width && height <= space.Height;

    private void UpdateAvailableSpace(SpaceDTO space, Product product)
    {
        List<SpaceDTO> newSpace = [];
        if (space.Length > product.Length)
            newSpace.Add(new SpaceDTO(space.Length - product.Length, space.Width, space.Height));
        if (space.Width > product.Width)
            newSpace.Add(new SpaceDTO(product.Length, space.Width - product.Width, space.Height));
        if (space.Height > product.Height)
            newSpace.Add(new SpaceDTO(product.Length, product.Width, space.Height - product.Height));

        _availableSpace.Remove(space);
        _availableSpace.AddRange(newSpace);
    }
}
