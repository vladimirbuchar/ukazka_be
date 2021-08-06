using Model.Functions.CourseStudent;
using Model.Functions.SendMessage;
using Model.Functions.StudentGroup;
using System;
using System.Collections.Generic;

namespace EduRepository.SendMessageRepository
{
    public interface IStudentGroupRepository : IBaseRepository
    {
        Guid AddStudentGroup(AddStudentGroup addStudentGroup);
        HashSet<GetStudentGroupInOrganization> GetStudentGroupInOrganization(Guid organizationId);
        void UpdateStudentGroup(UpdateStudentGroup updateStudentGroup);
        GetStudentGroupDetail GetStudentGroupDetail(Guid studentGroupId);
        void AddStudentToGroup(AddStudentToGroup addStudentToGroup);
        HashSet<GetAllStudentInGroup> GetAllStudentInGroup(Guid studenbtGroupId);
        HashSet<GetAllTermInGroup> GetAllTermInGroup(Guid studentGroupId);


    }
}
