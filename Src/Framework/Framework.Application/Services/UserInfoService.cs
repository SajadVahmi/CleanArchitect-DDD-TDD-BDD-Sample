using Framework.Application.Extensions;
using Framework.Domain.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Services
{
    public class UserInfoService : IUserInfoService
    {

        private const string AccessList = "";

        private IHttpContextAccessor HttpContextAccessor { get; }
        public UserInfoService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        private HttpContext httpContext => HttpContextAccessor.HttpContext;
        public string GetUserAgent() => httpContext?.Request.Headers["User-Agent"];
        public string GetUserIp() => httpContext?.Connection?.RemoteIpAddress?.ToString();
        public Guid? UserId() => (httpContext?.User?.GetClaim(ClaimTypes.NameIdentifier) != null ? Guid.Parse(httpContext.User.GetClaim(ClaimTypes.NameIdentifier)) : null);
        public string GetUsername() => httpContext?.User?.GetClaim("username");
        public string GetFirstName() => httpContext?.User?.GetClaim(ClaimTypes.GivenName);
        public string GetLastName() => httpContext?.User?.GetClaim(ClaimTypes.Surname);
        public bool IsCurrentUser(string userId)
        {
            return string.Equals(UserId().ToString(), userId, StringComparison.OrdinalIgnoreCase);
        }

        public virtual bool HasAccess(string accessKey)
        {
            var result = false;

            if (!string.IsNullOrWhiteSpace(accessKey))
            {
                var accessList = httpContext.User?.GetClaim(AccessList)?.Split(',').ToList() ?? new List<string>();
                result = accessList.Any(key => string.Equals(key, accessKey, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public string GetSub() => httpContext?.User?.GetClaim("sub");
    }
}
