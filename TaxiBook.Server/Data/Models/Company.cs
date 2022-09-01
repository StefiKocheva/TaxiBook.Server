namespace TaxiBook.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.Company;

    public class Company
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(MinDescriptionLength)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
