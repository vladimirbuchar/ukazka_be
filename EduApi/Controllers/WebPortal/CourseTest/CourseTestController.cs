using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.CourseLesson;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using EduFacade.TestFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebModel.CourseTest;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.CourseLesson
{
    public class CourseTestController : BaseWebPortalController
    {
        private readonly ITestFacade _testFacade;
        public CourseTestController(ILogger<CourseTestController> logger, ITestFacade testFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _testFacade = testFacade;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseTest(AddCourseTestDto addCourseTestDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCourseTestDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseMaterial(addCourseTestDto.MaterialId),
                    OperationType = new OperationType(new AddCourseLessonOperation()),
                    Request = addCourseTestDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_testFacade.AddCourseTest(addCourseTestDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(GetCourseTestDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseTestDetail([FromQuery] string accessToken, [FromQuery] Guid courseLessonId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationByCourseLesson(courseLessonId),
                    OperationType = new OperationType(new GetCourseLessonDetailOperation()),
                    ValidateAccessToken = true
                });
                return SendResponse(_testFacade.GetCourseTestDetail(courseLessonId));
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
        public ActionResult UpdateCourseTest(UpdateCourseTestDto updateCourseTestDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseTestDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseLesson(updateCourseTestDto.Id),
                    OperationType = new OperationType(new UpdateCourseLessonOperation()),
                    Request = updateCourseTestDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_testFacade.UpdateCourseTest(updateCourseTestDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetAllStudentTestResultDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllStudentTestResult([FromQuery] string accessToken, [FromQuery] Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByCourse(courseId),
                    OperationType = new OperationType(new GetAllStudentTestResultOperation()),
                    ValidateAccessToken = true
                });
                return SendResponse(_testFacade.GetAllStudentTestResult(courseId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShowStudentAnswerDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ShowStudentAnswer([FromQuery] string accessToken, [FromQuery] Guid courseId, [FromQuery] Guid studentTestResultId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByCourse(courseId),
                    OperationType = new OperationType(new ShowStudentAnswerOperation()),
                    ValidateAccessToken = true
                });
                return SendResponse(_testFacade.ShowStudentAnswer(studentTestResultId));
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
        public ActionResult SetLectorControl(SetLectorControlDto setLectorControlDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = setLectorControlDto.UserAccessToken,
                    /*OrganizationId = GetOrganizationByCourseLesson(updateCourseTestDto.Id),
                    OperationType = new OperationType(new UpdateCourseLessonOperation()),*/
                    Request = setLectorControlDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _testFacade.SetLectorControl(setLectorControlDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
