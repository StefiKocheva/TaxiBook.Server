namespace TaxiBook.Server.Features.Companies
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using TaxiBook.Server.Data;
    using TaxiBook.Server.Data.Models;

    public class CompanyService : ICompanyService
    {
        private readonly TaxiBookDbContext data;

        public CompanyService(TaxiBookDbContext data) => this.data = data;

        public async Task<string> Create(string name, string description, string userId)
        {
            var company = new Company
            {
                Name = name,
                Description = description,
                UserId = userId,
            };

            data.Add(company);

            await this.data.SaveChangesAsync();

            return company.Id;
        }

        public async Task<IEnumerable<CompanyListingResponseModel>> ByUser(string userId)
            => await this.data
                .Companies
                .Where(c => c.UserId == userId)
                .Select(c => new CompanyListingResponseModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
    }
}
