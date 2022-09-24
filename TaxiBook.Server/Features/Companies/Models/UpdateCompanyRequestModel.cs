namespace TaxiBook.Server.Features.Companies.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Vallidation.Company;

    public class UpdateCompanyRequestModel
    {
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MinLength(MinDescriptionLength)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
