using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.SendMessage;
using EduCore.EduOperation.StudentInCourse;
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
using WebModel.Student;

namespace EduApi.Controllers.WebPortal.Certificate
{

    public class StudentGroupController : BaseWebPortalController
    {
        private readonly IStudentGroupFacade _studentGroupFacade;
        public StudentGroupController(IStudentGroupFacade studentGroupFacade, ILogger<StudentGroupController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _studentGroupFacade = studentGroupFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddStudentGroup(AddStudentGroupDto addStudentGroupDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addStudentGroupDto.UserAccessToken,
                    OrganizationId = addStudentGroupDto.OrganizationId,
                    OperationType = new OperationType(new AddStudentGroupOperation()),
                    Request = addStudentGroupDto,
                    TestRequest = true,
                    ValidateAccessToken = true,

                });
                return SendResponse(_studentGroupFacade.AddStudentGroup(addStudentGroupDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetStudentGroupInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetStudentGroupInOrganization([FromQuery] string accessToken, [FromQuery] Guid organizationId)
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
                return SendResponse(_studentGroupFacade.GetStudentGroupInOrganization(organizationId));
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
        public ActionResult UpdateStudentGroup(UpdateStudentGroupDto updateStudentGroupDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateStudentGroupDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateStudentGroupOperation()),
                    OrganizationId = GetOrganizationByStudentGroupId(updateStudentGroupDto.Id),
                    Request = updateStudentGroupDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_studentGroupFacade.UpdateStudentGroup(updateStudentGroupDto));
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
        public ActionResult DeleteStudentGroup(string accessToken, Guid studentGroupId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteStudentGroupOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByStudentGroupId(studentGroupId)
                });
                _studentGroupFacade.DeleteStudentGroup(studentGroupId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }



        //
        [HttpGet]
        [ProducesResponseType(typeof(GetStudentGroupDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetStudentGroupDetail([FromQuery] string accessToken, Guid studentGroupId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DetailStudentGroupOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByStudentGroupId(studentGroupId)
                });
                return SendResponse(_studentGroupFacade.GetStudentGroupDetail(studentGroupId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        //
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddStudentToGroup(AddStudentToGroupDto addStudentToGroupDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addStudentToGroupDto.UserAccessToken,
                    OrganizationId = GetOrganizationByStudentGroupId(addStudentToGroupDto.StudentGroupId),
                    OperationType = new OperationType(new AddStudentToGroupOperation()),
                    ValidateAccessToken = true,
                });
                return SendResponse(_studentGroupFacade.AddStudentToGroup(addStudentToGroupDto, GetOrganizationByStudentGroupId(addStudentToGroupDto.StudentGroupId)));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllStudentInGroupDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllStudentInGroup([FromQuery] string accessToken, [FromQuery] Guid studentGroupId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    ValidateAccessToken = true,
                    AccessToken = accessToken,
                    OrganizationId = GetOrganizationByStudentGroupId(studentGroupId),
                    OperationType = new OperationType(new GetStudentGroupInOrganizationOperation())
                });
                return SendResponse(_studentGroupFacade.GetAllStudentInGroup(studentGroupId));
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
        public ActionResult DeleteStudentFromGroup(string accessToken, Guid studentId, Guid studentGroupId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new DeleteStudentFromCourseTermOperation()),
                    OrganizationId = GetOrganizationByStudentGroupId(studentGroupId)
                });
                _studentGroupFacade.DeleteStudentFromGroup(studentId, studentGroupId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
