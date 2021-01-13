using ClaimsAPI.DTO;
using ClaimsAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimsAPI.Definitions
{
	public interface IClaimsService
	{
		Task<List<MemberClaimsDto>> GetMemberClaims(DateTime dateOfService);
	}
}