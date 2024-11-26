﻿using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    { 
        private readonly IRepository<About> _aboutRepository;

        public RemoveAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        } 
        public async Task Handle(RemoveAboutCommand command)
        {
            var value= await _aboutRepository.GetByıdAsync(command.Id); 
           await _aboutRepository.RemoveAsync(value);
        }
    }
}
