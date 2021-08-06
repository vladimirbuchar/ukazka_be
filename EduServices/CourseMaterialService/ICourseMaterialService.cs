using Core.DataTypes;
using Model.Functions.SendMessage;
using System;
using System.Collections.Generic;

namespace EduServices.CertificateService
{
    public interface ICourseMaterialService : IBaseService
    {
        Guid AddCourseMaterial(AddCourseMaterial addCourseMaterial);
        HashSet<GetCourseMaterialInOrganization> GetCourseMaterialInOrganization(Guid organizationId);
        void UpdateCourseMaterial(UpdateCourseMaterial updateCourseMaterial);
        void DeleteCourseMaterial(Guid courseMaterialId);
        GetCourseMaterialDetail GetCourseMaterialDetail(Guid courseMaterialId);
        void ValidateName(string name, Result result);
        HashSet<GetFiles> GetFiles(Guid courseMaterialId);
    }
}
