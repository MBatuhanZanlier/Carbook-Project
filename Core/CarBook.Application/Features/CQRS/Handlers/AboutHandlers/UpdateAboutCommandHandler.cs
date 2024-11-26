using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    { 
        private readonly IRepository<About> _aboutRepository;

        public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        } 
        public async Task Handle(UpdateAboutCommand command)
        {
            var values=await _aboutRepository.GetByıdAsync(command.AboutId); 
            values.Description = command.Description; 
            values.Title=command.Title; 
            values.ImageUrl=command.ImageUrl; 
            await _aboutRepository.UpdateAsync(values);
        }
    }
}
