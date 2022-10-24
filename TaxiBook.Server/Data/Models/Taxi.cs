namespace TaxiBook.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    public class Taxi : DeletableEntity
    {
        public Taxi()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string DriverId { get; set; }

        public virtual User Driver { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string NumberPlate { get; set; }

        public bool IsBusy { get; set; }
    }
}
