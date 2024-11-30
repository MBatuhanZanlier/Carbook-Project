using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers
{
    public class RemoveFooterCommandHandler : IRequestHandler<RemoveFooterCommand>
    { 
        private readonly IRepository<FooterAddress> _repository;

        public RemoveFooterCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByıdAsync(request.Id); 
            await _repository.RemoveAsync(values);
        }
    }
}
