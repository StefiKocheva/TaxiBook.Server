namespace TaxiBook.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.User;

    public class Profile
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(MaxFirstNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxLastNameLength)]
        public string LastName { get; set; }

        public string MainPhotoUrl { get; set; }
    }
}
