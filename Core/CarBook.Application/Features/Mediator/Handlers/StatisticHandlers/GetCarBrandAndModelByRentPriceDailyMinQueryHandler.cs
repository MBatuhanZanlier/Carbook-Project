using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarBrandAndModelByRentPriceDailyMinQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetCarBrandAndModelByRentPriceDailyMin(); 
            return new GetCarBrandAndModelByRentPriceDailyMinQueryResult { CarBrandAndModelByRentPriceDailyMin = values };      
        }
    }
}
