using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade
{
    public interface ICourseMaterialFacade : IBaseFacade
    {
        Result AddCourseMaterial(AddCourseMaterialDto addCourseMaterialDto);
        HashSet<GetCourseMaterialInOrganizationDto> GetCourseMaterialInOrganization(Guid organizationId);
        Result UpdateCourseMaterial(UpdateCourseMaterialDto updateCourseMaterialDto);
        void DeleteCourseMaterial(Guid courseMaterialId);
        GetCourseMaterialDetailDto GetCourseMaterial(Guid courseMaterialId);
        HashSet<GetFilesDto> GetFiles(Guid courseMaterialId);
        HashSet<GetFilesDto> GetFilesStudent(Guid courseId);
    }
}
