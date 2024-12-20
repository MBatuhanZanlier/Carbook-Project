using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvaibleChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvaibleChangeToTrueCommand>
    { 
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureAvaibleChangeToTrueCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeatureAvaibleChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
