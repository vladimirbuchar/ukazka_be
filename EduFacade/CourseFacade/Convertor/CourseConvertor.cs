using EduServices.CodeBookService;
using Model.Functions.Course;
using Model.Functions.CourseStudent;
using Model.Functions.CourseTest;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Course;
using WebModel.CourseTest;
using WebModel.Student;

namespace EduFacade.CourseFacade.Convertor
{
    public class CourseConvertor : ICourseConvertor
    {
        private readonly HashSet<CourseType> _courseTypes;
        public CourseConvertor(ICodeBookService codeBookService)
        {
            _courseTypes = codeBookService.GetCodeBookItems<CourseType>();
        }
        public AddCourse ConvertToBussinessEntity(AddCourseDto addCourseDto)
        {
            Guid certificateId = Guid.Empty;
            if (!string.IsNullOrEmpty(addCourseDto.CertificateId))
            {
                Guid.TryParse(addCourseDto.CertificateId, out certificateId);
            }
            Guid materialId = Guid.Empty;
            if (!string.IsNullOrEmpty(addCourseDto.CourseMaterialId))
            {
                Guid.TryParse(addCourseDto.CourseMaterialId, out materialId);
            }
            Guid emailId = Guid.Empty;
            if (!string.IsNullOrEmpty(addCourseDto.EmailTemplateId))
            {
                Guid.TryParse(addCourseDto.EmailTemplateId, out emailId);
            }
            return new AddCourse()
            {
                BasicInformationDescription = addCourseDto.Description,
                BasicInformationName = addCourseDto.Name,
                CoursePrice = addCourseDto.Price.Price,
                CoursePriceSale = addCourseDto.Price.Sale,
                CourseStatusId = addCourseDto.CourseStatusId,
                CourseTypeId = addCourseDto.CourseTypeId,
                OrganizationId = addCourseDto.OrganizationId,
                IsPrivateCourse = addCourseDto.IsPrivateCourse,
                StudentCountMaximumStudent = addCourseDto.DefaultMaximumStudents,
                StudentCountMinimumStudent = addCourseDto.DefaultMinimumStudents,
                CertificateId = string.IsNullOrEmpty(addCourseDto.CertificateId) || certificateId == Guid.Empty ? (Guid?)null : certificateId,
                AutomaticGenerateCertificate = addCourseDto.AutomaticGenerateCertificate,
                CourseMaterialId = string.IsNullOrEmpty(addCourseDto.CourseMaterialId) || materialId == Guid.Empty ? (Guid?)null : materialId,
                SendEmail = addCourseDto.SendEmail,
                EmailTemplateId = string.IsNullOrEmpty(addCourseDto.EmailTemplateId) || emailId == Guid.Empty ? (Guid?)null : emailId,
                CourseWithLector =addCourseDto.CourseWithLector
                
            };
        }

        public UpdateCourse ConvertToBussinessEntity(UpdateCourseDto updateCourseDto)
        {
            Guid certificateId = Guid.Empty;
            if (!string.IsNullOrEmpty(updateCourseDto.CertificateId))
            {
                Guid.TryParse(updateCourseDto.CertificateId, out certificateId);
            }
            Guid materialId = Guid.Empty;
            if (!string.IsNullOrEmpty(updateCourseDto.CourseMaterialId))
            {
                Guid.TryParse(updateCourseDto.CourseMaterialId, out materialId);
            }
            Guid emailId = Guid.Empty;
            if (!string.IsNullOrEmpty(updateCourseDto.EmailTemplateId))
            {
                Guid.TryParse(updateCourseDto.EmailTemplateId, out emailId);
            }
            return new UpdateCourse()
            {
                BasicInformationDescription = updateCourseDto.Description,
                BasicInformationName = updateCourseDto.Name,
                CourseId = updateCourseDto.Id,
                CoursePrice = updateCourseDto.Price.Price,
                CoursePriceSale = updateCourseDto.Price.Sale,
                CourseStatusId = updateCourseDto.CourseStatusId,
                CourseTypeId = updateCourseDto.CourseTypeId,
                IsPrivateCourse = updateCourseDto.IsPrivateCourse,
                StudentCountMaximumStudent = updateCourseDto.DefaultMaximumStudents,
                StudentCountMinimumStudent = updateCourseDto.DefaultMinimumStudents,
                CertificateId = string.IsNullOrEmpty(updateCourseDto.CertificateId) || certificateId == Guid.Empty ? (Guid?)null : certificateId,
                AutomaticGenerateCertificate = updateCourseDto.AutomaticGenerateCertificate,
                CourseMaterialId = string.IsNullOrEmpty(updateCourseDto.CourseMaterialId) || materialId == Guid.Empty ? (Guid?)null : materialId,
                SendEmail = updateCourseDto.SendEmail,
                EmailTemplateId = string.IsNullOrEmpty(updateCourseDto.EmailTemplateId) || emailId == Guid.Empty ? (Guid?)null : emailId,
                CourseWithLector = updateCourseDto.CourseWithLector

            };
        }

        public HashSet<GetAllCourseInOrganizationDto> ConvertToWebModel(HashSet<GetAllCourseInOrganization> getAllCourseInOrganizations)
        {
            return getAllCourseInOrganizations.Select(item => new GetAllCourseInOrganizationDto()
            {
                Id = item.Id,
                Name = item.Name
            }).ToHashSet();
        }

        public GetCourseDetailDto ConvertToWebModel(GetCourseDetail getCourseDetail)
        {
            return new GetCourseDetailDto()
            {
                CourseStatusId = getCourseDetail.CourseStatusId,
                Description = getCourseDetail.Description,
                Name = getCourseDetail.Name,
                CourseTypeId = getCourseDetail.CourseTypeId,
                FileName = "",
                Id = getCourseDetail.Id,
                IsPrivateCourse = getCourseDetail.IsPrivateCourse,
                CoursePrice = new WebModel.Shared.CoursePriceDto()
                {
                    Price = getCourseDetail.Price,
                    Sale = getCourseDetail.Sale
                },
                CourseType = _courseTypes.FirstOrDefault(x => x.Id == getCourseDetail.CourseTypeId).SystemIdentificator,
                MaximumStudent = getCourseDetail.MaximumStudent,
                MinimumStudent = getCourseDetail.MinimumStudent,
                CertificateId = getCourseDetail.CertificateId,
                AutomaticGenerateCertificate = getCourseDetail.AutomaticGenerateCertificate,
                CourseMaterialId = getCourseDetail.CourseMaterialId,
                SendEmail = getCourseDetail.SendEmail,
                SendMessageId = getCourseDetail.SendMessageId,
                CourseWithLector =getCourseDetail.CourseWithLector
            };
        }
        public HashSet<GetMyCourseDto> ConvertToWebModel(HashSet<GetMyCourse> getStudentCourses)
        {
            return getStudentCourses.Select(item => new GetMyCourseDto()
            {
                ActiveFrom = item.ActiveFrom,
                ActiveTo = item.ActiveTo,
                BranchName = item.BranchName,
                ClassRoom = item.ClassRoom,
                CourseName = item.CourseName,
                Friday = item.Friday,
                Id = item.Id,
                Monday = item.Monday,
                Saturday = item.Saturday,
                Sunday = item.Sunday,
                Thursday = item.Thursday,
                TimeFrom = item.TimeFrom,
                TimeTo = item.TimeTo,
                Tuesday = item.Tuesday,
                UserId = item.UserId,
                Wednesday = item.Wednesday,
                OrganizationName = item.OrganizationName,
                CourseStudentId = item.CourseStudentId,
                CourseFinish = item.CourseFinish,
                CourseTermId = item.TermId
            }).ToHashSet();

        }

        public ShowTestResultDto ConvertToWebModel(ShowTestResult showTestResult)
        {
            return new ShowTestResultDto()
            {
                Finish = showTestResult.Finish,
                Id = showTestResult.Id,
                Question = showTestResult.GetUserTestQuestions.Select(x => new ShowTestResultQuestionDto()
                {
                    Id = x.Id,
                    IsTrue = x.IsTrue,
                    TestQuestionId = x.TestQuestionId,
                    UserAnswers = x.Answers.Select(y => new ShowTestResultAnswerDto()
                    {
                        Id = y.Id,
                        IsTrueAnswer = y.IsTrue,
                        TestQuestionAnswerId = y.TestQuestionAnswerId,
                        Text = y.Text
                    }).ToHashSet()
                }).ToHashSet(),
                Score = showTestResult.Score,
                StartTime = showTestResult.StartTime,
                TestCompleted = showTestResult.TestCompleted
            };
        }

        public HashSet<GetStudentTestDto> ConvertToWebModel(HashSet<GetStudentTest> getStudentTests)
        {
            return getStudentTests.Select(x => new GetStudentTestDto()
            {
                Finish = x.Finish,
                Id = x.Id,
                Name = x.Name,
                Score = x.Score,
                TestCompleted = x.TestCompleted,
                TestId = x.TestId,
                CourseMaterialId = x.CourseMaterialId,
                CourseId = x.CourseId

            }).ToHashSet();
        }
    }
}
