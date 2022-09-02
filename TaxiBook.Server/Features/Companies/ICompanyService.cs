﻿namespace TaxiBook.Server.Features.Companies
{
    public interface ICompanyService
    {
        public Task<string> Create(string name, string description, string userId);
    }
}
