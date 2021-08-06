using Model.Functions.CourseTest;
using System.Collections.Generic;
using WebModel.CourseTest;

namespace EduFacade.TestFacade.Convertor
{
    public interface ITestConvertor
    {
        AddCourseTest ConvertToBussinessEntity(AddCourseTestDto addCourseTestDto);
        GetCourseTestDetailDto ConvertToWebModel(GetCourseTestDetail getCourseTestDetail);
        UpdateCourseTest ConvertToBussinessEntity(UpdateCourseTestDto updateCourseTestDto);
        HashSet<GetAllStudentTestResultDto> ConvertToWebModel(HashSet<GetAllStudentTestResult> getAllStudentTestResults);
        HashSet<ShowStudentAnswerDto> ConvertToWebModel(HashSet<GetStudentQuestion> showStudentAnswers);
        ShowTestResultDto ConvertToWebModel(ShowTestResult showTestResult);
    }
}
