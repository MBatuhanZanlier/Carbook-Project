using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        public IRepository<TagCloud> _repository;

        public UpdateTagCloudHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        { 
            var values=await _repository.GetByıdAsync(request.TagCloudId); 
            values.Title = request.Title; 
            values.BlogId = request.BlogId; 
            await _repository.UpdateAsync(values);
        }
    }
}
