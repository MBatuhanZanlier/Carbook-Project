using CarBook.Application.Features.Mediator.Commands.SoicalMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    { 
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByıdAsync(request.SocialMediaID);  
            values.Name = request.Name; 
            values.Url = request.Url; 
            values.Icon=request.Icon; 
            await _repository.UpdateAsync(values);
        }
    }
}
