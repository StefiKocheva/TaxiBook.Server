namespace TaxiBook.Server.Data.Models.Enums
{
    public enum OrderState
    {
        Unprocessed = 0,
        Processed = 1,
        Accepted = 2,
        Unaccepted = 3,
        Canceled = 4,
        Refused = 5,
        Past = 6,
    }
}
