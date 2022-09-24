namespace TaxiBook.Server.Features.Profiles
{
    using Infrastructure.Services;
    using Models;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);

        Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string firstName, 
            string lastName, 
            string mainPhotoUrl);
    }
}
