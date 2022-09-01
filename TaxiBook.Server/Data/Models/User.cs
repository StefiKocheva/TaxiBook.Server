namespace TaxiBook.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public IEnumerable<Company> Companies { get; } = new HashSet<Company>();
    }
}
