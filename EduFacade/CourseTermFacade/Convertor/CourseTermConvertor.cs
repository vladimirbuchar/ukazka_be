using Model.Functions.CourseTerm;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Course;
using WebModel.CourseTerm;

namespace EduFacade.CourseTermFacade.Convertor
{
    public class CourseTermConvertor : ICourseTermConvertor
    {
        public AddCourseTerm ConvertToBussinessEntity(AddCourseTermDto addCourseTermDto)
        {
            Guid organizationStudyHourId = Guid.Empty;
            if (!string.IsNullOrEmpty(addCourseTermDto.OrganizationStudyHourId))
            {
                Guid.TryParse(addCourseTermDto.OrganizationStudyHourId, out organizationStudyHourId);
            }
            return new AddCourseTerm()
            {
                ActiveFrom = addCourseTermDto.ActiveFrom,
                ActiveTo = addCourseTermDto.ActiveTo,
                ClassRoomId = addCourseTermDto.ClassRoomId ?? Guid.Empty,
                CourseId = addCourseTermDto.CourseId,
                BasicInformationDescription = addCourseTermDto.Description,
                Friday = addCourseTermDto.Friday,
                StudentCountMaximumStudent = addCourseTermDto.MaximumStudents,
                StudentCountMinimumStudent = addCourseTermDto.MinimumStudents,
                Monday = addCourseTermDto.Monday,
                BasicInformationName = addCourseTermDto.Name,
                CoursePrice = addCourseTermDto.Price.Price,
                RegistrationFrom = addCourseTermDto.RegistrationFrom,
                RegistrationTo = addCourseTermDto.RegistrationTo,
                CoursePriceSale = addCourseTermDto.Price.Sale,
                Saturday = addCourseTermDto.Saturday,
                Sunday = addCourseTermDto.Sunday,
                Thursday = addCourseTermDto.Thursday,
                TimeFromId = addCourseTermDto.TimeFromId,
                TimeToId = addCourseTermDto.TimeToId,
                Tuesday = addCourseTermDto.Tuesday,
                Wednesday = addCourseTermDto.Wednesday,
                OrganizationStudyHourId = string.IsNullOrEmpty(addCourseTermDto.OrganizationStudyHourId) || organizationStudyHourId == Guid.Empty ? (Guid?)null : organizationStudyHourId
            };
        }

        public AddStudentEvaluation ConvertToBussinessEntity(AddStudentEvaluationDto addStudentEvaluationDto)
        {
            return new AddStudentEvaluation()
            {
                CourseTermId = addStudentEvaluationDto.CourseTermId,
                Evaluation = addStudentEvaluationDto.Evaluation,
                UserInOrganizationId = addStudentEvaluationDto.UserInOrganizationId
            };
        }

        public HashSet<GetAllTermInCourseDto> ConvertToWebModel(HashSet<GetAllTermInCourse> getTermInCourses)
        {
            return getTermInCourses.Select(item => new GetAllTermInCourseDto()
            {
                Branch = item.Branch,
                ClassRoom = item.ClassRoom,
                CourseId = item.CourseId,
                Id = item.Id,
                TimeFrom = item.TimeFrom,
                TimeTo = item.TimeTo,
                ActiveFrom = item.ActiveFrom,
                ActiveTo = item.ActiveTo,
                Monday = item.Monday,
                Saturday = item.Saturday,
                Sunday = item.Sunday,
                Thursday = item.Thursday,
                Tuesday = item.Tuesday,
                Wednesday = item.Wednesday,
                Friday = item.Friday,
                BranchId = item.BranchId,
                ClassRoomId = item.ClassRoomId,
                IsActive = item.IsActive
            }).ToHashSet();
        }

        public GetCourseTermDetailDto ConvertToWebModel(GetCourseTermDetail getCourseTermDetail)
        {
            return new GetCourseTermDetailDto()
            {
                ActiveFrom = getCourseTermDetail.ActiveFrom,
                Id = getCourseTermDetail.Id,
                Wednesday = getCourseTermDetail.Wednesday,
                ActiveTo = getCourseTermDetail.ActiveTo,
                ClassRoomId = getCourseTermDetail.ClassRoomId,
                BranchId = getCourseTermDetail.BranchId,
                CoursePrice = new WebModel.Shared.CoursePriceDto()
                {
                    Price = getCourseTermDetail.Price,
                    Sale = getCourseTermDetail.Sale
                },
                Friday = getCourseTermDetail.Friday,
                MaximumStudent = getCourseTermDetail.MaximumStudent,
                MinimumStudent = getCourseTermDetail.MinimumStudent,
                Monday = getCourseTermDetail.Monday,
                RegistrationFrom = getCourseTermDetail.RegistrationFrom,
                RegistrationTo = getCourseTermDetail.RegistrationTo,
                Saturday = getCourseTermDetail.Saturday,
                Sunday = getCourseTermDetail.Sunday,
                Thursday = getCourseTermDetail.Thursday,
                TimeFromId = getCourseTermDetail.TimeFromId,
                TimeToId = getCourseTermDetail.TimeToId,
                Tuesday = getCourseTermDetail.Tuesday,
                OrganizationStudyHourId = getCourseTermDetail.OrganizationStudyHourId
            };
        }

        public UpdateCourseTerm ConvertToWebModel(UpdateCourseTermDto updateCourseTermDto)
        {
            Guid organizationStudyHourId = Guid.Empty;
            if (!string.IsNullOrEmpty(updateCourseTermDto.OrganizationStudyHourId))
            {
                Guid.TryParse(updateCourseTermDto.OrganizationStudyHourId, out organizationStudyHourId);
            }
            return new UpdateCourseTerm()
            {
                ActiveFrom = updateCourseTermDto.ActiveFrom,
                ActiveTo = updateCourseTermDto.ActiveTo,
                BasicInformationDescription = updateCourseTermDto.Description,
                BasicInformationName = updateCourseTermDto.Name,
                ClassRoomId = updateCourseTermDto.ClassRoomId ?? Guid.Empty,
                CoursePrice = updateCourseTermDto.Price.Price,
                CoursePriceSale = updateCourseTermDto.Price.Sale,
                Friday = updateCourseTermDto.Friday,
                Id = updateCourseTermDto.Id,
                Monday = updateCourseTermDto.Monday,
                RegistrationFrom = updateCourseTermDto.RegistrationFrom,
                RegistrationTo = updateCourseTermDto.RegistrationTo,
                Saturday = updateCourseTermDto.Saturday,
                StudentCountMaximumStudent = updateCourseTermDto.MaximumStudents,
                StudentCountMinimumStudent = updateCourseTermDto.MinimumStudents,
                Sunday = updateCourseTermDto.Sunday,
                Thursday = updateCourseTermDto.Thursday,
                TimeFromId = updateCourseTermDto.TimeFromId,
                TimeToId = updateCourseTermDto.TimeToId,
                Tuesday = updateCourseTermDto.Tuesday,
                Wednesday = updateCourseTermDto.Wednesday,
                OrganizationStudyHourId = string.IsNullOrEmpty(updateCourseTermDto.OrganizationStudyHourId) || organizationStudyHourId == Guid.Empty ? (Guid?)null : organizationStudyHourId
            };
        }

        public HashSet<GetTimeTableDto> ConvertToWebModel(HashSet<GetTimeTable> getTimeTables)
        {
            return getTimeTables.Select(x => new GetTimeTableDto()
            {
                Date = x.Date,
                DayOfWeek = x.DayOfWeek,
                Id = x.Id,
                IsCanceled = x.IsCanceled,
                TimeFrom = x.TimeFrom,
                TimeTo = x.TimeTo,
                ClassRoom = x.ClassRoom,
                Lector = string.IsNullOrEmpty(string.Format("{0} {1} {2}", x.FirstName, x.SecondName, x.LastName).Trim()) ? x.UserEmail : string.Format("{0} {1} {2}", x.FirstName, x.SecondName, x.LastName)
            }).ToHashSet();
        }

        public HashSet<GetStudentEvaluationDto> ConvertToWebModel(HashSet<GetStudentEvaluation> getStudentEvaluations)
        {
            return getStudentEvaluations.Select(x => new GetStudentEvaluationDto()
            {
                Date =x.Date,
                Evaluation =x.Evaluation,
                FirstName =x.FirstName,
                Id =x.Id,
                LastName=x.LastName,
                SecondName =x.SecondName,
                UserEmail =x.UserEmail
            }).ToHashSet();

        }
    }
}
