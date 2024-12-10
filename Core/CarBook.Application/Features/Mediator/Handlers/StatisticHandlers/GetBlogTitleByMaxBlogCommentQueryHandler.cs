using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBlogTitleByMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResult>
    { 
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBlogTitleByMaxBlogCommentQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBlogTitleByMaxBlogCommentQueryResult> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
        {
            var values = _statisticsRepository.GetBlogTitleByMaxBlogComment();
            return new GetBlogTitleByMaxBlogCommentQueryResult
            {
                BlogTitleByMaxBlogComment = values
            };
        }
    }
}
