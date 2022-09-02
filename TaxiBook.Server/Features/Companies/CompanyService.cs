﻿namespace TaxiBook.Server.Features.Companies
{
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
    }
}