using Core.DataTypes;
using Core.Extension;
using EduRepository.CodeBookRepository;
using EduRepository.CourseRepository;
using Integration.YoutubeIntegration;
using Model.Functions.Course;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.CourseService
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICodeBookRepository _codeBookRepository;
        private readonly IYoutubeIntegration _youtubeIntegration;
        public CourseService(ICourseRepository courseRepository, ICodeBookRepository codeBookRepository, IYoutubeIntegration youtubeIntegration)
        {
            _courseRepository = courseRepository;
            _codeBookRepository = codeBookRepository;
            _youtubeIntegration = youtubeIntegration;
        }

        public Guid AddCourse(AddCourse addCourse)
        {
            return _courseRepository.AddCourse(addCourse);
        }

        public GetCourseDetail GetCourseDetail(Guid courseId)
        {
            return _courseRepository.GetCourseDetail(courseId);
        }

        public void DeleteCourse(Guid courseId)
        {
            _courseRepository.DeleteEntity<Course>(courseId);
        }

        public void UpdateCourse(UpdateCourse updateCourse)
        {
            _courseRepository.UpdateCourse(updateCourse);
        }
        public HashSet<Course> GetCourseOffer(Course filter)
        {
            return new HashSet<Course>();
            /* Guid categoryId = filter.CategoryId;
             Guid organizationId = filter.OrganizationId;
             string city = filter.Address.City;
             Guid branch = filter.BranchId;
             int maxPrice = filter.MaxPrice;
             Guid courseId = filter.CourseId;
             Guid lectorId = filter.LectorId;
             Guid classRoom = filter.ClassRoomId;
             bool selectSomeDay = filter.Monday || filter.Thursday || filter.Wednesday || filter.Tuesday || filter.Friday || filter.Saturday || filter.Sunday;
             Dictionary<DaysInWeek, bool> daysInWeek = new Dictionary<DaysInWeek, bool>
             {
                 { DaysInWeek.FRIDAY, filter.Friday },
                 { DaysInWeek.MONDAY, filter.Monday },
                 { DaysInWeek.SATURDAY, filter.Saturday },
                 { DaysInWeek.SUNDAY, filter.Sunday },
                 { DaysInWeek.TUESDAY, filter.Tuesday },
                 { DaysInWeek.WEDNESDAY, filter.Wednesday }
             };
             return mapper.Map<IEnumerable<CourseOfferListItemDto>>(repository.GetCourseOffer(categoryId, organizationId, city, branch, maxPrice, courseId, lectorId, classRoom, selectSomeDay, daysInWeek));
             */
        }

        public HashSet<GetAllCourseInOrganization> GetAllCourseInOrganization(Guid organizationId)
        {
            return _courseRepository.GetAllCourseInOrganization(organizationId);
        }


        public Result ValidateCourseName(string courseName, Result validate)
        {
            if (courseName.IsNullOrEmptyWithTrim())
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE", "COURSE_NAME_IS_EMPTY"));
            }
            return validate;
        }
        public Result ValidateStudentCount(int defaultMinimumStudents, int defaultMaximumStudents, Result validate)
        {
            if (defaultMaximumStudents < 0)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE", "MAXIMUM_STUDENT_IS_LESS_THAN_ZERO"));
            }
            if (defaultMinimumStudents < 0)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE", "MINIMUM_STUDENT_IS_LESS_THAN_ZERO"));
            }
            if (defaultMinimumStudents > defaultMaximumStudents)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE", "MAXIMUM_STUDENT_IS_LESS_THAN_MINIMUM_STUDENT"));
            }
            return validate;
        }

        public Result ValidateCourseStatus(Guid courseStatus, Result validate)
        {
            CourseStatus status = _codeBookRepository.GetEntity<CourseStatus>(courseStatus);
            if (status == null || status.SystemIdentificator == CodeBookValues.CODEBOOK_SELECT_VALUE)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE", "INVALID_COURSE_STATUS"));
            }
            return validate;
        }
        public Result ValidateCourseType(Guid courseType, Result validate)
        {
            CourseType type = _codeBookRepository.GetEntity<CourseType>(courseType);
            if (type == null || type.SystemIdentificator == CodeBookValues.CODEBOOK_SELECT_VALUE)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE", "INVALID_COURSE_TYPE"));
            }
            return validate;
        }

        public Result ValidatePrice(double price, Result validate)
        {
            if (price < 0)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.WARNING, "COURSE", "PRICE_IS_LESS_THAN_ZERO"));
            }
            return validate;
        }

        public void SaveActiveSlide(Guid slideId, Guid userId, Guid courseId)
        {
            _courseRepository.SaveActiveSlide(slideId, userId, courseId);
        }

        public void FinishCourse(Guid courseStudentId)
        {
            _courseRepository.FinishCourse(courseStudentId);
        }

        public void ResetCourse(Guid studentTermId)
        {
            _courseRepository.ResetCourse(studentTermId);
        }

        public GetCourseTermByCourseStudent GetCourseTermByCourseStudent(Guid courseStudentId)
        {
            return _courseRepository.GetCourseTermByCourseStudent(courseStudentId);
        }

        public void CreateLiveBroadcastEvent(Guid courseTermId)
        {
            _youtubeIntegration.CreateLiveBroadcastEvent("", DateTime.Now);
        }
    }
}
