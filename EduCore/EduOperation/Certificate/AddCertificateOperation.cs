using EduCore.DataTypes;

namespace EduCore.EduOperation.Certificate
{
    public class AddCertificateOperation : BaseOperation
    {
        public AddCertificateOperation() : base("ADD_CERTIFICATE")
        {
            OrganizationAdministrator = true;
        }
    }
}