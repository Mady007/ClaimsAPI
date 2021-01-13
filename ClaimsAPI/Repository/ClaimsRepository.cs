using ClaimsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.Repository
{
	public class ClaimsRepository : IClaimsRepository
	{
		private readonly MemberClaimsContext memberClaimsContext;

		public ClaimsRepository(MemberClaimsContext memberClaimsContext)
		{
			this.memberClaimsContext = memberClaimsContext;
		}

		public async Task<List<MemberClaim>> GetMemberClaims(DateTime dateOfService)
		{
			var memberClaims = from c in memberClaimsContext.Claims
							 join m in memberClaimsContext.Members on c.MemberID equals m.MemberID
							 where c.ClaimDate.Date <= dateOfService.Date
							 select new MemberClaim()
							 {
								 ID = m.MemberID,
								 MemberID = c.MemberID,
								 FirstName = m.FirstName,
								 LastName = m.LastName,
								 EnrollmentDate = m.EnrollmentDate,
								 ClaimDate = c.ClaimDate,
								 ClaimAmount = c.ClaimAmount
							 };

			return await Task.FromResult(memberClaims?.ToList());
		}
	}
}
