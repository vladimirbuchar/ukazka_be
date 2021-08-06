using EduFacade.LinkLifeTimeRepository;
using System;

namespace EduServices.LinkLifeTimeService
{
    public class LinkLifeTimeService : BaseService, ILinkLifeTimeService
    {
        private readonly ILinkLifeTimeRepository _linkLifeTimeRepository;
        public LinkLifeTimeService(ILinkLifeTimeRepository linkLifeTimeRepository)
        {
            _linkLifeTimeRepository = linkLifeTimeRepository;
        }
        public Guid GenerateLinkLifeTime(Guid userId, int lifeTime)
        {
            return _linkLifeTimeRepository.SaveLink(userId, DateTime.Now.AddMinutes(lifeTime));
        }
    }
}
