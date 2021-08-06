using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class DeleteStudentGroupOperation : BaseOperation
    {
        public DeleteStudentGroupOperation() : base("DELETE_STUDENT_GROUP")
        {
            OrganizationAdministrator = true;
        }
    }
}