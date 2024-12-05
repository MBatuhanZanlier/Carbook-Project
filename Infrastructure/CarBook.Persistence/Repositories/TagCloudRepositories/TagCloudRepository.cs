using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    { 
        private readonly CarbookContext _context;

        public TagCloudRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogID(int id)
        { 
            var values=await _context.TagClouds.Where(x=>x.BlogId==id).ToListAsync();
            return values;
        }
    }
}
