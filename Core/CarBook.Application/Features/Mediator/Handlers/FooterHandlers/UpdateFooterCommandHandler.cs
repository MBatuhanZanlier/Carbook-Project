using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers
{
    public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
    { 
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByıdAsync(request.FooterAddressId); 
            values.Phone=request.Phone; 
            values.Address=request.Address;  
            values.Email=request.Email; 
            values.Description=request.Description; 
            await _repository.UpdateAsync(values);
        }
    }
}
