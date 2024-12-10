using CarBook.Application.Features.RepositoryPattern.CommentRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : Application.Features.RepositoryPattern.CommentRepositories.CommentRepository<Comment>
    { 
        private readonly CarbookContext _context;

        public CommentRepository(CarbookContext context)
        {
            _context = context;
        }

        public  void Create(Comment entity)
        {
          _context.Comments.Add(entity); 
        _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
           return _context.Comments.Select(x=> new Comment
           {
               CommentId = x.CommentId, 
               BlogId = x.BlogId, 
               CreatedDate = x.CreatedDate, 
               Description = x.Description, 
               Name = x.Name
           }).ToList();
        }

        public Comment GetById(int id)
        {
           return _context.Comments.Find(id);
           
        }

        public List<Comment> GetCommentsByBlog(int id)
        {
          return _context.Set<Comment>().Where(x=>x.BlogId == id).ToList();
        }

        public void Remove(Comment entity)
        {
            var values = _context.Comments.Find(entity.CommentId);
          _context.Comments.Remove(values); 
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity); 
            _context.SaveChanges();
        }
       
    }
}
