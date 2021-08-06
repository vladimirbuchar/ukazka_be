using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class AddStudentToGroupOperation : BaseOperation
    {
        public AddStudentToGroupOperation() : base("ADD_STUDENT_TO_GROUP")
        {
            OrganizationAdministrator = true;
        }

    }
}