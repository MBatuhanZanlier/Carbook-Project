using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository:IRentACarRepository
    { 
        private readonly CarbookContext _context;

        public RentACarRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<List<RentaCar>> GetByFilterAsync(Expression<Func<RentaCar, bool>> filter)
        {
            var values = await _context.RentaCars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }
    }
}
