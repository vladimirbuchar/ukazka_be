using EduCore.DataTypes;

namespace EduCore.EduOperation.CourseLesson
{
    public class GetAllStudentTestResultOperation : BaseOperation
    {
        public GetAllStudentTestResultOperation() : base("GET_ALL_STUDENT_TEST_RESULT")
        {
            Lector = true;
        }
    }
}