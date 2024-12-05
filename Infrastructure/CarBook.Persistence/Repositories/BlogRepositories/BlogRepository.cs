using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarbookContext _context;

        public BlogRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).Include(y => y.Category).ToList();
            return values;
        }

        public async Task<List<Blog>> GetAllBlogWithAuthorTake3(int id)
        {
            var values = await _context.Blogs
           .Where(x => x.AuthorID == id)
           .Include(z => z.Author)
           .OrderByDescending(k => k.CreatedDate)
           .Take(3)
           .ToListAsync();
            return values;
        }

        public async Task<Blog> GetBlogByAutorId(int id)
        {
            var values = await _context.Blogs.Where(x => x.BlogId == id).Include(z => z.Author).FirstOrDefaultAsync();
            return values;
                
        }

        public List<Blog> GetBlogWithCategoryAndAuthor()
        {
            var values = _context.Blogs.Include(x => x.Author).Include(y => y.Category).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(y => y.BlogId).Take(3).ToList();
            return values;
        }
    }
}
