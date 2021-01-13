using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.Models
{
	public class Claim
	{
		public int MemberID { get; set; }

		public decimal	ClaimAmount { get; set; }

		public DateTime ClaimDate { get; set; }
	}
}
