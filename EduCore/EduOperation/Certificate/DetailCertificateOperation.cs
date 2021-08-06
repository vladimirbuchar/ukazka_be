using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class DetailCertificateOperation : BaseOperation
    {
        public DetailCertificateOperation() : base("DETAIL_CERTIFICATE")
        {
            OrganizationAdministrator = true;
        }
    }
}