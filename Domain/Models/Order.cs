namespace Domain.Models;

public class Order(int orderId, List<Product> products, List<Box> boxes)
{
    public int OrderId { get; set; } = orderId;
    public List<Product> Products { get; set; } = products;
    public List<Box> Boxes { get; set; } = boxes;
}