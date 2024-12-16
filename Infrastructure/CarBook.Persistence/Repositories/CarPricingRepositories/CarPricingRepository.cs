using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
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

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select  Brands.Name, Model, CoverImage, PricingId, Amount From CarPricings Inner Join Cars on Cars.CarId = CarPricings.CarId Inner Join Brands On Brands.BrandId = Cars.BrandId) As SourceTable Pivot (Sum(Amount) For PricingID In ([2], [3], [4])) as PivotTable";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImage = reader["CoverImage"].ToString(),
                            Amounts = new List<decimal>
                    {
                        // DBNull kontrolü ekledik
                        reader["2"] != DBNull.Value ? Convert.ToDecimal(reader["2"]) : 0.0m,  // Varsayılan değer 0.0m
                        reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0.0m,
                        reader["4"] != DBNull.Value ? Convert.ToDecimal(reader["4"]) : 0.0m
                    }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }


        public List<CarPricing> GetCarsWithPricings()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).ToList();
            return values;
        }
    }
}
