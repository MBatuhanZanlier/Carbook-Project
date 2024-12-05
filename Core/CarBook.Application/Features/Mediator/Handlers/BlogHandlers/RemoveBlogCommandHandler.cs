using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
    { 
        private readonly IRepository<Blog> _blogRepository;

        public RemoveBlogCommandHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetByıdAsync(request.Id); 
            await _blogRepository.RemoveAsync(values);
        }
    }
}
