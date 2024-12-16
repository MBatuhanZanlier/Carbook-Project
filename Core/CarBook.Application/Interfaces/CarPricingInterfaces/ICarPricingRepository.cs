using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarsWithPricings();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();
    }
}
