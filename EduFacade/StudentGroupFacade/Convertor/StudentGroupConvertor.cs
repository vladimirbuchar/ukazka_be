using Model.Functions.CourseStudent;
using Model.Functions.SendMessage;
using System.Collections.Generic;
using System.Linq;
using WebModel.SendMessage;
using WebModel.Student;

namespace EduFacade.SendMessageFacade.Convertor
{
    public class StudentGroupConvertor : IStudentGroupConvertor
    {

        public StudentGroupConvertor()
        {

        }

        public HashSet<GetStudentGroupInOrganizationDto> ConvertToWebModel(HashSet<GetStudentGroupInOrganization> getStudentGroupInOrganizations)
        {
            return getStudentGroupInOrganizations.Select(x => new GetStudentGroupInOrganizationDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToHashSet();
        }

        public GetStudentGroupDetailDto ConvertToWebModel(GetStudentGroupDetail getStudentGroupDetail)
        {
            return new GetStudentGroupDetailDto()
            {
                Id = getStudentGroupDetail.Id,
                Name = getStudentGroupDetail.Name
            };
        }

        public HashSet<GetAllStudentInGroupDto> ConvertToWebModel(HashSet<GetAllStudentInGroup> getAllStudentInGroups)
        {
            return getAllStudentInGroups.Select(x => new GetAllStudentInGroupDto()
            {
                Email = x.UserEmail,
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                SecondName = x.SecondName,
                StudentId = x.StudentId
            }).ToHashSet();
        }

        public AddStudentGroup CovertToBussinessEntity(AddStudentGroupDto addStudentGroupDto)
        {
            return new AddStudentGroup()
            {
                Name = addStudentGroupDto.Name,
                OrganizationId = addStudentGroupDto.OrganizationId
            };
        }

        public UpdateStudentGroup CovertToBussinessEntity(UpdateStudentGroupDto updateStudentGroupDto)
        {
            return new UpdateStudentGroup()
            {

                Id = updateStudentGroupDto.Id,
                Name = updateStudentGroupDto.Name,

            };
        }
    }
}
