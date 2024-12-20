using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    { 
       private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
           var values=  _carFeatureRepository.GetCarFeaturesByCarId(request.Id); 
            return values.Select(x=> new GetCarFeatureByCarIdQueryResult
            {
                Available=x.Available, 
                CarFeatureId=x.CarFeatureId, 
                FeatureID=x.FeatureID, 
                FeatureName=x.Feature.Name
            }).ToList();
        }
    }
}
