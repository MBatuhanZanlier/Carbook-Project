using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _carRepository.GetCarListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                CarId = x.CarId,
                CoverImage = x.CoverImage,
                BrandName = x.Brand.Name,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
