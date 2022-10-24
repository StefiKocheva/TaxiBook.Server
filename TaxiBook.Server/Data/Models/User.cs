namespace TaxiBook.Server.Data.Models
{
    using Base;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IEntity
    {
        public Profile Profile { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public IEnumerable<Company> Companies { get; set; } = new HashSet<Company>();

        public IEnumerable<Order> Orders { get; set; } = new HashSet<Order>();

        public IEnumerable<Taxi> Taxies { get; set; } = new HashSet<Taxi>();
    }
}
