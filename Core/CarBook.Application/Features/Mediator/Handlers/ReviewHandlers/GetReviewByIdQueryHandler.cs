using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, List<GetReviewByIdQueryResult>>
	{ 
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<List<GetReviewByIdQueryResult>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
		{
			var values = _reviewRepository.GetReviewByCarId(request.Id); 
			return values.Select(x=>new GetReviewByIdQueryResult
			{
				Comment=x.Comment, 
				CarID=x.CarID, 
				CustomerImage=x.CustomerImage, 
				CustomerName=x.CustomerName, 
				RaytingValue=x.RaytingValue, 
				ReviewDate=x.ReviewDate, 
				ReviewID=x.ReviewID
			}).ToList();
		}
	}
}
