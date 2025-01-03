using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Interfaces.CarDescriptionInterfaces
{
	public interface ICarDescriptionRepository
	{
		CarDescription GetCarDescriptionByCarId(int carId);
	}
}
