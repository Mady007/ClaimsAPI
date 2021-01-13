using ClaimsAPI.Models;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsAPI.Infrastructure
{
	public class MemberClaimsContextSeed
	{
		private readonly IConfigurationSection configurationSection;
		private readonly IWebHostEnvironment webHostEnvironment;

		public MemberClaimsContextSeed(IConfigurationSection configurationSection, IWebHostEnvironment webHostEnvironment)
		{
			this.configurationSection = configurationSection;
			this.webHostEnvironment = webHostEnvironment;
		}

		public List<Claim> GetCliamsFromFile()
		{
			var claimsFileName = configurationSection.GetValue<string>("ClaimFileName");
			var claimsFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "SeedData", claimsFileName);
			using var streamReader = new StreamReader(claimsFilePath);
			using var csvReader = new CsvReader(streamReader, culture: System.Globalization.CultureInfo.InvariantCulture);

			var claims = csvReader.GetRecords<Claim>()?.ToList();

			return claims;
		}

		public List<Member> GetMemberFromFile()
		{
			var membersFileName = configurationSection.GetValue<string>("MembersFileName");
			var memeberFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "SeedData", membersFileName);
			using var streamReader = new StreamReader(memeberFilePath);
			using var csvReader = new CsvReader(streamReader, culture: System.Globalization.CultureInfo.InvariantCulture);

			var members = csvReader.GetRecords<Member>()?.ToList();

			return members;
		}
	}
}
