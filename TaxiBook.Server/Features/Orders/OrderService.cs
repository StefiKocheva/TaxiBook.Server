namespace TaxiBook.Server.Features.Orders
{
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Xml.Linq;
    using TaxiBook.Server.Data.Models.Enums;
    using TaxiBook.Server.Features.Companies.Models;
    using TaxiBook.Server.Features.Orders.Models;
    using TaxiBook.Server.Infrastructure.Services;
    using static TaxiBook.Server.Data.Vallidation;

    public class OrderService : IOrderService
    {
        private readonly TaxiBookDbContext data;

        public OrderService(TaxiBookDbContext data) => this.data = data;

        public async Task<string> Create(
            int? countOfPassengers, 
            string additionalRequirements, 
            string userId)
        {
            var order = new Data.Models.Order
            {
                CountOfPassengers = countOfPassengers,
                AdditionalRequirements = additionalRequirements,
            };

            this.data.Add(order);

            await this.data.SaveChangesAsync();

            return order.Id;
        }

        public async Task<Result> Delete(string id, string userId)
        {
            var order = await this.GetById(id);
            if (order == null)
            {
                return "This user cannot delete this order.";
            }

            this.data.Orders.Remove(order);

            await this.data.SaveChangesAsync();

            return true;
        }

        // by user
        public async Task<Result> Cancel(string id, string userId)
        {
            var order = await this.GetById(id);
            if (order == null)
            {
                return "This user cannot cancel this order.";
            }

            //add canceled by


            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<OrderDetailsServiceModel> Details(string id)
            => await this.data
                .Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDetailsServiceModel
                {
                    Id = o.Id,
                    ClientName = o.User.UserName,
                    CompanyName = o.Company.Name,
                    PhoneNumber = o.User.PhoneNumber,
                    AdditionalRequirements = o.AdditionalRequirements,
                    CountOfPassengers = o.CountOfPassengers,
                    OrderState = o.OrderState.ToString(),
                })
                .FirstOrDefaultAsync();

        public async Task<Result> Update(
            string id, 
            string additionalRequirements,
            int? countOfPassengers)
        {
            var order = await this.GetById(id);
            if (order == null)
            {
                return "This user cannot edit this order.";
            }

            order.AdditionalRequirements = additionalRequirements;
            order.CountOfPassengers = countOfPassengers;

            await this.data.SaveChangesAsync();

            return true;
        }


        //and by user
        private async Task<Data.Models.Order> GetById(string id)
            => await this.data
                .Orders
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}
