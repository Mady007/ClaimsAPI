using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsAPI.Definitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClaimsController : ControllerBase
	{
		private readonly IClaimsService claimsService;
		public ClaimsController(IClaimsService claimsService)
		{
			this.claimsService = claimsService;
		}

		[HttpGet]
		public async Task<IActionResult> GetClaims(DateTime dateOfService)
		{
			try
			{
				var memberClaims = await claimsService.GetMemberClaims(dateOfService);

				if(memberClaims == null || !memberClaims.Any())
				{
					//return NotFound($"Could not find claims for given date of service: {dateOfService.Date}");
					return Ok($"Could not find claims for given date of service: {dateOfService.Date}");
				}

				return Ok(memberClaims);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}
