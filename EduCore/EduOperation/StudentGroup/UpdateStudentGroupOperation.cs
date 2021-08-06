using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class UpdateStudentGroupOperation : BaseOperation
    {


        public UpdateStudentGroupOperation() : base("UPDATE_STUDENT_GROUP")
        {
            OrganizationAdministrator = true;
        }
    }
}