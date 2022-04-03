using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)
        {
            return userClaimsPrincipal.Claims.FirstOrDefault((x) => x.Type == claimType)?.Value;
        }
    }
}
