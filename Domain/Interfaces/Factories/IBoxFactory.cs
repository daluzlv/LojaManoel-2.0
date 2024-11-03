using Domain.Models;

namespace Domain.Interfaces;

public interface IBoxFactory
{
    Box CreateBox();
    Box CreateSmallBox();
    Box CreateLargeBox();
}