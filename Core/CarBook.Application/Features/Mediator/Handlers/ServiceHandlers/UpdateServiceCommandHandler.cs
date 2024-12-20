﻿using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _reposiyory;

        public UpdateServiceCommandHandler(IRepository<Service> reposiyory)
        {
            _reposiyory = reposiyory;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _reposiyory.GetByıdAsync(request.ServiceId);
            values.Description = request.Description;
            values.IcounUrl = request.IcounUrl;
            values.Title = request.Title;
           await _reposiyory.UpdateAsync(values);

        }
    }
}
