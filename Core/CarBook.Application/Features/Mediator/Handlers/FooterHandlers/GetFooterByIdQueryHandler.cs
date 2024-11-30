using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers
{
    public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByıdAsync(request.Id);
            return new GetFooterByIdQueryResult
            {
                 Address=values.Address, 
                 Description=values.Description, 
                 Email=values.Email, 
                 FooterAddressId=values.FooterAddressId, 
                 Phone = values.Phone  
            };
        }
    }
}
