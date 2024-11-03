using Domain.Dtos;

namespace Domain.Models;

public class Box
{
    public List<SpaceDTO> AvailableSpace { get; private set; }
    public List<Product> Products { get; set; }

    public Box(int length, int width, int height, List<Product>? products = null)
    {
        AvailableSpace = [new SpaceDTO(length, width, height)];
        Products = products ?? [];
    }

    
    public bool AddProduct(Product product)
    {
        var productRotations = product.GetRotations();
        foreach (var availableSpace in AvailableSpace)
        {
            foreach (var (rotatedLength, rotatedWidth, rotatedHeight) in productRotations)
            {
                if (!FitsInDimension(availableSpace, rotatedLength, rotatedWidth, rotatedHeight)) continue;
                
                Products.Add(product);
                UpdateAvailableSpace(availableSpace, product);
                return true;
            }
        }
        return false;
    }

    private static bool FitsInDimension(SpaceDTO space, int length, int width, int height) => 
        length <= space.Length && width <= space.Width && height <= space.Height;

    private void UpdateAvailableSpace(SpaceDTO space, Product product)
    {
        List<SpaceDTO> newDimensions = [];
        if (space.Length > product.Length)
            newDimensions.Add(new SpaceDTO(space.Length - product.Length, space.Width, space.Height));
        if (space.Width > product.Width)
            newDimensions.Add(new SpaceDTO(space.Length, space.Width - product.Width, space.Height));
        if (space.Height > product.Height)
            newDimensions.Add(new SpaceDTO(space.Length, space.Width, space.Height - product.Height));

        AvailableSpace.Remove(space);
        AvailableSpace.AddRange(newDimensions);
    }
}
