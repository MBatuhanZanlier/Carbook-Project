using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class CarDescriptionQueryHandler : IRequestHandler<CarDescriptionByIdQuery, CarDescriptionQueryResult>
	{
	private readonly ICarDescriptionRepository _carDescriptionRepository;

		public CarDescriptionQueryHandler(ICarDescriptionRepository carDescriptionRepository)
		{
			_carDescriptionRepository = carDescriptionRepository;
		}

		public async Task<CarDescriptionQueryResult> Handle(CarDescriptionByIdQuery request, CancellationToken cancellationToken)
		{
			var values = _carDescriptionRepository.GetCarDescription(request.Id);
			return new CarDescriptionQueryResult
			{
				CarDescriptionId = values.CarDescriptionId,
				CarId = values.CarId,
				Details = values.Details
			};
		}
	}
}
