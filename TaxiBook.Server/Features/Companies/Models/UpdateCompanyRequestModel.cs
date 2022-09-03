﻿namespace TaxiBook.Server.Features.Companies.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Vallidation.Company;

    public class UpdateCompanyRequestModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(MinDescriptionLength)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
