using EduCore.DataTypes;
using System;
using WebModel.Organization;

namespace EduFacade.OraganizationRoleFacade
{
    public interface IOrganizationRoleFacade : IBaseFacade
    {
        /// <summary>
        /// check user permition
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="organizationId"></param>
        /// <param name="operationType"></param>
        /// <returns></returns>
        bool CheckPermition(Guid userId, Guid organizationId, OperationType operationType);
        /// <summary>
        /// return organization id by branch
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByBranch(Guid branchId);
        /// <summary>
        /// return organization id by class room
        /// </summary>
        /// <param name="classRoomId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByClassRoom(Guid classRoomId);
        /// <summary>
        /// retrun organization id by course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByCourse(Guid courseId);
        /// <summary>
        /// return organization id by course term
        /// </summary>
        /// <param name="termId"></param>
        /// <returns></returns>
        Guid GetOrganizationIdByCourseTerm(Guid termId);
        Guid GetOrganizationByUserInOrganization(Guid userInOrganizationId);
        Guid GetOrganizationByCourseLesson(Guid courseLessonId);
        Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId);
        Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId);
        Guid GetOrganizationIdByQuestion(Guid questionId);
        Guid GetOrganizationByAnswer(Guid answerId);
        GetUserOrganizationRoleDto GetUserOrganizationRole(Guid userId, Guid organizationId);
        Guid GetOrganizationByStudentId(Guid studentId);
        Guid GetOrganizationByCertificateId(Guid certificateId);
        Guid GetOrganizationBySendMessage(Guid sendMessageId);
        Guid GetOrganizationByStudentGroupId(Guid studentGroupId);
        Guid GetOrganizationByCourseMaterial(Guid courseMaterialId);
    }
}
