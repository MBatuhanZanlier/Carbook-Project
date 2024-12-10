using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAvgRentPriceForDailyQueryHandler : IRequestHandler<GetAvgRentPriceForDailyQuery, GetAvgRentPriceForDailyQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetAvgRentPriceForDailyQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetAvgRentPriceForDailyQueryResult> Handle(GetAvgRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetAvgRentPriceForDaily();
            return new GetAvgRentPriceForDailyQueryResult
            {
                AvgRentPriceForDaily = values
            };
        }
    }
}
