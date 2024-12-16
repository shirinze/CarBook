using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
        List<RentACar> GetByFilterAsync(Expression<Func<RentACar, bool>> filter);
    }
}
