using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Services
{
    public interface IUserInfoService
    {
        string GetUserAgent();
        string GetUserIp();
        Guid? UserId();
        string GetSub();

        string GetFirstName();
        string GetLastName();
        string GetUsername();
        bool IsCurrentUser(string userId);
        bool HasAccess(string accessKey);
    }
}
