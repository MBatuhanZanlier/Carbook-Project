using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
   public class GetBlogByAutorIdQuery:IRequest<GetBlogByAutorIdQueryResult>
    { 
        public int Id { get; set; }

        public GetBlogByAutorIdQuery(int id)
        {
            Id = id;
        }
    }
}
