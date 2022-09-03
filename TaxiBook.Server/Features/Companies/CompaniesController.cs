namespace TaxiBook.Server.Features.Companies
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Server.Features.Companies.Models;
    using TaxiBook.Server.Infrastructure.Extensions;

    using static Infrastructure.WebConstants;

    [Authorize]
    public class CompaniesController : ApiController
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService) => this.companyService = companyService;

        [HttpGet]
        public async Task<IEnumerable<CompanyListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.companyService.ByUser(userId);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CompanyDetailsServiceModel>> Details(string id)
            => await this.companyService.Details(id);

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

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCompanyRequestModel model)
        {
            var userId = this.User.GetId();

            var updated = await this.companyService.Update(
                model.Id,
                model.Name,
                model.Description,
                userId);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(string id)
        {
            var userId = this.User.GetId();

            var deleted = await this.companyService.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
