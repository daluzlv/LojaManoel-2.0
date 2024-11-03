using Domain.Interfaces;
using Domain.Models;

namespace Domain.Factories;

public class BoxFactory : IBoxFactory
{
    public Box CreateSmallBox() => new Box(30, 40, 80);
    public Box CreateBox() => new Box(80, 50, 40);
    public Box CreateLargeBox() => new Box(50, 80, 60);
}