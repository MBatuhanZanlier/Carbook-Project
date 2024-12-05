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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _reposiory;

        public CreateBlogCommandHandler(IRepository<Blog> reposiory)
        {
            _reposiory = reposiory;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _reposiory.CreateAsync(new Blog
            {
                AuthorID = request.AuthorID, 
               CategoryID = request.CategoryID, 
               Title= request.Title, 
               CoverImageUrl = request.CoverImageUrl, 
               CreatedDate = request.CreatedDate
            });
                
        }
    }
}
