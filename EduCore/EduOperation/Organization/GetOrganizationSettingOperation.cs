using EduCore.DataTypes;

namespace EduCore.EduOperation.Organization
{
    public class GetOrganizationSettingOperation : BaseOperation
    {
        public GetOrganizationSettingOperation() : base("GET_ORGANIZATION_SETTING")
        {
            OrganizationAdministrator = true;
        }
    }
}