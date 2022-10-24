namespace TaxiBook.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;
    using Enums;

    using static Vallidation.Order;

    public class Order : DeletableEntity
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int? CountOfPassengers { get; set; }

        [MaxLength(MaxAdditionalRequirementsLength)]
        public string AdditionalRequirements { get; set; }

        public OrderState OrderState { get; set; }
    }
}
