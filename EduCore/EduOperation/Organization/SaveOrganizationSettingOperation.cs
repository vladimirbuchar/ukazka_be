using EduCore.DataTypes;

namespace EduCore.EduOperation.Organization
{
    public class SaveOrganizationSettingOperation : BaseOperation
    {
        public SaveOrganizationSettingOperation() : base("SAVE_ORGANIZATION_SETTING")
        {
            OrganizationAdministrator = true;
        }
    }
}