namespace TaxiBook.Server.Features.Companies
{
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    using static Infrastructure.WebConstants;

    [Authorize]
    public class CompaniesController : ApiController
    {
        private readonly ICompanyService companies;
        private readonly ICurrentUserService currentUser;

        public CompaniesController(
            ICompanyService companies,
            ICurrentUserService currentUser)
        {
            this.companies = companies;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyListingServiceModel>> Mine()
            => await this.companies.ByUser(this.currentUser.GetId());

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CompanyDetailsServiceModel>> Details(string id)
            => await this.companies.Details(id);

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateCompanyRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var id = await this.companies.Create(
                model.Name, 
                model.Description, 
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCompanyRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.companies.Update(
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
            var userId = this.currentUser.GetId();

            var deleted = await this.companies.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
