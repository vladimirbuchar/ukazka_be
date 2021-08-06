using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation;
using EduCore.EduOperation.CourseTerm;
using EduFacade.AuthFacade;
using EduFacade.CourseTermFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Course;
using WebModel.CourseTerm;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.CourseTerm
{
    public class CourseTermController : BaseWebPortalController
    {
        private readonly ICourseTermFacade _courseTermFacade;
        public CourseTermController(ICourseTermFacade courseTermFacade, ILogger<CourseTermController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseTermFacade = courseTermFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseTerm(AddCourseTermDto addCourseTermDto)
        {
            try
            {
                Guid organizationId = GetOrganizationIdByCourse(addCourseTermDto.CourseId);
                Test(
                    new TestRequestSettings()
                    {
                        AccessToken = addCourseTermDto.UserAccessToken,
                        OrganizationId = organizationId,
                        OperationType = new OperationType(new GetMyNotificationOperation()),
                        Request = addCourseTermDto,
                        TestRequest = true,
                        ValidateAccessToken = true
                    });
                return SendResponse(_courseTermFacade.AddCourseTerm(addCourseTermDto, organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllTermInCourseDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllTermInCourse([FromQuery] string accessToken, [FromQuery] Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new GetAllTermInCourseOperation()),
                    OrganizationId = GetOrganizationIdByCourse(courseId)
                });
                return SendResponse(_courseTermFacade.GetAllTermInCourse(courseId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetCourseTermDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseTermDetail([FromQuery] string accessToken, [FromQuery] Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(courseTermId),
                    OperationType = new OperationType(new GetCourseTermDetailOperation())
                });
                return SendResponse(_courseTermFacade.GetCourseTermDetail(courseTermId));
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
        public ActionResult UpdateCourseTerm(UpdateCourseTermDto updateCourseTermDto)
        {
            try
            {
                Guid organizationId = GetOrganizationIdByCourseTerm(updateCourseTermDto.Id);
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseTermDto.UserAccessToken,
                    OrganizationId = organizationId,
                    OperationType = new OperationType(new UpdateCourseTermOperation()),
                    Request = updateCourseTermDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseTermFacade.UpdateCourseTerm(updateCourseTermDto, organizationId, GetUserByAccessToken(updateCourseTermDto.UserAccessToken).Id));
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
        public ActionResult DeleteCourseTerm(string accessToken, Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteCourseTermOperation()),
                    OrganizationId = GetOrganizationIdByCourseTerm(courseTermId)
                });
                _courseTermFacade.DeleteCourseTerm(courseTermId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetCourseTermDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetTimeTable([FromQuery] string accessToken, [FromQuery] Guid courseTermId)
        {
            Test(new TestRequestSettings()
            {
                AccessToken = accessToken,
                ValidateAccessToken = true,
                OperationType = new OperationType(new GetAllTermInCourseOperation()),
                OrganizationId = GetOrganizationIdByCourseTerm(courseTermId)
            });
            return SendResponse(_courseTermFacade.GetTimeTable(courseTermId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GenerateTimeTable(GenerateTimeTableDto generateTimeTableDto)
        {
            try
            {

                Test(
                    new TestRequestSettings()
                    {
                        AccessToken = generateTimeTableDto.UserAccessToken,
                        OrganizationId = GetOrganizationIdByCourseTerm(generateTimeTableDto.CourseTermId),
                        OperationType = new OperationType(new GetMyNotificationOperation()),
                        Request = generateTimeTableDto,
                        TestRequest = true,
                        ValidateAccessToken = true
                    });
                _courseTermFacade.GenerateTimeTable(generateTimeTableDto.CourseTermId);
                return SendResponse();
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
        public ActionResult CancelCourseTerm(CancelCourseTermDto cancelCourseTermDto)
        {
            try
            {
                Guid organizationId = GetOrganizationIdByCourseTerm(cancelCourseTermDto.CourseTermId);
                Test(new TestRequestSettings()
                {
                    AccessToken = cancelCourseTermDto.UserAccessToken,
                    OrganizationId = organizationId,
                    OperationType = new OperationType(new UpdateCourseTermOperation()),
                    Request = cancelCourseTermDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _courseTermFacade.CancelCourseTerm(cancelCourseTermDto.Id);
                return SendResponse();
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
        public ActionResult RestoreCourseTerm(RestoreCourseTermDto restoreCourseTermDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = restoreCourseTermDto.UserAccessToken,
                    OrganizationId = GetOrganizationIdByCourseTerm(restoreCourseTermDto.CourseTermId),
                    OperationType = new OperationType(new UpdateCourseTermOperation()),
                    Request = restoreCourseTermDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _courseTermFacade.RestoreCourseTerm(restoreCourseTermDto.Id);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(HashSet<GetStudentAttendanceDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetStudentAttendance([FromQuery] string accessToken, [FromQuery] Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseTermFacade.GetStudentAttendance(courseTermId));
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
        public ActionResult SaveStudentAttendance(SaveStudentAttendanceDto saveStudentAttendanceDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = saveStudentAttendanceDto.UserAccessToken
                });
                _courseTermFacade.SaveStudentAttendance(saveStudentAttendanceDto.StudentId, saveStudentAttendanceDto.TimeTableId, saveStudentAttendanceDto.CourseTermId, saveStudentAttendanceDto.IsActive);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(HashSet<GetStudentEvaluationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetStudentEvaluation([FromQuery] string accessToken, [FromQuery] Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken
                });
                return SendResponse(_courseTermFacade.GetStudentEvaluation(courseTermId));
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
        public ActionResult AddStudentEvaluation(AddStudentEvaluationDto addStudentEvaluationDto)
        {
            try
            {

                Test(
                    new TestRequestSettings()
                    {
                        AccessToken = addStudentEvaluationDto.UserAccessToken,
                        OrganizationId = GetOrganizationIdByCourseTerm(addStudentEvaluationDto.CourseTermId),
                        OperationType = new OperationType(new GetMyNotificationOperation()),
                        Request = addStudentEvaluationDto,
                        TestRequest = true,
                        ValidateAccessToken = true
                    });
                _courseTermFacade.AddStudentEvaluation(addStudentEvaluationDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

    }
}
