using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBookApplication.Interfaces.RentACarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _context;

        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<RentACar> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = _context.RentACars.Where(filter);
            return values.ToList();
        }
    }
}
