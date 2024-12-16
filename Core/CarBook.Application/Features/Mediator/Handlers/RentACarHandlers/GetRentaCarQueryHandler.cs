using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentaCarQueryHandler : IRequestHandler<GetRentaCarQuery, List<GetRentACarResult>>
    { 
        private readonly IRentACarRepository _repository;

        public GetRentaCarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarResult>> Handle(GetRentaCarQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true); 
            return values.Select(x=> new GetRentACarResult
            {
                CarId=x.CarId,  
                Brand=x.Car.Brand.Name, 
                Model=x.Car.Model, 
                CoverImageUrl=x.Car.CoverImage
            }).ToList();
        }
    }
}
