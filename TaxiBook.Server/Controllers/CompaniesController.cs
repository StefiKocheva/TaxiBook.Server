namespace TaxiBook.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Server.Models.Companies;

    public class CompaniesController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateCompanyRequestModel model)
        {

        }
    }
}
