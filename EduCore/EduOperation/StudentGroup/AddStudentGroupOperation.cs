using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class AddStudentGroupOperation : BaseOperation
    {
        public AddStudentGroupOperation() : base("ADD_STUDENT_GROUP")
        {
            OrganizationAdministrator = true;
        }

    }
    public class AddCourseMaterialOperation: BaseOperation
    {
        public AddCourseMaterialOperation() : base("ADD_COURSE_MATERIAL_OPERATION")
        {
            OrganizationAdministrator = true;
        }
    }
}