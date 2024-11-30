using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {

        private readonly IRepository<Pricing> _repositor;

        public RemovePricingCommandHandler(IRepository<Pricing> repositor)
        {
            _repositor = repositor;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repositor.GetByıdAsync(request.Id); 
            await _repositor.RemoveAsync(values);
        }
    }
}
