using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.Models
{
	public class MemberClaim
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public int MemberID { get; set; }

		public decimal ClaimAmount { get; set; }

		public DateTime ClaimDate { get; set; }
	}
}
