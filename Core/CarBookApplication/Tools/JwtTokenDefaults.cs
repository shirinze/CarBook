using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience = "https://localhost";
		public const string ValidIssuer = "http://localhost";
		public const string Key = "CarbOOK01*@#%CarBook01carbookk+++++*!!!!!!";
		public const int Expire = 3;
	}
}
