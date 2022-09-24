namespace TaxiBook.Server.Features.Profiles.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Vallidation.User;

    public class UpdateProfileRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        [MaxLength(MaxFirstNameLength)]
        public string FirstName { get; set; }

        [MaxLength(MaxLastNameLength)]
        public string LastName { get; set; }

        public string MainPhotoUrl { get; set; }
    }
}
