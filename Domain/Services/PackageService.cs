using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services;

public class PackageService(IBoxFactory boxFactory) : IPackageService
{
    public (List<Box> boxes, List<Product> unpackedProducts) PackageProducts(List<Product> products)
    {
        var sortedProducts = products.OrderByDescending(p => p.Volume).ToList();
        var boxes = new List<Box>();
        var unpackedProducts = new List<Product>();
        
        var smallBoxSize = boxFactory.GetSmallBoxSize();
        var mediumBoxSize = boxFactory.GetMediumBoxSize();
        
        var remainingVolume = sortedProducts.Sum(p => p.Volume);
        
        foreach (var product in sortedProducts)
        {
            if (ShouldAddNewBox(boxes, product))
                AddNewBox(boxes, remainingVolume, smallBoxSize, mediumBoxSize);

            var isPacked = boxes.Any(box => box.AddProduct(product));

            if (!isPacked)
                unpackedProducts.Add(product);
            
            remainingVolume -= product.Volume;
        }

        return (boxes, unpackedProducts);
    }
    
    private static bool ShouldAddNewBox(List<Box> boxes, Product product) =>
        boxes.All(b => b.Volume < product.Volume);
    
    private void AddNewBox(List<Box> boxes, int remainingVolume, int smallBoxVolume, int mediumBoxVolume)
    {
        if (remainingVolume > mediumBoxVolume) boxes.Add(boxFactory.CreateLargeBox());
        else if (remainingVolume > smallBoxVolume) boxes.Add(boxFactory.CreateMediumBox());
        else boxes.Add(boxFactory.CreateSmallBox());
    }
}