namespace TaxiBook.Server.Data.Models
{
    using Base;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IEntity
    {
        public Profile Profile { get; set; } 

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public IEnumerable<Company> Companies { get; } = new HashSet<Company>();
    }
}
