namespace TaxiBook.Server.Features.Profiles
{
    using Data;
    using Data.Models;
    using Infrastructure.Services;
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

        public async Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string firstName, 
            string lastName, 
            string mainPhotoUrl)
        {
            var user = await this.data
                .Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(p => p.Id == userId);

            if (user == null)
            {
                return "User does not exist.";
            }

            if (user.Profile == null)
            {
                user.Profile = new Profile();
            }

            var result = await this.ChangeEmail(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            result = await this.ChangeUserName(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            this.ChangeProfile(
                user.Profile,
                firstName,
                lastName,
                mainPhotoUrl);

            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Result> ChangeEmail(User user,string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists)
                {
                    return "The provided e-mail is already taken.";
                }

                user.Email = email;
            }

            return true;
        }

        private async Task<Result> ChangeUserName(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExists)
                {
                    return "The provided user name is already taken.";
                }

                user.UserName = userName;
            }

            return true;
        }

        private void ChangeProfile(
            Profile profile,
            string firstName,
            string lastName,
            string mainPhotoUrl)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && profile.FirstName != firstName)
            {
                profile.FirstName = firstName;
            }

            if (!string.IsNullOrWhiteSpace(lastName) && profile.LastName != lastName)
            {
                profile.LastName = lastName;
            }

            if (!string.IsNullOrWhiteSpace(mainPhotoUrl) && profile.MainPhotoUrl != mainPhotoUrl)
            {
                profile.MainPhotoUrl = mainPhotoUrl;
            }
        }
    }
}
