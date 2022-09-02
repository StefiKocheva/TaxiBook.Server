﻿using System.Security.Claims;

namespace TaxiBook.Server.Infrastructure
{
    public static class IddentityExtentions
    {
        public static string GetId(this ClaimsPrincipal user) 
            => user
                .Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
    }
}
