using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBookApplication.Interfaces.ReviewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReviewRepositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly CarBookContext _context;

		public ReviewRepository(CarBookContext context)
		{
			_context = context;
		}
		List<Review> IReviewRepository.GetReviewByCarId(int carId)
		{
			var value = _context.Reviews.Where(x => x.CarId == carId).ToList();
			return value;
		}
	}
}
