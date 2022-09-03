namespace TaxiBook.Server.Features.Companies
{
    using System.ComponentModel.DataAnnotations;

    using static TaxiBook.Server.Data.Vallidation.Company; 

    public class CompanyListingResponseModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }
    }
}
