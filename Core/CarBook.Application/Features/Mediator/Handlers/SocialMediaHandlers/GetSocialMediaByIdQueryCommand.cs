using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryCommand : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaGetByIdResult>
    { 
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public GetSocialMediaByIdQueryCommand(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<GetSocialMediaGetByIdResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _socialMediaRepository.GetByıdAsync(request.Id);
            return new GetSocialMediaGetByIdResult
            {
               Icon=values.Icon, 
               Name=values.Name, 
               Url =values.Url, 
               SocialMediaID = values.SocialMediaID
            };
        }
    }
}
