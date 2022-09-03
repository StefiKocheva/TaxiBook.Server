namespace TaxiBook.Server.Features.Companies
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Server.Infrastructure;

    public class CompaniesController : ApiController
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService) => this.companyService = companyService;

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CompanyListingResponseModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.companyService.ByUser(userId);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateCompanyRequestModel model)
        {
            var userId = User.GetId();

            var id = await this.companyService.Create(
                model.Name, 
                model.Description, 
                userId);

            return Created(nameof(this.Create), id);
        }
    }
}
