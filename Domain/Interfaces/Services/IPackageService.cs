using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPackageService
{
    (List<Box> boxes, List<Product> unpackedProducts) PackageProducts(List<Product> products);
}