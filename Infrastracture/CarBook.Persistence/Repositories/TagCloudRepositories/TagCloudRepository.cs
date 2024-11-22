using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBookApplication.Interfaces.TagCloudInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _context;

        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudByBlogId(int id)
        {
            var values = _context.TagClouds.Where(x => x.BlogId == id).ToList();
            return values;
        }
    }
}
