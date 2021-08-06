using EduCore.DataTypes;
using EduFacade.OraganizationRoleFacade.Convertor;
using EduServices.OrganizationRoleService;
using System;
using WebModel.Organization;

namespace EduFacade.OraganizationRoleFacade
{
    public class OrganizationRoleFacade : BaseFacade, IOrganizationRoleFacade
    {
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly IOraganizationRoleConvertor _organizationRoleConvertor;
        public OrganizationRoleFacade(IOrganizationRoleService organizationRoleService, IOraganizationRoleConvertor organizationRoleConvertor)
        {
            _organizationRoleService = organizationRoleService;
            _organizationRoleConvertor = organizationRoleConvertor;
        }

        public bool CheckPermition(Guid userId, Guid organizationId, OperationType operationType)
        {
            return _organizationRoleService.CheckPermition(userId, organizationId, operationType);
        }

        public Guid GetOrganizationByAnswer(Guid answerId)
        {
            return _organizationRoleService.GetOrganizationByAnswer(answerId);
        }

        public Guid GetOrganizationByCertificateId(Guid certificateId)
        {
            return _organizationRoleService.GetOrganizationByCertificateId(certificateId);
        }

        public Guid GetOrganizationByCourseLesson(Guid courseLessonId)
        {
            return _organizationRoleService.GetOrganizationByCourseLesson(courseLessonId);
        }

        public Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId)
        {
            return _organizationRoleService.GetOrganizationByCourseLessonItem(courseLessonItemId);
        }

        public Guid GetOrganizationByCourseMaterial(Guid courseMaterialId)
        {
            return _organizationRoleService.GetOrganizationByCourseMaterial(courseMaterialId);
        }

        public Guid GetOrganizationBySendMessage(Guid sendMessageId)
        {
            return _organizationRoleService.GetOrganizationBySendMessage(sendMessageId);
        }

        public Guid GetOrganizationByStudentGroupId(Guid studentGroupId)
        {
            return _organizationRoleService.GetOrganizationByStudentGroupId(studentGroupId);
        }

        public Guid GetOrganizationByStudentId(Guid studentId)
        {
            return _organizationRoleService.GetOrganizationByStudentId(studentId);
        }

        public Guid GetOrganizationByUserInOrganization(Guid userInOrganizationId)
        {
            return _organizationRoleService.GetOrganizationByUserInOrganization(userInOrganizationId);
        }

        public Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId)
        {
            return _organizationRoleService.GetOrganizationIdByBankOfQuestion(bankOfQuestionId);
        }

        public Guid GetOrganizationIdByBranch(Guid branchId)
        {
            return _organizationRoleService.GetOrganizationIdByBranch(branchId);
        }

        public Guid GetOrganizationIdByClassRoom(Guid classRoomId)
        {
            return _organizationRoleService.GetOrganizationIdByClassRoom(classRoomId);
        }

        public Guid GetOrganizationIdByCourse(Guid courseId)
        {
            return _organizationRoleService.GetOrganizationIdByCourseId(courseId);
        }

        public Guid GetOrganizationIdByCourseTerm(Guid termId)
        {
            return _organizationRoleService.GetOrganizationIdByTermId(termId);
        }

        public Guid GetOrganizationIdByQuestion(Guid questionId)
        {
            return _organizationRoleService.GetOrganizationIdByQuestion(questionId);
        }
        public GetUserOrganizationRoleDto GetUserOrganizationRole(Guid userId, Guid organizationId)
        {
            return _organizationRoleConvertor.ConvertToWebModel(_organizationRoleService.GetUserOrganizationRole(userId, organizationId));
        }
    }
}
