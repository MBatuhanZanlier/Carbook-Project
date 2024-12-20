﻿using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    { 
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values =_carPricingRepository.GetCarsWithPricings();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
               Amount = x.Amount,  
               Brand=x.Car.Brand.Name, 
               CoverImageUrl=x.Car.CoverImage, 
               Model=x.Car.Model,  
               CarPricingId=x.CarPricingId, 
               CarId=x.CarId

            }).ToList();
        }
    }
}
