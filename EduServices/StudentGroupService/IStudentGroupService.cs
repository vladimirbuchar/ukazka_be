using Core.DataTypes;
using Model.Functions.CourseStudent;
using Model.Functions.SendMessage;
using Model.Functions.StudentGroup;
using System;
using System.Collections.Generic;

namespace EduServices.CertificateService
{
    public interface IStudentGroupService : IBaseService
    {
        Guid AddStudentGroup(AddStudentGroup addStudentGroup);
        HashSet<GetStudentGroupInOrganization> GetStudentGroupInOrganization(Guid organizationId);
        void UpdateStudentGroup(UpdateStudentGroup updateStudentGroup);
        void DeleteStudentGroup(Guid sendMessageId);
        GetStudentGroupDetail GetStudentGroupDetail(Guid sendMessageId);
        void AddStudentToGroup(AddStudentToGroup addStudentToGroup);
        HashSet<GetAllStudentInGroup> GetAllStudentInGroup(Guid studenbtGroupId);
        void DeleteStudentFromGroup(Guid studentId);
        void ValidateName(string name, Result result);
        HashSet<GetAllTermInGroup> GetAllTermInGroup(Guid studentGroupId);


    }
}
