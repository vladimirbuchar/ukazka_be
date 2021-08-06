using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class GetStudentGroupInOrganizationOperation : BaseOperation
    {
        public GetStudentGroupInOrganizationOperation() : base("GET_STUDENT_IN_GROUP")
        {
            OrganizationAdministrator = true;
        }
    }
}