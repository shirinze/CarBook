using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDeatilDtos
{
    public class ResultCarFeatureDetailDto
    {
        public int CarFeatureID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
