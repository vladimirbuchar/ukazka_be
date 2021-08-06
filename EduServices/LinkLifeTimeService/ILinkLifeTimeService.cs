using System;

namespace EduServices.LinkLifeTimeService
{
    public interface ILinkLifeTimeService : IBaseService
    {
        Guid GenerateLinkLifeTime(Guid userId, int lifeTime);
    }
}
