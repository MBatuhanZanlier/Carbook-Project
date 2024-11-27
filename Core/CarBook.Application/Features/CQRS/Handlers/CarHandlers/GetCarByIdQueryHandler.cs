using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarGetByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByıdAsync(query.Id);
            return new GetCarGetByIdQueryResult
            {
                BrandId = values.BrandId,
                CoverImage = values.CoverImage,
                CarId = values.CarId,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission,
                BigImageUrl= values.BigImageUrl
               
            };
        }
    }
}
