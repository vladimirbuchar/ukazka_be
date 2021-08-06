using EduCore.DataTypes;

namespace EduCore.EduOperation.BankOfQuestion
{
    public class GetCertificateInOrganizationOperation : BaseOperation
    {
        public GetCertificateInOrganizationOperation() : base("GET_CERTIFICATE_IN_ORGANIZATION")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}