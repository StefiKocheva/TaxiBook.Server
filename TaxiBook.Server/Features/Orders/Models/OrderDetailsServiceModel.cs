namespace TaxiBook.Server.Features.Orders.Models
{
    using TaxiBook.Server.Data.Models.Enums;
    
    public class OrderDetailsServiceModel
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string ClientName { get; set; }

        public string PhoneNumber { get; set; }

        //public string CurrentLocation { get; set; }

        //public string EndLocation { get; set; }

        //public string CurrentLocationDetails { get; set; }

        //public string EndLocationDetails { get; set; }

        public int? CountOfPassengers { get; set; }

        public string AdditionalRequirements { get; set; }

        public string OrderState { get; set; }
    }
}
