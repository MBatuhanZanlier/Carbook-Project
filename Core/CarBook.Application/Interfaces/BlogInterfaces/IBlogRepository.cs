

using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetBlogWithCategoryAndAuthor();
        List<Blog> GetLast3BlogWithAuthors();
        List<Blog> GetAllBlogsWithAuthors(); 
        Task <List<Blog>> GetAllBlogWithAuthorTake3(int id); 
        Task <Blog>  GetBlogByAutorId(int id);
    }
}
