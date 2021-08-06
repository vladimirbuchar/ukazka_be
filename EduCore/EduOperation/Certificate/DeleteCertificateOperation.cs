using EduCore.DataTypes;

namespace EduCore.EduOperation.Certificate
{
    public class DeleteCertificateOperation : BaseOperation
    {
        public DeleteCertificateOperation() : base("DELETE_CERTIFICATE")
        {
            OrganizationAdministrator = true;
        }
    }
}