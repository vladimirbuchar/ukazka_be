using Model.Functions.CourseStudent;
using System.Collections.Generic;
using WebModel.Student;

namespace EduFacade.CourseStudentFacade.Convertor
{
    public interface ICourseStudentConvertor
    {
        HashSet<GetAllStudentInCourseTermDto> ConvertToWebModel(HashSet<GetAllStudentInCourseTerm> getStudentsInTerms);

    }
}
