namespace TaxiBook.Server.Features.Companies
{
    using TaxiBook.Server.Features.Companies.Models;

    public interface ICompanyService
    {
        Task<string> Create(string name, string description, string userId);

        Task<bool> Update(string id, string name, string description, string userId);

        Task<bool> Delete(string id, string userId);

        Task<IEnumerable<CompanyListingServiceModel>> ByUser(string userId);

        Task<CompanyDetailsServiceModel> Details(string id);
    }
}
