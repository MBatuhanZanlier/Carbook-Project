using CarBook.Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewByIdQuery:IRequest<List<GetReviewByIdQueryResult>>
	{ 
		public int Id { get; set; }

		public GetReviewByIdQuery(int id)
		{
			Id = id;
		}
	}
}
