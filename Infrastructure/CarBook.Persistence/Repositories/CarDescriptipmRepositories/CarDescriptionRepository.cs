using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repositories.CarDescriptipmRepositories
{
	public class CarDescriptionRepository : ICarDescriptionRepository
	{ 
		private readonly CarbookContext _context;

		public CarDescriptionRepository(CarbookContext context)
		{
			_context = context;
		}

		public CarDescription GetCarDescription(int id)
		{
		     var values= _context.CarDescriptions.Where(x=>x.CarId==id).FirstOrDefault();
			return values;
		}
	}
}
