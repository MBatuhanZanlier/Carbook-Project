using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarbookContext _context;

        public CarPricingRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarsWithPricings()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(ı=>ı.PricingId ==2).ToList();
            return values;
        }
    }
}
