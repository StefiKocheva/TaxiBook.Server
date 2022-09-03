namespace TaxiBook.Server.Features.Companies
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using TaxiBook.Server.Data;
    using TaxiBook.Server.Data.Models;
    using TaxiBook.Server.Features.Companies.Models;

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

        public async Task<bool> Update(string id, string name, string description, string userId)
        {
            var company = await this.data
                .Companies
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();

            if (company == null)
            {
                return false;
            }

            company.Name = name;
            company.Description = description;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CompanyListingServiceModel>> ByUser(string userId)
            => await this.data
                .Companies
                .Where(c => c.UserId == userId)
                .Select(c => new CompanyListingServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

        public async Task<CompanyDetailsServiceModel> Details(string id)
            => await this.data
                .Companies
                .Where(c => c.Id == id)
                .Select(c => new CompanyDetailsServiceModel
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Name = c.Name,
                    Description = c.Description,
                })
                .FirstOrDefaultAsync();
    }
}
