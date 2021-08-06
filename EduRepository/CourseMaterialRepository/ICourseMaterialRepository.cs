using Model.Functions.SendMessage;
using System;
using System.Collections.Generic;

namespace EduRepository.SendMessageRepository
{
    public interface ICourseMaterialRepository : IBaseRepository
    {
        Guid AddCourseMaterial(AddCourseMaterial addCourseMaterial);
        HashSet<GetCourseMaterialInOrganization> GetCourseMaterialInOrganization(Guid organizationId);
        void UpdateCourseMaterial(UpdateCourseMaterial updateStudentGroup);
        GetCourseMaterialDetail GetCourseMaterialDetail(Guid courseMaterialId);
        HashSet<GetFiles> GetFiles(Guid courseMaterialId);



    }
}
