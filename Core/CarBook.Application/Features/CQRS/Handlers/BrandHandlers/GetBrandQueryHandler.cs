using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private IRepository<Brand> _reposiyory;

        public GetBrandQueryHandler(IRepository<Brand> reposiyory)
        {
            _reposiyory = reposiyory;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _reposiyory.GetAllAsync();
            return values.ToList().Select(v => new GetBrandQueryResult
            {
                BrandId = v.BrandId,
                Name = v.Name
            }).ToList();
        }
    }
}
