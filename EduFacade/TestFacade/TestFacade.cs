using Core.DataTypes;
using EduFacade.TestFacade.Convertor;
using EduServices.CourseLessonService;
using EduServices.TestService;
using Model.Functions.CourseTest;
using System;
using System.Collections.Generic;
using WebModel.CourseTest;

namespace EduFacade.TestFacade
{
    public class TestFacade : BaseFacade, ITestFacade
    {
        private readonly ICourseLessonService _courseLessonService;
        private readonly ITestService _testService;
        private readonly ITestConvertor _testConvertor;
        public TestFacade(ICourseLessonService courseLessonService, ITestService testService, ITestConvertor testConvertor)
        {
            _courseLessonService = courseLessonService;
            _testService = testService;
            _testConvertor = testConvertor;
        }

        private Result Validate(AddCourseTestDto addCourseTestDto)
        {
            Result result = new Result();
            _courseLessonService.ValidateCourseLessonName(addCourseTestDto.Name, result);
            _testService.ValidateCourseTestBankOfQuestion(addCourseTestDto.BankOfQuestion, result);
            _testService.ValidateCourseTestDesiredSuccess(addCourseTestDto.DesiredSuccess, result);
            _testService.ValidateCourseTestQuestionCountInTest(addCourseTestDto.QuestionCountInTest, result);
            _testService.ValidateCourseTestTimeLimit(addCourseTestDto.TimeLimit, result);
            return result;
        }
        private Result Validate(UpdateCourseTestDto updateCourseTestDto)
        {
            Result result = new Result();
            _courseLessonService.ValidateCourseLessonName(updateCourseTestDto.Name, result);
            _testService.ValidateCourseTestBankOfQuestion(updateCourseTestDto.BankOfQuestion, result);
            _testService.ValidateCourseTestDesiredSuccess(updateCourseTestDto.DesiredSuccess, result);
            _testService.ValidateCourseTestQuestionCountInTest(updateCourseTestDto.QuestionCountInTest, result);
            _testService.ValidateCourseTestTimeLimit(updateCourseTestDto.TimeLimit, result);
            return result;
        }
        public Result AddCourseTest(AddCourseTestDto addCourseTestDto)
        {
            Result result = Validate(addCourseTestDto);
            if (result.IsOk)
            {
                Guid lessonGuid = _courseLessonService.AddCourseLesson(new Model.Functions.CourseLesson.AddCourseLesson()
                {
                    MaterialId = addCourseTestDto.MaterialId,
                    Description = addCourseTestDto.Description,
                    Name = addCourseTestDto.Name,
                    Type = addCourseTestDto.Type
                });
                AddCourseTest test = _testConvertor.ConvertToBussinessEntity(addCourseTestDto);
                test.CourseLessonId = lessonGuid;
                _testService.AddCourseTest(test);
            }
            return result;

        }

        public GetCourseTestDetailDto GetCourseTestDetail(Guid courseLessonId)
        {
            return _testConvertor.ConvertToWebModel(_testService.GetCourseTestDetail(courseLessonId));
        }

        public Result UpdateCourseTest(UpdateCourseTestDto updateCourseTestDto)
        {
            Result result = Validate(updateCourseTestDto);
            if (result.IsOk)
            {
                _courseLessonService.UpdateCourseLesson(new Model.Functions.CourseLesson.UpdateCourseLesson()
                {
                    Description = updateCourseTestDto.Description,
                    Id = updateCourseTestDto.Id,
                    Name = updateCourseTestDto.Name
                });
                UpdateCourseTest test = _testConvertor.ConvertToBussinessEntity(updateCourseTestDto);
                _testService.UpdateCourseTest(test);
            }
            return result;
        }

        public HashSet<GetAllStudentTestResultDto> GetAllStudentTestResult(Guid couseId)
        {
            return _testConvertor.ConvertToWebModel(_testService.GetAllStudentTestResult(couseId));
        }

        public ShowTestResultDto ShowStudentAnswer(Guid studentTestResultId)
        {
            return _testConvertor.ConvertToWebModel(_testService.ShowStudentAnswer(studentTestResultId));
        }

        public void SetLectorControl(SetLectorControlDto setLectorControlDto)
        {
            _testService.SetLectorControl(setLectorControlDto.QuestionId, setLectorControlDto.IsTrue, setLectorControlDto.Score, setLectorControlDto.StudentTestResultId);
        }
    }
}
