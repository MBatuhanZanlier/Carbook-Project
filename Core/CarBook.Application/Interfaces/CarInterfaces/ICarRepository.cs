using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarListWithBrands();
        List<Car> GetLast5CarsWithBrands();
     
        int GetCarCount();  
    }
}
