using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPackageService
{
    List<Order> PackageProducts(IEnumerable<Order> orders);
}