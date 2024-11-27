using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
   public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        } 
        public async Task Handle(UpdateContactCommand command)
        {
            var values=await _repository.GetByıdAsync(command.ContactId); 
            values.SendDate=command.SendDate; 
            values.Subject=command.Subject; 
            values.Email=command.Email; 
            values.Message=command.Message; 
            values.Name=command.Name;  
            await _repository.UpdateAsync(values);

        }
    }
}
