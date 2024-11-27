using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _reposiyory;

        public GetContactByIdQueryHandler(IRepository<Contact> reposiyory)
        {
            _reposiyory = reposiyory;
        } 

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery command)
        {
            var values= await _reposiyory.GetByıdAsync(command.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Email=values.Email,  
                Message=values.Message, 
                Name=values.Name, 
                SendDate=values.SendDate, 
                Subject=values.Subject
            };
        }
    }
}
