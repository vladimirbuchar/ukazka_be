using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;
namespace EduRepository.OrganizationRoleRepository
{
    public interface IOrganizationRoleRepository : IBaseRepository
    {
        HashSet<GetUserOrganizationRole> GetUserOrganizationRole(Guid userId, Guid organizationId);
        HashSet<GetAllUserInOrganization> GetAllUserInOrganization(Guid organizationId);
        Guid AddUserToOrganization(AddUserToOrganization addUserToOrganization);
        GetUserOrganizationRoleDetail GetUserOrganizationRoleDetail(Guid userInOrganizationId);
        void UpdateUserInOrganizationRole(UpdateUserInOrganizationRole updateUserInOrganizationRole);
    }
}
