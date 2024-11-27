using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _reposiyory;

        public GetCarQueryHandler(IRepository<Car> reposiyory)
        {
            _reposiyory = reposiyory;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _reposiyory.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                CarId = x.CarId,
                CoverImage = x.CoverImage,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                BrandId = x.BrandId,
                Transmission = x.Transmission, 
                BigImageUrl = x.BigImageUrl,
               

            }).ToList();
        }
    }
}
