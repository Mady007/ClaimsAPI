using ClaimsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.Repository
{
	public class MemberClaimsContext
	{
		public IEnumerable<Claim> Claims { get; set; }

		public IEnumerable<Member> Members { get; set; }
	}
}
