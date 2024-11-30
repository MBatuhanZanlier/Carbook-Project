using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryCommand : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    { 
        private readonly IRepository<Location> _locationRepository;

        public GetLocationByIdQueryCommand(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        { 
            var values=await _locationRepository.GetByıdAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
              LocationID= values.LocationID,    
              Name = values.Name
            };
        }
    }
}
