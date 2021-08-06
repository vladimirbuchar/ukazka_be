using Core.DataTypes;
using EduFacade.CourseFacade.Convertor;
using EduServices.AnswerService;
using EduServices.CertificateService;
using EduServices.CodeBookService;
using EduServices.CourseLectorService;
using EduServices.CourseLessonItemService;
using EduServices.CourseLessonService;
using EduServices.CourseService;
using EduServices.CourseStudentService;
using EduServices.FileUploadService;
using EduServices.GeneratePdfService;
using EduServices.OrganizationRoleService;
using EduServices.OrganizationService;
using EduServices.PrepareTextService;
using EduServices.QuestionService;
using EduServices.SendMailService;
using EduServices.TestService;
using EduServices.UserService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Model.Functions.Certificate;
using Model.Functions.Course;
using Model.Functions.CourseLesson;
using Model.Functions.CourseLessonItem;
using Model.Functions.CourseTest;
using Model.Functions.Organization;
using Model.Functions.SendMessage;
using Model.Functions.User;
using Model.Functions.UserInOrganization;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebModel.Course;
using WebModel.CourseTest;
using WebModel.Organization;
using WebModel.Student;

namespace EduFacade.CourseFacade
{
    public class CourseFacade : BaseFacade, ICourseFacade
    {
        private readonly ICourseService _courseService;
        private readonly ICourseConvertor _courseConvertor;
        private readonly ICourseStudentService _courseStudentService;
        private readonly ICourseLectorService _courseLectorService;
        private readonly ICourseLessonService _courseLessonService;
        private readonly ICourseLessonItemService _courseLessonItemService;
        private readonly ITestService _testService;
        private readonly IConfiguration _configuration;
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly IOrganizationService _organizationService;
        private readonly ICertificateService _certificateService;
        private readonly IGeneratePdfService _generatePdfService;
        private readonly IUserService _userService;
        private readonly ISendMailService _sendMailService;
        private readonly ISendMessageService _sendMessageService;
        private readonly string _fileRepositoryPath;
        private readonly IPrepareTextService _prepareTextService;
        private readonly IFileUploadService _fileUploadService;
        private readonly ICourseTableService _courseTable;


        public CourseFacade(IOrganizationRoleService organizationRoleService, ICourseService courseService, ICourseConvertor courseConvertor, ICourseStudentService courseStudentService, ICourseLectorService courseLectorService, ICourseLessonService courseLessonService, ICourseLessonItemService courseLessonItemService, ITestService testService, IConfiguration configuration, IAnswerService answerService, IQuestionService questionService, ICodeBookService codeBookService, IOrganizationService organizationService, ICertificateService certificateService, IGeneratePdfService generatePdfService, IUserService userService, ISendMailService sendMailService, ISendMessageService sendMessageService, IHostingEnvironment hostingEnvironment, IPrepareTextService prepareTextService, IFileUploadService fileUploadService, ICourseTableService courseTable)
        {
            _courseService = courseService;
            _courseConvertor = courseConvertor;
            _courseStudentService = courseStudentService;
            _courseLectorService = courseLectorService;
            _courseLessonService = courseLessonService;
            _courseLessonItemService = courseLessonItemService;
            _testService = testService;
            _configuration = configuration;
            _organizationRoleService = organizationRoleService;
            _organizationService = organizationService;
            _certificateService = certificateService;
            _generatePdfService = generatePdfService;
            _userService = userService;
            _sendMailService = sendMailService;
            _sendMessageService = sendMessageService;
            string projectRootPath = hostingEnvironment.ContentRootPath;
            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}{2}", parent, configuration.GetSection("FileRepository").Value, "certificate/");
            _prepareTextService = prepareTextService;
            _fileUploadService = fileUploadService;
            _courseTable = courseTable;
        }
        private Result Validate(AddCourseDto addCourseDto)
        {
            Result result = new Result();
            _courseService.ValidateCourseName(addCourseDto.Name, result);
            _courseService.ValidatePrice(addCourseDto.Price.Price, result);
            _courseService.ValidateStudentCount(addCourseDto.DefaultMinimumStudents, addCourseDto.DefaultMaximumStudents, result);
            _courseService.ValidateCourseStatus(addCourseDto.CourseStatusId, result);
            _courseService.ValidateCourseType(addCourseDto.CourseTypeId, result);
            return result;
        }
        private Result Validate(UpdateCourseDto updateCourseDto)
        {
            Result result = new Result();
            _courseService.ValidateCourseName(updateCourseDto.Name, result);
            _courseService.ValidatePrice(updateCourseDto.Price.Price, result);
            _courseService.ValidateStudentCount(updateCourseDto.DefaultMinimumStudents, updateCourseDto.DefaultMaximumStudents, result);
            _courseService.ValidateCourseStatus(updateCourseDto.CourseStatusId, result);
            _courseService.ValidateCourseType(updateCourseDto.CourseTypeId, result);
            return result;
        }

        public Result AddCourse(AddCourseDto addCourseDto)
        {
            Result validate = Validate(addCourseDto);
            if (validate.IsOk)
            {
                AddCourse addCourse = _courseConvertor.ConvertToBussinessEntity(addCourseDto);
                return new Result<Guid>()
                {
                    Data = _courseService.AddCourse(addCourse)
                };
            }
            return validate;
        }

        public IEnumerable<GetCourseOfferDto> GetCourseOffer(CourseFilterDto courseFilterDto)
        {
            return new List<GetCourseOfferDto>();
            // return courseService.GetCourseOffer(courseFilter);
        }


        public HashSet<GetAllCourseInOrganizationDto> GetAllCourseInOrganization(Guid organizationId)
        {
            return _courseConvertor.ConvertToWebModel(_courseService.GetAllCourseInOrganization(organizationId));
        }

        public GetCourseDetailDto GetCourseDetail(Guid courseId)
        {
            return _courseConvertor.ConvertToWebModel(_courseService.GetCourseDetail(courseId));
        }

        public Result UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            Result validate = Validate(updateCourseDto);
            if (validate.IsOk)
            {
                UpdateCourse updateCourse = _courseConvertor.ConvertToBussinessEntity(updateCourseDto);
                _courseService.UpdateCourse(updateCourse);
            }
            return validate;
        }

        public void DeleteCourse(Guid courseId)
        {
            _courseService.DeleteCourse(courseId);
        }
        public HashSet<GetMyCourseDto> GetMyCourse(Guid userId, bool hideFinishCourse)
        {
            HashSet<GetMyCourseDto> myCourse = new HashSet<GetMyCourseDto>();
            HashSet<GetMyCourseDto> study = _courseConvertor.ConvertToWebModel(_courseStudentService.GetStudentCourse(userId, hideFinishCourse));
            foreach (GetMyCourseDto item in study)
            {
                item.IsStudent = true;
            }
            HashSet<GetMyCourseDto> lector = _courseConvertor.ConvertToWebModel(_courseLectorService.GetLectorCourse(userId));
            foreach (GetMyCourseDto item in lector)
            {
                item.IsLector = true;
            }
            myCourse.UnionWith(study);
            myCourse.UnionWith(lector);
            myCourse = myCourse.OrderBy(x => x.CourseFinish).ThenBy(x => x.CourseName).ToHashSet();
            return myCourse;
        }

        public HashSet<CourseMenuItemDto> GetCourseMenu(Guid courseId, Guid userId)
        {
            HashSet<CourseMenuItemDto> courseMenuItems = new HashSet<CourseMenuItemDto>();
            HashSet<GetAllLessonInCourse> getAllLessonInCourses = _courseLessonService.GetAllLessonInCourse(_courseService.GetCourseDetail(courseId).CourseMaterialId);
            courseMenuItems = getAllLessonInCourses.OrderBy(x => x.Position).Select(x => new CourseMenuItemDto()
            {
                Id = x.Id,
                Name = x.Name,
                Items = _courseLessonItemService.GetCourseLessonItems(x.Id).OrderBy(z => z.Position).Select(y => new CourseMenuSubItemDto()
                {
                    Id = y.Id,
                    Name = y.Name,
                    Type = CourseLessonType.COURSE_ITEM
                }).ToHashSet(),
                Type = x.Type ?? CourseLessonType.COURSE_ITEM
            }).Where(x => x.Type == CourseLessonType.COURSE_TEST || x.Type == CourseLessonType.COURSE_ITEM_POWER_POINT || (x.Type == CourseLessonType.SUB_ITEM && x.Items.Count > 0)).ToHashSet();
            courseMenuItems.Add(new CourseMenuItemDto()
            {
                Id = Guid.Empty,
                Items = new HashSet<CourseMenuSubItemDto>(),
                Name = CourseLessonType.LAST_SLIDE,
                Type = CourseLessonType.LAST_SLIDE,
            });
            return courseMenuItems;
        }
        public GetUserOrganizationRoleDto CanCourseBrowse(Guid courseId, Guid userId)
        {
            GetAllUserInOrganization getAllUserInOrganizations = _organizationRoleService.GetAllUserInOrganization(_organizationRoleService.GetOrganizationIdByCourseId(courseId)).FirstOrDefault(x => x.UserId == userId && (x.IsCourseAdministrator || x.IsCourseEditor || x.IsOrganizationAdministrator || x.IsOrganizationOwner));
            if (getAllUserInOrganizations == null)
            {
                return new GetUserOrganizationRoleDto()
                {
                    IsCourseAdministrator = false,
                    IsCourseEditor = false,
                    IsOrganizationAdministrator = false,
                    IsOrganizationOwner = false,
                    IsLector = _courseLectorService.GetLectorCourse(userId).FirstOrDefault(x => x.Id == courseId) != null,
                    IsStudent = _courseStudentService.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
                };
            }
            return new GetUserOrganizationRoleDto()
            {
                IsCourseAdministrator = getAllUserInOrganizations.IsOrganizationOwner,
                IsCourseEditor = getAllUserInOrganizations.IsOrganizationOwner,
                IsOrganizationAdministrator = getAllUserInOrganizations.IsOrganizationOwner,
                IsOrganizationOwner = getAllUserInOrganizations.IsOrganizationOwner,
                IsLector = _courseLectorService.GetLectorCourse(userId).FirstOrDefault(x => x.Id == courseId) != null,
                IsStudent = _courseStudentService.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null
            };
        }
        public CourseLessonStudyDto CourseMaterialBrowse(Guid courseId, Guid userId)
        {
            GetUserOrganizationRoleDto getUserOrganizationRoleDto = CanCourseBrowse(courseId, userId);
            if (getUserOrganizationRoleDto.IsLector || getUserOrganizationRoleDto.IsStudent)
            {
                GetUserCourseItem getUserCourseItem = _courseLessonItemService.GetUserCourseItem(courseId, userId);
                return GoToSlide(getUserCourseItem.CourseLessonItem, userId, courseId);
            }
            return null;
        }
        public CourseLessonStudyDto GoToSlide(Guid slideId, Guid userId, Guid courseId)
        {
            GetCourseLessonItemDetail getCourseLessonItemDetail = _courseLessonItemService.GetCourseLessonItemDetail(slideId);
            if (getCourseLessonItemDetail != null)
            {
                _courseService.SaveActiveSlide(slideId, userId, courseId);
                return new CourseLessonStudyDto()
                {
                    Name = getCourseLessonItemDetail?.Name,
                    Type = CourseLessonType.COURSE_ITEM,
                    Description = getCourseLessonItemDetail?.Description,
                    Html = getCourseLessonItemDetail?.Html,
                    TemplateIdentificator = getCourseLessonItemDetail?.TemplateIdentificator,
                    ImagePath = string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, getCourseLessonItemDetail?.Id, getCourseLessonItemDetail?.FileName),
                    PowerPointFile = "",
                    SlideId = slideId,
                    Youtube = getCourseLessonItemDetail.Youtube
                };
            }
            GetCourseLessonPowerPointFile getCourseLessonPowerPointFile = _courseLessonItemService.GetCourseLessonPowerPointFile(slideId);
            if (getCourseLessonPowerPointFile != null && !string.IsNullOrEmpty(getCourseLessonPowerPointFile.PowerPointFile))
            {
                _courseService.SaveActiveSlide(slideId, userId, courseId);
                return new CourseLessonStudyDto()
                {
                    Name = getCourseLessonPowerPointFile?.Name,
                    Type = CourseLessonType.COURSE_ITEM_POWER_POINT,
                    Description = getCourseLessonPowerPointFile?.Description,
                    Html = "",
                    TemplateIdentificator = "",
                    ImagePath = "",
                    PowerPointFile = string.Format("{0}{1}", _configuration.GetSection("FileServerUrl").Value, getCourseLessonPowerPointFile.PowerPointFile),
                    SlideId = slideId,

                };
            }
            GetCourseTestDetail getCourseTestDetail = _testService.GetCourseTestDetail(slideId);
            if (getCourseTestDetail != null)
            {
                _courseService.SaveActiveSlide(slideId, userId, courseId);

                return new CourseLessonStudyDto()
                {
                    Name = getCourseTestDetail?.Name,
                    Type = CourseLessonType.COURSE_TEST,
                    Description = getCourseTestDetail?.Description,
                    TimeLimit = getCourseTestDetail.TimeLimit,
                    Questions = _testService.GenerateTest(slideId, userId, courseId).Select(x => new CourseLessonQuestionStudyDto()
                    {
                        AnswerMode = x.AnswerMode,
                        QuestionMode = x.QuestionMode,
                        Id = x.Id,
                        Question = x.Question,
                        FilePath = string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, x.ObjectOwner, x.FileName),
                        Answers = x.Answer.Select(y => new CourseLessonAnswerDto()
                        {
                            Answer = y.Answer,
                            Id = y.Id,
                            FilePath = string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, y.ObjectOwner, y.FileName)

                        }).ToHashSet()

                    }).ToHashSet(),
                    SlideId = slideId,
                    CanRunTest = _testService.CanRunTest(slideId, userId)
                };

            }
            return null;
        }
        public HashSet<GetStudentTestDto> GetStudentTest(Guid userId)
        {
            return _courseConvertor.ConvertToWebModel(_testService.GetStudentTest(userId));
        }
        public Guid StartTest(Guid courseLessonId, Guid userId, Guid courseId)
        {
            GetCourseTestDetail getCourseTestDetail = _testService.GetCourseTestDetail(courseLessonId);
            return _testService.StartTest(getCourseTestDetail.TestId, userId, courseId);
        }
        public EvaluateTest EvaluateTest(Guid userTestSummaryId, List<EvaluateQuestionDto> evaluateTestDtos, Guid courseLessonId)
        {
            if (userTestSummaryId == Guid.Empty)
            {
                return new EvaluateTest();
            }
            EvaluateTest evaluateTest = new EvaluateTest
            {
                Id = userTestSummaryId
            };
            foreach (EvaluateQuestionDto item in evaluateTestDtos)
            {
                Guid fileName = Guid.Empty;
                if (!string.IsNullOrEmpty(item.TextManualAnswer))
                {
                    fileName = _fileUploadService.SaveFilePngFile(item.TextManualAnswer,"test");
                }
                _testService.EvaluateQuestion(userTestSummaryId, item.QuestionId, item.AnswerId, item.TextAnswer,fileName);
            }
            EvaluateTestResult evaluateTestResult = _testService.EvaluateTest(userTestSummaryId);
            evaluateTest.IsAutomatic = evaluateTestResult.IsAutomatic;
            evaluateTest.IsSucess = evaluateTestResult.Sucess;
            evaluateTest.Score = evaluateTestResult.Score;

            return evaluateTest;

        }

        public HashSet<ShowTestResultQuestionDto> ShowTestResult(Guid userTestSummaryId)
        {
            return _testService.ShowStudentAnswer(userTestSummaryId).GetUserTestQuestions.Select(x => new ShowTestResultQuestionDto()
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
            }).ToHashSet();
        }

        public GetUserOrganizationRoleDto CanShowStudentTestResult(Guid courseId, Guid userId)
        {
            return new GetUserOrganizationRoleDto()
            {
                IsCourseAdministrator = false,
                IsCourseEditor = false,
                IsLector = _courseLectorService.GetLectorCourse(userId).FirstOrDefault(x => x.Id == courseId) != null,
                IsOrganizationAdministrator = false,
                IsOrganizationOwner = false,
                IsStudent = _courseStudentService.GetStudentCourse(userId, false).FirstOrDefault(x => x.Id == courseId) != null

            };
        }

        public HashSet<GetAllSlideIdDto> GetAllSlideId(Guid courseId, Guid userId)
        {
            HashSet<GetAllSlideIdDto> courseMenuItems = new HashSet<GetAllSlideIdDto>();
            HashSet<CourseMenuItemDto> getAllLessonInCourses = GetCourseMenu(courseId, userId);
            foreach (CourseMenuItemDto item in getAllLessonInCourses)
            {
                HashSet<CourseMenuSubItemDto> subItems = item.Items;
                if (subItems.Count() > 0)
                {
                    foreach (CourseMenuSubItemDto subItem in subItems)
                    {
                        courseMenuItems.Add(new GetAllSlideIdDto()
                        {
                            Id = subItem.Id,
                            ParentId = item.Id,
                            Name = subItem.Name
                        });
                    }
                }
                else
                {
                    courseMenuItems.Add(new GetAllSlideIdDto()
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }
            return courseMenuItems;
        }

        public HashSet<GetManagedCourseDto> GetManagedCourse(Guid userId)
        {
            HashSet<GetMyOrganizations> org = _organizationService.GetMyOrganizations(userId).Where(x => x.IsOrganizationOwner || x.IsCourseAdministrator || x.IsCourseEditor || x.IsOrganizationAdministrator).ToHashSet();
            HashSet<GetManagedCourseDto> data = new HashSet<GetManagedCourseDto>();

            foreach (GetMyOrganizations item in org)
            {
                HashSet<GetAllCourseInOrganization> courses = _courseService.GetAllCourseInOrganization(item.Id);
                foreach (GetAllCourseInOrganization course in courses)
                {
                    data.Add(new GetManagedCourseDto()
                    {
                        CourseName = course.Name,
                        Id = course.Id,
                        OrganizationId = item.Id,
                        IsCourseAdministrator = item.IsCourseAdministrator,
                        IsCourseEditor = item.IsCourseEditor,
                        IsOrganizationAdministrator = item.IsOrganizationAdministrator,
                        IsOrganizationOwner = item.IsOrganizationOwner
                    });
                }

            }

            return data;
        }

        public FinishCourseDto FinishCourse(Guid userId, Guid courseStudentId, Guid courseId, Guid organizationId)
        {
            GetCourseDetail getCourseDetail = _courseService.GetCourseDetail(courseId);
            Guid fileName = Guid.Empty;
            bool pdfCreated = false;
            if (getCourseDetail.AutomaticGenerateCertificate)
            {
                GetCertificateDetail getCertificateDetail = _certificateService.GetCertificateDetail(getCourseDetail.CertificateId);
                string html = _prepareTextService.PrepareText(getCertificateDetail.Html, userId, organizationId, courseId, _courseService.GetCourseTermByCourseStudent(courseStudentId).CourseTermId);
                fileName = _generatePdfService.HtmlToPdfFile(html);
                DateTime certificateValidTo = DateTime.MaxValue;
                if (getCertificateDetail.CertificateValidTo > 0)
                {
                    certificateValidTo = certificateValidTo.AddMonths(getCertificateDetail.CertificateValidTo);
                }

                _certificateService.SaveUserCertificate(getCertificateDetail.Name, fileName.ToString(), userId, certificateValidTo);
                pdfCreated = true;
                if (getCourseDetail.SendEmail)
                {
                    GetSendMessageDetail getSendMessageDetail = _sendMessageService.GetSendMessageDetail(getCourseDetail.SendMessageId);
                    GetUserDetail getUserDetail = _userService.GetUserDetail(userId);
                    List<string> attachment = new List<string>
                    {
                        string.Format("{0}{1}.pdf", _fileRepositoryPath, fileName)
                    };
                    _sendMailService.SendEmail(getSendMessageDetail.Name, _prepareTextService.PrepareText(getSendMessageDetail.Html, userId, organizationId, courseId, _courseService.GetCourseTermByCourseStudent(courseStudentId).CourseTermId), attachment, new EmailAddress()
                    {
                        Email = getUserDetail.UserEmail
                    }, organizationId, getSendMessageDetail.Reply);
                }
            }
            _courseService.FinishCourse(courseStudentId);
            return new FinishCourseDto()
            {
                CertificatePdf = string.Format("{0}certificate/{1}.pdf", _configuration.GetSection("FileServerUrl").Value, fileName),
                PdfCreated = pdfCreated
            };
        }

        public void ResetCourse(Guid studentTermId)
        {
            _courseService.ResetCourse(studentTermId);
        }

        public void UpdateActualTable(UpdateActualTableDto updateActualTableDto)
        {
            _courseTable.UpdateActualTable(updateActualTableDto.CourseTermId, updateActualTableDto.Img);
        }

        public Result<string> GetActualTable(Guid courseTermid)
        {
            return new Result<string>() { Data = _courseTable.GetActualTable(courseTermid) };
        }

        public void CreateLiveBroadcastEvent(CreateLiveBroadcastEventDto createLiveBroadcastEventDto)
        {
            _courseService.CreateLiveBroadcastEvent(createLiveBroadcastEventDto.CourseTermId);
        }
    }
    }

