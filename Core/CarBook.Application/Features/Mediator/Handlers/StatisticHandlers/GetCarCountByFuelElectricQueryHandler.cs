using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
    { 
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarCountByFuelElectricQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetCarCountByFuelElectric();
            return new GetCarCountByFuelElectricQueryResult
            {
                CarCountByFuelElectric=values,
            };
        }
    }
}
