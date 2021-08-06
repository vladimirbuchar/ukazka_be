using Model.Functions.CourseTerm;
using System.Collections.Generic;
using WebModel.Course;
using WebModel.CourseTerm;

namespace EduFacade.CourseTermFacade.Convertor
{
    public interface ICourseTermConvertor
    {
        AddCourseTerm ConvertToBussinessEntity(AddCourseTermDto addCourseTermDto);
        HashSet<GetAllTermInCourseDto> ConvertToWebModel(HashSet<GetAllTermInCourse> getTermInCourses);
        GetCourseTermDetailDto ConvertToWebModel(GetCourseTermDetail getCourseTermDetail);
        UpdateCourseTerm ConvertToWebModel(UpdateCourseTermDto updateCourseTermDto);
        HashSet<GetTimeTableDto> ConvertToWebModel(HashSet<GetTimeTable> getTimeTables);
        HashSet<GetStudentEvaluationDto> ConvertToWebModel(HashSet<GetStudentEvaluation> getTimeTables);
        //AddStudentEvaluationDto
        AddStudentEvaluation ConvertToBussinessEntity(AddStudentEvaluationDto addStudentEvaluationDto);
    }
}
