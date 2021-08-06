using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class UpdateCertificateOperation : BaseOperation
    {
        public UpdateCertificateOperation() : base("UPDATE_CERTIFICATE")
        {
            OrganizationAdministrator = true;
        }
    }
}