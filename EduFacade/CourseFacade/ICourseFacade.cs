using Core.DataTypes;
using Model.Functions.CourseTest;
using System;
using System.Collections.Generic;
using WebModel.Course;
using WebModel.CourseTest;
using WebModel.Organization;
using WebModel.Student;

namespace EduFacade.CourseFacade
{
    public interface ICourseFacade : IBaseFacade
    {
        IEnumerable<GetCourseOfferDto> GetCourseOffer(CourseFilterDto courseFilterDto);
        Result AddCourse(AddCourseDto addCourseDto);
        HashSet<GetAllCourseInOrganizationDto> GetAllCourseInOrganization(Guid organizationId);
        GetCourseDetailDto GetCourseDetail(Guid courseId);
        Result UpdateCourse(UpdateCourseDto updateCourseDto);
        void DeleteCourse(Guid courseId);
        HashSet<GetMyCourseDto> GetMyCourse(Guid userId, bool hideFinishCourse);
        HashSet<CourseMenuItemDto> GetCourseMenu(Guid courseId, Guid userId);
        HashSet<GetAllSlideIdDto> GetAllSlideId(Guid courseId, Guid userId);
        GetUserOrganizationRoleDto CanCourseBrowse(Guid courseId, Guid userId);
        CourseLessonStudyDto CourseMaterialBrowse(Guid courseId, Guid userId);
        CourseLessonStudyDto GoToSlide(Guid slideId, Guid userId, Guid courseId);
        Guid StartTest(Guid courseLessonId, Guid userId, Guid courseId);
        EvaluateTest EvaluateTest(Guid userTestSummaryId, List<EvaluateQuestionDto> evaluateTestDtos, Guid courseLessonId);
        HashSet<ShowTestResultQuestionDto> ShowTestResult(Guid userTesId);
        GetUserOrganizationRoleDto CanShowStudentTestResult(Guid courseId, Guid userId);
        HashSet<GetManagedCourseDto> GetManagedCourse(Guid userId);
        HashSet<GetStudentTestDto> GetStudentTest(Guid userId);
        FinishCourseDto FinishCourse(Guid userId, Guid courseStudentId, Guid courseId, Guid organizationId);
        void ResetCourse(Guid studentTermId);
        void UpdateActualTable(UpdateActualTableDto updateActualTableDto);
        Result<string> GetActualTable(Guid courseTermid);
        void CreateLiveBroadcastEvent(CreateLiveBroadcastEventDto createLiveBroadcastEventDto);
    }
}
