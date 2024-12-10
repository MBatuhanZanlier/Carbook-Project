using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByFuelGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
    { 
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetCarCountByFuelGasolineOrDiesel(); 
            return new GetCarCountByFuelGasolineOrDieselQueryResult { CarCountByFuelGasolineOrDiesel = values };    
        }
    }
}
