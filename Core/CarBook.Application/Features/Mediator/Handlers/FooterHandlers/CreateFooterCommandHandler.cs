using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers
{
    public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand >
    { 
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        { 
            await _repository.CreateAsync(new FooterAddress { Address = request.Address, Description=request.Description,Email=request.Email,Phone=request.Phone });
        }
    }
}
