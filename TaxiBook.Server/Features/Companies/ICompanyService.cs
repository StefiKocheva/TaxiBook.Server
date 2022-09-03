namespace TaxiBook.Server.Features.Companies
{
    using TaxiBook.Server.Features.Companies.Models;

    public interface ICompanyService
    {
        public Task<string> Create(string name, string description, string userId);

        public Task<bool> Update(string id, string name, string description, string userId);

        public Task<bool> Delete(string id, string userId);

        public Task<IEnumerable<CompanyListingServiceModel>> ByUser(string userId);

        public Task<CompanyDetailsServiceModel> Details(string id);
    }
}
