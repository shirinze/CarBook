using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListBrand();
        List<Car> GetLast5CarsWithBrand();
        
    }
}
