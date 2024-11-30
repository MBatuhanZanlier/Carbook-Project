using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers
{
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync(); 
            return values.Select(x=> new GetFooterQueryResult
            {
                Address = x.Address, 
                Description = x.Description, 
                Email = x.Email, 
                FooterAddressId = x.FooterAddressId, 
                Phone=x.Phone
            }).ToList();
            
        }
    }
}