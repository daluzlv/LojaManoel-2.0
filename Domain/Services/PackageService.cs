using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services;

public class PackageService(IBoxFactory boxFactory) : IPackageService
{
    public List<Order> PackageProducts(IEnumerable<Order> orders)
    {
        var sortedOrders = orders.OrderByDescending(o => o.Products.Sum(p => p.Volume));
        var packedOrders = new List<Order>();
        
        var smallBoxSize = boxFactory.GetSmallBoxSize();
        var mediumBoxSize = boxFactory.GetMediumBoxSize();
        

        foreach (var order in sortedOrders)
        {
            var remainingVolume = order.Products.Sum(p => p.Volume);
            var boxes = new List<Box>();
            
            PackOrderProducts(order, boxes, remainingVolume, smallBoxSize, mediumBoxSize);
            
            packedOrders.Add(new Order(order.OrderId, [], boxes));
        }

        return packedOrders;
    }

    private void PackOrderProducts(Order order, List<Box> boxes, int remainingVolume, int smallBoxSize, int mediumBoxSize)
    {
        foreach (var product in order.Products)
        {
            if (ShouldAddNewBox(boxes, product))
                AddNewBox(boxes, remainingVolume, smallBoxSize, mediumBoxSize);

            var isPacked = boxes.Any(box => box.AddProduct(product));
            if (!isPacked)
            {
                var lastBox = boxes.LastOrDefault()!;
                lastBox.BoxId = null;
                lastBox.Products = [product];
                lastBox.AddObservation("Produto não cabe em nenhuma caixa disponível.");
            }

            remainingVolume -= product.Volume;
        }
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