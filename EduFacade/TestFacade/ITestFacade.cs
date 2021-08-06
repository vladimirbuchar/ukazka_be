using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.CourseTest;

namespace EduFacade.TestFacade
{
    public interface ITestFacade : IBaseFacade
    {
        Result AddCourseTest(AddCourseTestDto addCourseTestDto);
        Result UpdateCourseTest(UpdateCourseTestDto updateCourseTestDto);
        GetCourseTestDetailDto GetCourseTestDetail(Guid courseLessonId);
        HashSet<GetAllStudentTestResultDto> GetAllStudentTestResult(Guid couseId);
        ShowTestResultDto ShowStudentAnswer(Guid studentTestResultId);
        void SetLectorControl(SetLectorControlDto setLectorControlDto);
    }
}
