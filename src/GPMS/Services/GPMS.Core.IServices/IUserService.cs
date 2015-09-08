using System;
using GPMS.Core.Entities;

namespace GPMS.Core.IServices
{
    public interface IUserService : IServiceBase<UserBasicInfo,Guid>
    {
        UserBasicInfo FindUserByName(string userName);
    }
}
