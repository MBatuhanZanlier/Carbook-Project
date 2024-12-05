using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetAllBlogsWithAuthors(); 
            return values.Select(x=>new GetAllBlogsWithAuthorQueryResult
            {  
                BlogId= x.BlogId, 
                CategoryID= x.CategoryID, 
                CreatedDate=x.CreatedDate,
                AuthorID = x.AuthorID, 
                AuthorName=x.Author.Name, 
                Title=x.Title, 
                CategoryName=x.Category.Name,  
               CoverImageUrl=x.CoverImageUrl, 
               Description=x.Description

            }).ToList();
        }
    }
}
