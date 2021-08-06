using Model.Functions.Course;
using Model.Functions.CourseStudent;
using Model.Functions.CourseTest;
using System.Collections.Generic;
using WebModel.Course;
using WebModel.CourseTest;
using WebModel.Student;

namespace EduFacade.CourseFacade.Convertor
{
    public interface ICourseConvertor
    {
        AddCourse ConvertToBussinessEntity(AddCourseDto addCourseDto);
        HashSet<GetAllCourseInOrganizationDto> ConvertToWebModel(HashSet<GetAllCourseInOrganization> getAllCourseInOrganizations);
        GetCourseDetailDto ConvertToWebModel(GetCourseDetail getCourseDetail);
        UpdateCourse ConvertToBussinessEntity(UpdateCourseDto updateCourseDto);
        HashSet<GetMyCourseDto> ConvertToWebModel(HashSet<GetMyCourse> getStudentCourses);
        ShowTestResultDto ConvertToWebModel(ShowTestResult getAllCourseInOrganizations);
        HashSet<GetStudentTestDto> ConvertToWebModel(HashSet<GetStudentTest> getStudentTests);
    }

}
