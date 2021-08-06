using Model.Functions.UserInOrganization;
using System.Collections.Generic;
using WebModel.Organization;

namespace EduFacade.OraganizationRoleFacade.Convertor
{
    public interface IOraganizationRoleConvertor
    {
        GetUserOrganizationRoleDto ConvertToWebModel(HashSet<GetUserOrganizationRole> getUserOrganizationRoles);
    }
}
