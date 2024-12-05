using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAutorIdQueryHandler : IRequestHandler<GetBlogByAutorIdQuery, GetBlogByAutorIdQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByAutorIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogByAutorIdQueryResult> Handle(GetBlogByAutorIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogByAutorId(request.Id);
            return new GetBlogByAutorIdQueryResult
            {
                AuthorID = values.AuthorID,
                AuthorDescription = values.Author.Description,
                AuthorImageUrl = values.Author.ImageUrl,
                AuthorName = values.Author.Name,
                BlogId = values.BlogId,

            };

        }
    }
}
