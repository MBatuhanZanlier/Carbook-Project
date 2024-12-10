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
    public class GetCarCountByKmSmallerThen1000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThen1000Query, GetCarCountByKmSmallerThen1000QueryResult>
    { 
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarCountByKmSmallerThen1000QueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarCountByKmSmallerThen1000QueryResult> Handle(GetCarCountByKmSmallerThen1000Query request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetCarCountByKmSmallerThen1000(); 
            return new GetCarCountByKmSmallerThen1000QueryResult { CarCountByKmSmallerThen1000 = values };
            
        }
    }
}
