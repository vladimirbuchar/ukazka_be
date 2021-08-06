using Core.DataTypes;
using EduRepository.SendMessageRepository;
using Model.Functions.CourseStudent;
using Model.Functions.SendMessage;
using Model.Functions.StudentGroup;
using Model.Tables.Link;
using System;
using System.Collections.Generic;

namespace EduServices.CertificateService
{
    public class StudentGroupService : BaseService, IStudentGroupService
    {
        private readonly IStudentGroupRepository _studentGroupRepository;
        public StudentGroupService(IStudentGroupRepository studentGroupRepository)
        {
            _studentGroupRepository = studentGroupRepository;
        }

        public Guid AddStudentGroup(AddStudentGroup addStudentGroup)
        {
            return _studentGroupRepository.AddStudentGroup(addStudentGroup);
        }

        public void AddStudentToGroup(AddStudentToGroup addStudentToGroup)
        {
            _studentGroupRepository.AddStudentToGroup(addStudentToGroup);
        }

        public void DeleteStudentFromGroup(Guid studentId)
        {
            _studentGroupRepository.DeleteEntity<StudentInGroup>(studentId);
        }

        public void DeleteStudentGroup(Guid studentGroupId)
        {
            _studentGroupRepository.DeleteEntity<Model.Tables.Edu.StudentGroup>(studentGroupId);
        }

        public HashSet<GetAllStudentInGroup> GetAllStudentInGroup(Guid studenbtGroupId)
        {
            return _studentGroupRepository.GetAllStudentInGroup(studenbtGroupId);
        }

        public HashSet<GetAllTermInGroup> GetAllTermInGroup(Guid studentGroupId)
        {
            return _studentGroupRepository.GetAllTermInGroup(studentGroupId);
        }

        public GetStudentGroupDetail GetStudentGroupDetail(Guid studentGroupId)
        {
            return _studentGroupRepository.GetStudentGroupDetail(studentGroupId);
        }

        public HashSet<GetStudentGroupInOrganization> GetStudentGroupInOrganization(Guid organizationId)
        {
            return _studentGroupRepository.GetStudentGroupInOrganization(organizationId);
        }

        public void UpdateStudentGroup(UpdateStudentGroup updateStudentGroup)
        {
            _studentGroupRepository.UpdateStudentGroup(updateStudentGroup);
        }

        public void ValidateName(string name, Result result)
        {
            if (string.IsNullOrEmpty(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "STUDENT_GROUP", "NAME_IS_EMPTY"));
            }
        }
    }
}
