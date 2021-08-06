using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.SendMessage;
using WebModel.Student;

namespace EduFacade.SendMessageFacade
{
    public interface IStudentGroupFacade : IBaseFacade
    {
        Result AddStudentGroup(AddStudentGroupDto addSendMessageDto);
        HashSet<GetStudentGroupInOrganizationDto> GetStudentGroupInOrganization(Guid organizationId);
        Result UpdateStudentGroup(UpdateStudentGroupDto updateSendMessageDto);
        void DeleteStudentGroup(Guid sendMessageId);
        GetStudentGroupDetailDto GetStudentGroupDetail(Guid sendMessageId);
        Result AddStudentToGroup(AddStudentToGroupDto addStudentToGroupDto, Guid organizationId);
        HashSet<GetAllStudentInGroupDto> GetAllStudentInGroup(Guid studenbtGroupId);
        void DeleteStudentFromGroup(Guid studentId, Guid studentGroupId);
    }
}
