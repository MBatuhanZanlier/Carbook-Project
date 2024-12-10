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
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetAuthorCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetAuthorCount();
            return new GetAuthorCountQueryResult
            {
                GetAuthorCount = value
            };
        }
    }
}
