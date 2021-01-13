using ClaimsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.Repository
{
	public interface IClaimsRepository
	{
		Task<List<MemberClaim>> GetMemberClaims(DateTime dateOfService);
	}
}
