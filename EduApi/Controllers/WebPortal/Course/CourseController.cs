using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.Course;
using EduFacade.AuthFacade;
using EduFacade.CourseFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Course;
using WebModel.CourseTest;
using WebModel.Shared;
using WebModel.Student;

namespace EduApi.Controllers.WebPortal.Course
{
    public class CourseController : BaseWebPortalController
    {
        private readonly ICourseFacade _courseFacade;
        public CourseController(ICourseFacade courseFacade, ILogger<CourseController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseFacade = courseFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourse(AddCourseDto addCourseDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCourseDto.UserAccessToken,
                    OrganizationId = addCourseDto.OrganizationId,
                    OperationType = new OperationType(new AddCourseOperation()),
                    Request = addCourseDto,
                    TestRequest = true,
                    ValidateAccessToken = true,
                    ValidateLicense = true
                });
                return SendResponse(_courseFacade.AddCourse(addCourseDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllCourseInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllCourseInOrganization([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetAllOrganizationCourseOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseFacade.GetAllCourseInOrganization(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetCourseDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseDetail([FromQuery] string accessToken, [FromQuery] Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetCourseDetailOperation()),
                    OrganizationId = GetOrganizationIdByCourse(courseId),
                    ValidateAccessToken = true,

                });
                return SendResponse(_courseFacade.GetCourseDetail(courseId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateCourseOperation()),
                    OrganizationId = GetOrganizationIdByCourse(updateCourseDto.Id),
                    Request = updateCourseDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseFacade.UpdateCourse(updateCourseDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult DeleteCourse(string accessToken, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteCourseOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationIdByCourse(courseId)
                });
                _courseFacade.DeleteCourse(courseId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetMyCourseDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyCourse([FromQuery] string accessToken, [FromQuery] bool hideFinishCourse)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.GetMyCourse(GetUserByAccessToken(accessToken).Id, hideFinishCourse));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetManagedCourseDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetManagedCourse([FromQuery] string accessToken)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.GetManagedCourse(GetUserByAccessToken(accessToken).Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseMenuItemDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseMenu([FromQuery] string accessToken, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.GetCourseMenu(courseId, GetUserByAccessToken(accessToken).Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllSlideIdDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllSlideId([FromQuery] string accessToken, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.GetAllSlideId(courseId, GetUserByAccessToken(accessToken).Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseLessonStudyDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult CourseMaterialBrowse([FromQuery] string accessToken, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.CourseMaterialBrowse(courseId, GetUserByAccessToken(accessToken).Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseLessonStudyDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GoToSlide([FromQuery] string accessToken, Guid slideId, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.GoToSlide(slideId, GetUserByAccessToken(accessToken).Id, courseId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult StartTest(StartTestDto startTestDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = startTestDto.UserAccessToken,
                    Request = startTestDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseFacade.StartTest(startTestDto.CourseLessonId, GetUserByAccessToken(startTestDto.UserAccessToken).Id, startTestDto.CourseId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult EvaluateTest(EvaluateTestDto evaluateTestDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = evaluateTestDto.UserAccessToken
                });
                return SendResponse(_courseFacade.EvaluateTest(evaluateTestDto.UserTestSummaryId ?? Guid.Empty, evaluateTestDto.EvaluateQuestions, evaluateTestDto.CourseLessonId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<ShowTestResultDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ShowTestResult([FromQuery] string accessToken, Guid userTestSummaryId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.ShowTestResult(userTestSummaryId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<GetStudentTestDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetStudentTest([FromQuery] string accessToken)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.GetStudentTest(GetUserByAccessToken(accessToken).Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(FinishCourseDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult FinishCourse([FromQuery] string accessToken, Guid courseStudentId, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseFacade.FinishCourse(GetUserByAccessToken(accessToken).Id, courseStudentId, courseId, GetOrganizationIdByCourse(courseId)));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ResetCourse(ResetCourseDto resetCourseDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = resetCourseDto.UserAccessToken
                });
                _courseFacade.ResetCourse(resetCourseDto.StudentTermId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateActualTable(UpdateActualTableDto updateActualTableDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = updateActualTableDto.UserAccessToken
                });
                _courseFacade.UpdateActualTable(updateActualTableDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetActualTable([FromQuery] string userAccessToken, [FromQuery] Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = userAccessToken
                });
                return SendResponse(_courseFacade.GetActualTable(courseTermId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        //CreateLiveBroadcastEvent
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult CreateLiveBroadcastEvent(CreateLiveBroadcastEventDto createLiveBroadcastEventDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = createLiveBroadcastEventDto.UserAccessToken
                });
                _courseFacade.CreateLiveBroadcastEvent(createLiveBroadcastEventDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }



    }

}
