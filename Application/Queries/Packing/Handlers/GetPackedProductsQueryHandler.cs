using Application.DTOs;
using Application.Queries.Packing.Queries;
using Domain;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Queries.Packing.Handlers;

public class GetPackedProductsQueryHandler(IPackageService service)
{
    public IEnumerable<OrderResponseDto> Handle(GetPackedProductsQuery query)
    {
        var orders = query.Orders.Select(ToOrder).ToList();
        var packedOrders = service.PackageProducts(orders).Select(ToOrderResponseDto).ToList();
        return packedOrders.OrderBy(p => p.OrderId);
    }

    private static Order ToOrder(OrderDto orderDto)
    {
        var products = orderDto.Products.Select(ToProduct).ToList();
        return new Order(orderDto.OrderId, products, []);
    }

    private static Product ToProduct(ProductRequestDto productRequestDto) =>
        new Product(productRequestDto.ProductId, productRequestDto.Space.Length, productRequestDto.Space.Height, productRequestDto.Space.Width);

    private static OrderResponseDto ToOrderResponseDto(Order order)
    {
        var boxes = order.Boxes.Select(ToBoxResponseDto).ToList();
        return new OrderResponseDto(order.OrderId, boxes);
    }

    private static BoxResponseDto ToBoxResponseDto(Box box)
    {
        var productIds = box.Products.Select(product => product.ProductId).ToList();
        return new BoxResponseDto(box.BoxId!, productIds);
    }
}