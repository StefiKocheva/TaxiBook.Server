namespace TaxiBook.Server.Features.Orders.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Vallidation.Order;

    public class CreateOrderRequestModel
    {
        public int? CountOfPassengers { get; set; }

        [MaxLength(MaxAdditionalRequirementsLength)]
        public string AdditionalRequirements { get; set; }
    }
}
