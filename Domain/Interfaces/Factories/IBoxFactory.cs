using Domain.Models;

namespace Domain.Interfaces.Factories;

public interface IBoxFactory
{
    int GetSmallBoxSize();
    int GetMediumBoxSize();
    int GetLargeBoxSize();
    Box CreateSmallBox();
    Box CreateMediumBox();
    Box CreateLargeBox();
}