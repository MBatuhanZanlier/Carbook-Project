using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories.ReviewRepositories
{
	public class ReviewRepository : IReviewRepository
	{ 
		private readonly CarbookContext _context;

		public ReviewRepository(CarbookContext context)
		{
			_context = context;
		}

		public List<Review> GetReviewByCarId(int id)
		{
			var values= _context.Reviews.Where(x=>x.CarID==id).ToList();	 
			return values; 
		}
	}
}
