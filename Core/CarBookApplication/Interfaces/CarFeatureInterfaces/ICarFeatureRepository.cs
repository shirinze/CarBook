using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeatureByCarId(int CarID);
        void ChangeCarFeatureAvailableToTrue(int id);
        void ChangeCarFeatureAvailableToFalse(int id);
    }
}
