using CarBook.Domain.Entities;
using System.Linq.Expressions;

namespace CarBook.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
       Task<List<RentaCar>> GetByFilterAsync(Expression<Func<RentaCar, bool>> filter);
    }
}
