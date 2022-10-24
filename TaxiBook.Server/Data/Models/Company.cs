namespace TaxiBook.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    using static Vallidation.Company;

    public class Company : DeletableEntity
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(MinDescriptionLength)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public IEnumerable<User> Employees { get; set; } = new HashSet<User>();

        public IEnumerable<Taxi> Taxies { get; set; } = new HashSet<Taxi>();

        public IEnumerable<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
