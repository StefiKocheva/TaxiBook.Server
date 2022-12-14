namespace TaxiBook.Server.Features.Companies
{
    using Infrastructure.Services;
    using Models;

    public interface ICompanyService
    {
        Task<string> Create(string name, string description);

        Task<Result> Update(string id, string name, string description, string userId);

        Task<Result> Delete(string id, string userId);

        Task<IEnumerable<CompanyListingServiceModel>> ByUser(string userId);

        Task<CompanyDetailsServiceModel> Details(string id);
    }
}
