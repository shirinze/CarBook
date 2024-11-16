using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Queries.BannerQuery
{
    public class GetBannerByIdQuery
    {
        public int Id { get; set; }

        public GetBannerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
