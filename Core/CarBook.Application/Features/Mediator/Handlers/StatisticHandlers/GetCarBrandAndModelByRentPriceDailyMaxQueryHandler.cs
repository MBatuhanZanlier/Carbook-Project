using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarBrandAndModelByRentPriceDailyMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
    { 
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarBrandAndModelByRentPriceDailyMaxQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetCarBrandAndModelByRentPriceDailyMax();
            return new GetCarBrandAndModelByRentPriceDailyMaxQueryResult { GetCarBrandAndModelByRentPriceDailyMax = values };
        }
    }
}
