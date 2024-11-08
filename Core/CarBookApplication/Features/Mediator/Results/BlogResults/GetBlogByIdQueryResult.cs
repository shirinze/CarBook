using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Results.BlogResults
{
    public class GetBlogByIdQueryResult
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string AuthorID { get; set; }
        public Author Author { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
