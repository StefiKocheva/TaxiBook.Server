namespace TaxiBook.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Server.Data;
    using TaxiBook.Server.Data.Models;
    using TaxiBook.Server.Infrastructure;
    using TaxiBook.Server.Models.Companies;

    public class CompaniesController : ApiController
    {
        private readonly TaxiBookDbContext data;

        public CompaniesController(TaxiBookDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateCompanyRequestModel model)
        {
            var userId = this.User.GetId();

            var company = new Company
            {
                Name = model.Name,
                Description = model.Description,
                UserId = userId,
            };

            this.data.Add(company);

            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), company.Id);
        }
    }
}
