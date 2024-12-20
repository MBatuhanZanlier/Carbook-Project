using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvaibleChangeToFalseCommandHandler:IRequestHandler<UpdateCarFeatureAvaibleChangeToFalseCommand>
    { 
      private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureAvaibleChangeToFalseCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeatureAvaibleChangeToFalseCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.ChangeCarFeatureAvailableToFalse(request.Id); 

        }
    }
}
