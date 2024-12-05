using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetByIdWithAuthorTake3QueryHandler : IRequestHandler<GetByIdWithAuthorTake3Query, List<GetByIdWithAuthorTake3QueryResult>>
    {
        private readonly IBlogRepository _blogrepository;

        public GetByIdWithAuthorTake3QueryHandler(IBlogRepository blogrepository)
        {
            _blogrepository = blogrepository;
        }

        public async Task<List<GetByIdWithAuthorTake3QueryResult>> Handle(GetByIdWithAuthorTake3Query request, CancellationToken cancellationToken)
        {
            var values = await _blogrepository.GetAllBlogWithAuthorTake3(request.Id);
            return values.Select(x => new GetByIdWithAuthorTake3QueryResult
            {
                AuthorID = x.AuthorID, 
                AuthorName=x.Author.Name, 
                BlogId = x.BlogId, 
                CategoryID = x.CategoryID, 
                CoverImageUrl = x.CoverImageUrl, 
                CreatedDate = x.CreatedDate, 
                Title=x.Title,

            }).ToList();
        }
    }
}
