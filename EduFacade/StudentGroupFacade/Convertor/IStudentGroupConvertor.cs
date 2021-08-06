using Model.Functions.CourseStudent;
using Model.Functions.SendMessage;
using System.Collections.Generic;
using WebModel.SendMessage;
using WebModel.Student;

namespace EduFacade.SendMessageFacade.Convertor
{
    public interface IStudentGroupConvertor
    {
        AddStudentGroup CovertToBussinessEntity(AddStudentGroupDto addStudentGroupDto);
        HashSet<GetStudentGroupInOrganizationDto> ConvertToWebModel(HashSet<GetStudentGroupInOrganization> getStudentGroupInOrganizations);
        UpdateStudentGroup CovertToBussinessEntity(UpdateStudentGroupDto updateStudentGroupDto);
        GetStudentGroupDetailDto ConvertToWebModel(GetStudentGroupDetail getStudentGroupDetail);
        HashSet<GetAllStudentInGroupDto> ConvertToWebModel(HashSet<GetAllStudentInGroup> getAllStudentInGroups);
    }

}
