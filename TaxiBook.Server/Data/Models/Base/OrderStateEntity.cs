namespace TaxiBook.Server.Data.Models.Base
{
    public class OrderStateEntity : IOrderStateEntity
    {
        public string? UnprocessedBy { get; set; }
        
        public string? ProcessedBy { get; set; }

        public string? AcceptedBy { get; set; }

        public string? UnacceptedBy { get; set; }

        public string? CanceledBy { get; set; }

        public string? RefusedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
