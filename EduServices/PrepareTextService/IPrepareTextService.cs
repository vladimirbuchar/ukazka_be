using System;

namespace EduServices.PrepareTextService
{
    public interface IPrepareTextService
    {
        string PrepareText(string text, Guid userId, Guid organizationId, Guid courseId, Guid courseTermId);
    }
}
