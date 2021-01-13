using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.DTO
{
	public class MemberClaimsDto
	{
		public int MemberID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime EnrollmentDate { get; set; }
		
		public List<ClaimsDto> Claims { get; set; }
	}
}
