using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
 public class CreateAboutCommandHandler
    { 
        private readonly IRepository<About> _aboutRepository;

        public CreateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        } 
        public async Task Handle(CreateAboutCommand createAbout)
        {
            await _aboutRepository.CreateAsync(new About { Title = createAbout.Title, Description = createAbout.Description, ImageUrl = createAbout.ImageUrl });
        }
    }
}
