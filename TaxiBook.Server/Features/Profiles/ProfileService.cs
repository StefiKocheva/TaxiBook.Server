namespace TaxiBook.Server.Features.Profiles
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ProfileService : IProfileService
    {
        private readonly TaxiBookDbContext data;

        public ProfileService(TaxiBookDbContext data) => this.data = data;

        public async Task<ProfileServiceModel> ByUser(string userId)
            => await this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileServiceModel
                {
                   FirstName = u.Profile.FirstName,
                   LastName = u.Profile.LastName,
                   MainPhotoUrl = u.Profile.MainPhotoUrl
                })
                .FirstOrDefaultAsync();
    }
}
