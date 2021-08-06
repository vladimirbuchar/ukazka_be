using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLesson
{
    public class ShowStudentAnswerOperation : BaseOperation
    {
        public ShowStudentAnswerOperation() : base("SHOW_STUDENT_ANSWER")
        {
            Lector = true;
            Student = true;
        }
    }
}