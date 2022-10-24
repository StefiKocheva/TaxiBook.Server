namespace TaxiBook.Server.Features.Orders
{
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Server.Features.Companies.Models;
    using TaxiBook.Server.Features.Orders.Models;
    using TaxiBook.Server.Infrastructure.Services;

    public interface IOrderService
    {
        Task<OrderDetailsServiceModel> Details(string id);

        Task<string> Create(
            int? countOfPassengers, 
            string additionalRequirements,
            string userId); 

        Task<Result> Update(
            string id, string name, string description, string userId);

        Task<Result> Delete(string id, string userId);
    }
}
