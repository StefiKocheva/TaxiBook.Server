namespace TaxiBook.Server.Features.Profiles
{
    using Models;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);
    }
}
