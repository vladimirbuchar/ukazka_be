using Model.Functions.License;
using Model.Functions.Organization;
using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;

namespace EduRepository.OrganizationRepository
{
    public interface IOrganizationRepository : IBaseRepository
    {
        Guid GetOrganizationIdByBranch(Guid branchId);
        Guid GetOrganizationIdByClassRoom(Guid classRoomId);
        Guid GetOrganizationByCourse(Guid courseId);
        Guid GetOrganizationByTermId(Guid termId);
        HashSet<GetAllOrganizations> GetAllOrganizations();
        HashSet<GetMyOrganizations> GetMyOrganizations(Guid userId);
        GetOrganizationDetail GetOrganizationDetail(Guid organizationId);
        GetLicenseByOrganization GetLicenseByOrganization(Guid organizationId);
        Guid GetOrganizationByUserInOrganization(Guid organizationUserId);
        Guid AddOrganization(AddOrganization addOrganization);
        void UpdateOrganization(UpdateOrganization updateOrganization);
        HashSet<FindOrganization> FindOrganization(string findText);
        Guid GetOrganizationByCourseLessonId(Guid courseLessonId);
        Guid GetOrganizationByCourseLessonItemId(Guid courseLessonItemId);
        Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId);
        Guid GetOrganizationIdByQuestion(Guid questionId);
        Guid GetOrganizationByAnswer(Guid answerId);
        HashSet<GetOrganizationAddress> GetOrganizationAddress(Guid organizationId);
        Guid GetOrganizationByStudent(Guid studentId);
        void SaveOrganizationSetting(SaveOrganizationSetting saveOrganizationSetting);
        GetOrganizationSetting GetOrganizationSetting(Guid organizationId);
        Guid GetOrganizationByCertificateId(Guid certificateId);
        HashSet<GetOrganizationCulture> GetOrganizationCulture(Guid organizationId);
        bool CheckOrganizationUrl(string organizationUrl, Guid organizationId);
        GetOrganizationSettingByUrl GetOrganizationSettingByUrl(string url);
        void AddStudyHour(AddStudyHours addStudyHours);
        void UpdateStudyHour(UpdateStudyHours updateStudyHours);
        HashSet<GetStudyHours> GetStudyHours(Guid organizationId);
        Guid GetOrganizationBySendMessage(Guid sendMessageId);
        Guid GetOrganizationByStudentGroupId(Guid studentGroupId);
        Guid GetOrganizationByCourseMaterial(Guid courseMaterialId);
    }
}
