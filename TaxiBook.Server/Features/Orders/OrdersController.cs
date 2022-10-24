namespace TaxiBook.Server.Features.Orders
{
    using Companies.Models;
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Mvc;
    using Orders.Models;

    using static Infrastructure.WebConstants;

    public class OrdersController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IOrderService orders;

        public OrdersController(
            ICurrentUserService currentUser, 
            IOrderService orders)
        {
            this.currentUser = currentUser;
            this.orders = orders;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CompanyDetailsServiceModel>> Details(string id)
            => await this.orders.Details(id);

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateOrderRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var id = await this.orders.Create(
                model.CountOfPassengers,
                model.AdditionalRequirements,
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(string id, UpdateCompanyRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.orders.Update(
                id,
                model.Name,
                model.Description,
                userId);

            if (result.Failure)
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

            var result = await this.orders.Delete(id, userId);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
