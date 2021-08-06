using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Organization;

namespace EduFacade.OrganizationFacade
{
    public interface IOrganizationFacade : IBaseFacade
    {
        GetOrganizationDetailDto GetOrganizationDetail(Guid organizationId);
        GetOrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId);
        Result AddOrganization(Guid userId, AddOrganizationDto addOrganizationDto);
        void DeleteOrganization(Guid ogranizationId);
        HashSet<GetMyOrganizationsDto> GetMyOrganizations(Guid userId);
        Result UpdateOrganization(UpdateOrganizationDto updateOrganizationDto);
        HashSet<GetOrganizationListDto> GetOrganizationList();
        Result AddUserToOrganization(AddUserToOrganizationDto addUserToOrganizationDto);
        HashSet<GetAllUserInOrganizationDto> GetAllUserInOrganization(Guid organizationId);
        void DeleteUserFromOrganization(Guid userId, Guid organizationId);
        HashSet<FindOrganizationDto> FindOrganization(string findText);
        HashSet<GetOrganizationRolesDto> GetOrganizationRoles();
        GetUserOrganizationRoleDetailDto GetUserOrganizationRoleDetail(Guid userId, Guid organizationId);
        void UpdateUserInOrganizationRole(UpdateUserInOrganizationRoleDto updateUserInOrganizationRoleDto);
        Result SaveOrganizationSetting(SaveOrganizationSettingDto saveOrganizationSettingDto);
        GetOrganizationSettingDto GetOrganizationSetting(Guid organizationId);
        HashSet<GetOrganizationCultureDto> GetOrganizationCulture(Guid organizationId);
        GetOrganizationSettingByUrlDto GetOrganizationSettingByUrl(string url);
        void AddStudyHour(AddStudyHoursDto addStudyHoursDto);
        void UpdateStudyHour(UpdateStudyHoursDto updateStudyHoursDto);
        HashSet<GetStudyHoursDto> GetStudyHours(Guid organizationId);
        void DeleteStudyHour(Guid studyHourId);

    }
}
