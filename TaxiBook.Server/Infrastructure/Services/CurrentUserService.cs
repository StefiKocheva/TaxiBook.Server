using System.Security.Claims;
using TaxiBook.Server.Infrastructure.Extensions;

namespace TaxiBook.Server.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
        }

        public string GetUserName()
            => this.user?.Identity?.Name;

        public string GetId()
            => this.user?.GetId();
    }
}
