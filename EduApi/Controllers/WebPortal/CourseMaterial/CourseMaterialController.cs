using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.SendMessage;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using EduFacade.SendMessageFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.SendMessage;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Certificate
{

    public class CourseMaterialController : BaseWebPortalController
    {
        private readonly ICourseMaterialFacade _courseMaterialFacade;
        public CourseMaterialController(ICourseMaterialFacade courseMaterialFacade, ILogger<CourseMaterialController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _courseMaterialFacade = courseMaterialFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCourseMaterial(AddCourseMaterialDto addCourseMaterialDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCourseMaterialDto.UserAccessToken,
                    OrganizationId = addCourseMaterialDto.OrganizationId,
                    OperationType = new OperationType(new AddStudentGroupOperation()),
                    Request = addCourseMaterialDto,
                    TestRequest = true,
                    ValidateAccessToken = true,

                });
                return SendResponse(_courseMaterialFacade.AddCourseMaterial(addCourseMaterialDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCourseMaterialInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseMaterialInOrganization([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetStudentGroupInOrganizationOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseMaterialFacade.GetCourseMaterialInOrganization(organizationId));
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
        public ActionResult UpdateCourseMaterial(UpdateCourseMaterialDto updateCourseMaterialDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCourseMaterialDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateStudentGroupOperation()),
                    OrganizationId = GetOrganizationByCourseMaterial(updateCourseMaterialDto.Id),
                    Request = updateCourseMaterialDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_courseMaterialFacade.UpdateCourseMaterial(updateCourseMaterialDto));
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
        public ActionResult DeleteCourseMaterial(string accessToken, Guid courseMaterialId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteStudentGroupOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByCourseMaterial(courseMaterialId)
                });
                _courseMaterialFacade.DeleteCourseMaterial(courseMaterialId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }



        //
        [HttpGet]
        [ProducesResponseType(typeof(GetCourseMaterialDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseMaterialDetail([FromQuery] string accessToken, Guid courseMaterialId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DetailStudentGroupOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByCourseMaterial(courseMaterialId)
                });
                return SendResponse(_courseMaterialFacade.GetCourseMaterial(courseMaterialId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GetFilesDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetFiles([FromQuery] string accessToken, Guid courseMaterialId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetFilesOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByCourseMaterial(courseMaterialId)
                });
                return SendResponse(_courseMaterialFacade.GetFiles(courseMaterialId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<GetFilesDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetFilesStudent([FromQuery] string accessToken, Guid courseId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetFilesStudentOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationIdByCourse(courseId)
                });
                return SendResponse(_courseMaterialFacade.GetFilesStudent(courseId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
