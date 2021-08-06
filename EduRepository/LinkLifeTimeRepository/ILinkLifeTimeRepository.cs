using EduRepository;
using System;

namespace EduFacade.LinkLifeTimeRepository
{
    public interface ILinkLifeTimeRepository : IBaseRepository
    {
        Guid SaveLink(Guid userId, DateTime endTime);
    }
}
