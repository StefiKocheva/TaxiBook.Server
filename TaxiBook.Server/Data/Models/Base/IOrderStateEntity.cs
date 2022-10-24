namespace TaxiBook.Server.Data.Models.Base
{
    public interface IOrderStateEntity : IDeletableEntity
    {
        string? UnprocessedBy { get; set; }
              
        string? ProcessedBy { get; set; }
              
        string? AcceptedBy { get; set; }
              
        string? UnacceptedBy { get; set; }
              
        string? CanceledBy { get; set; }
              
        string? RefusedBy { get; set; }
    }
}
