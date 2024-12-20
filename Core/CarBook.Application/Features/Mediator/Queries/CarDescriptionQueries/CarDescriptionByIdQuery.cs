using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
	public class CarDescriptionByIdQuery:IRequest<CarDescriptionQueryResult>
	{ 
		public int Id { get; set; }

		public CarDescriptionByIdQuery(int id)
		{
			Id = id;
		}
	}
}
