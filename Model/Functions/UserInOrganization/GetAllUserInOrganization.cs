using Model.Tables.Edu;
using System;

namespace Model.Functions.UserInOrganization
{
    public class GetAllUserInOrganization : SqlFunction
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public bool IsOrganizationOwner => UserRole == OrganizationRoleValue.ORGANIZATION_OWNER;
        public bool IsCourseAdministrator => UserRole == OrganizationRoleValue.COURSE_ADMINISTATOR;
        public bool IsCourseEditor => UserRole == OrganizationRoleValue.COURSE_EDITOR;
        public bool IsOrganizationAdministrator => UserRole == OrganizationRoleValue.ORGANIZATION_ADMINISTRATOR;
        public Guid UserId { get; set; }
    }
}
