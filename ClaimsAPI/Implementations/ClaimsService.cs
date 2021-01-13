using ClaimsAPI.Definitions;
using ClaimsAPI.DTO;
using ClaimsAPI.Models;
using ClaimsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.Implementations
{
	public class ClaimsService : IClaimsService
	{
		private readonly IClaimsRepository claimsRepository;

		public ClaimsService(IClaimsRepository claimsRepository)
		{
			this.claimsRepository = claimsRepository;
		}
		public async Task<List<MemberClaimsDto>> GetMemberClaims(DateTime dateOfService)
		{
			var memberClaims = await claimsRepository.GetMemberClaims(dateOfService);
			var memberClaimsDto = Map(memberClaims);

			return memberClaimsDto;
		}

		/// <summary>
		/// Mapping from list of member claims model to member claims DTO structure where a Member contains list of claims.
		/// </summary>
		/// <param name="memberClaims"></param>
		/// <returns></returns>
		private List<MemberClaimsDto> Map(IEnumerable<MemberClaim> memberClaims)
		{
			var memberClaimsDtoGroup = memberClaims.GroupBy(x => new	{ x.MemberID, x.FirstName, x.LastName, x.EnrollmentDate })
						 .Select((group) => new MemberClaimsDto() {
													  MemberID = group.Key.MemberID,
													  FirstName = group.Key.FirstName,
													  LastName = group.Key.LastName,
													  EnrollmentDate = group.Key.EnrollmentDate,
													  Claims = group.Select(x => new ClaimsDto { 
														 ClaimAmount = x.ClaimAmount,
														 ClaimDate = x.ClaimDate,
														 MemberID = x.MemberID
													  })?.ToList()
												  })?.ToList();

			return memberClaimsDtoGroup;
			
		}
	}
}
