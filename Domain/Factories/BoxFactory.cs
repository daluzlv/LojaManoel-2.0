using Domain.Interfaces.Factories;
using Domain.Models;

namespace Domain.Factories;

public class BoxFactory : IBoxFactory
{
    public int GetSmallBoxSize() => 30 * 40 * 80;
    public int GetMediumBoxSize() => 80 * 50 * 40;
    public int GetLargeBoxSize() => 50 * 80 * 60;
    public Box CreateSmallBox() => new Box(30, 40, 80);
    public Box CreateMediumBox() => new Box(80, 50, 40);
    public Box CreateLargeBox() => new Box(50, 80, 60);
}