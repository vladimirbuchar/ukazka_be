using Model.Functions.Organization;
using Model.Functions.UserInOrganization;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using WebModel.Organization;

namespace EduFacade.OrganizationFacade.Convertor
{
    public interface IOrganizationConvertor
    {
        AddOrganization ConvertToBussinessEntity(AddOrganizationDto addOrganizationDto, Guid userId);
        HashSet<GetMyOrganizationsDto> ConvertToWebModel(HashSet<GetMyOrganizations> getMyOrganizations);
        GetOrganizationDetailDto ConvertToWebModel(GetOrganizationDetail getOrganizationDetail, HashSet<GetOrganizationAddress> organizationAddresses);
        GetOrganizationDetailWebDto ConvertToWebModelWeb(GetOrganizationDetail getOrganizationDetail);
        UpdateOrganization ConvertToBussinessEntity(UpdateOrganizationDto updateOrganizationDto);
        HashSet<GetOrganizationListDto> ConvertToWebModel(HashSet<GetAllOrganizations> getAllOrganizations);
        HashSet<FindOrganizationDto> ConvertToWebModel(HashSet<FindOrganization> findOrganizations);
        HashSet<GetAllUserInOrganizationDto> ConvertToWebModel(HashSet<GetAllUserInOrganization> getAllUserInOrganizations);
        HashSet<GetOrganizationRolesDto> ConvertToWebModel(HashSet<OrganizationRole> organizationRoles);
        SaveOrganizationSetting ConvertToBussinessEntity(SaveOrganizationSettingDto saveOrganizationSettingDto);
        GetOrganizationSettingDto ConvertToWebModel(GetOrganizationSetting getOrganizationSetting);
        HashSet<GetOrganizationCultureDto> ConvertToWebModel(HashSet<GetOrganizationCulture> getOrganizationCultures);
        GetOrganizationSettingByUrlDto ConvertToWebModel(GetOrganizationSettingByUrl getOrganizationSettingByUrl);

        AddStudyHours ConvertToBussinessEntity(AddStudyHoursDto addStudyHoursDto);
        UpdateStudyHours ConvertToBussinessEntity(UpdateStudyHoursDto updateStudyHoursDto);
        HashSet<GetStudyHoursDto> ConvertToWebModel(HashSet<GetStudyHours> getStudyHours);


    }
}
