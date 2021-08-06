using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.CourseLesson;
using EduFacade.AuthFacade;
using EduFacade.CourseLessonFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.CourseLesson;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.CourseLesson
{
    public class CourseLesson : BaseWebPortalController
    {
        private readonly ICourseLessonFacade _courseLessonFacade;
        public CourseLesson(ILogger<CourseLesson> logger, ICourseLessonFacade courseLessonFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseLessonFacade = courseLessonFacade;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseLesson(AddCourseLessonDto addCourseLessonDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCourseLessonDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseMaterial(addCourseLessonDto.MaterialId),
                    OperationType = new OperationType(new AddCourseLessonOperation()),
                    Request = addCourseLessonDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseLessonFacade.AddCourseLesson(addCourseLessonDto));
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
        public ActionResult ImportCourseLessonFromPowerPoint(ImportCourseLessonFromPowerPointDto importCourseLessonFromPowerPointDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = importCourseLessonFromPowerPointDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseMaterial(importCourseLessonFromPowerPointDto.ObjectOwner),
                    OperationType = new OperationType(new AddCourseLessonOperation()),
                    Request = importCourseLessonFromPowerPointDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _courseLessonFacade.ImportCourseLessonFromPowerPoint(importCourseLessonFromPowerPointDto);
                return Ok();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllLessonInCourseDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllLessonInCourse([FromQuery] string accessToken, [FromQuery] Guid materialId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationByCourseMaterial(materialId),
                    OperationType = new OperationType(new GetAllLessonInCourseOperation()),
                    ValidateAccessToken = true
                });
                return SendResponse(_courseLessonFacade.GetAllLessonInCourse(materialId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetCourseLessonDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseLessonDetail([FromQuery] string accessToken, [FromQuery] Guid courseLessonId)
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

                return SendResponse(_courseLessonFacade.GetCourseLessonDetail(courseLessonId));
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
        public ActionResult UpdateCourseLesson(UpdateCourseLessonDto updateCourseLessonDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseLessonDto.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseLesson(updateCourseLessonDto.Id),
                    OperationType = new OperationType(new UpdateCourseLessonOperation()),
                    Request = updateCourseLessonDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseLessonFacade.UpdateCourseLesson(updateCourseLessonDto));
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
        public ActionResult DeleteCourseLesson(string accessToken, Guid courseLessonId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationByCourseLesson(courseLessonId),
                    OperationType = new OperationType(new DeleteCourseLessonOperation()),
                    ValidateAccessToken = true
                });
                _courseLessonFacade.DeleteCourseLesson(courseLessonId);
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
        public ActionResult UpdatePositionCourseLesson(UpdatePositionCourseLessonDto updatePositionCourseLesson)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updatePositionCourseLesson.UserAccessToken,
                    OrganizationId = GetOrganizationByCourseLesson(Guid.Parse(updatePositionCourseLesson.Ids.First())),
                    OperationType = new OperationType(new UpdateCourseLessonOperation()),
                    Request = updatePositionCourseLesson,
                    TestRequest = true,
                    ValidateAccessToken = true
                });

                _courseLessonFacade.UpdatePositionCourseLesson(updatePositionCourseLesson);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

    }
}
