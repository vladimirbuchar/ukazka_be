using Core.DataTypes;
using Model.Functions.Course;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
namespace EduRepository.CourseRepository
{
    public interface ICourseRepository : IBaseRepository
    {
        HashSet<Course> GetCourseOffer(Guid categoryId, Guid orgId, string city, Guid branch, int maxPrice, Guid courseId, Guid lectorId, Guid classRoomId, bool selectSomeDay, Dictionary<DaysInWeek, bool> selectedDays);
        HashSet<GetAllCourseInOrganization> GetAllCourseInOrganization(Guid organizationId);
        GetCourseDetail GetCourseDetail(Guid courseId);
        Guid AddCourse(AddCourse addCourse);
        void UpdateCourse(UpdateCourse updateCourse);
        void SaveActiveSlide(Guid slideId, Guid userId, Guid courseId);
        void FinishCourse(Guid courseStudentId);
        void ResetCourse(Guid studentTermId);
        GetCourseTermByCourseStudent GetCourseTermByCourseStudent(Guid courseStudentId);
    }
}
