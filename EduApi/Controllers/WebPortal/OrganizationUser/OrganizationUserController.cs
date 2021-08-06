using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.UserInOrganization;
using EduFacade.AuthFacade;
using EduFacade.CourseFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using EduFacade.OrganizationFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Organization;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.OrganizationUser
{
    public class OrganizationUserController : BaseWebPortalController
    {
        private readonly IOrganizationFacade _organizationFacade;
        private readonly IOrganizationRoleFacade _organizationRoleFacade;
        private readonly ICourseFacade _courseFacade;
        public OrganizationUserController(ILogger<OrganizationUserController> logger, IOrganizationFacade organizationFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade, ICourseFacade courseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _organizationFacade = organizationFacade;
            _organizationRoleFacade = organizationRoleFacade;
            _courseFacade = courseFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddUserToOrganization(AddUserToOrganizationDto addUserToOrganizationDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addUserToOrganizationDto.UserAccessToken,
                    OperationType = new OperationType(new AdUserToOrganizationOperation()),
                    OrganizationId = addUserToOrganizationDto.OrganizationId,
                    ValidateAccessToken = true,
                    ValidateLicense = true
                });
                return SendResponse(_organizationFacade.AddUserToOrganization(addUserToOrganizationDto));

            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllUserInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllUserInOrganization([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OrganizationId = organizationId,
                    OperationType = new OperationType(new GetAllUserInOrganizationOperation())
                });
                return SendResponse(_organizationFacade.GetAllUserInOrganization(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetOrganizationRolesDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetOrganizationRoles()
        {
            try
            {
                return SendResponse(_organizationFacade.GetOrganizationRoles());
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
        public ActionResult DeleteUserFromOrganization(string accessToken, Guid userId, Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteUserFromOrganizationOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                _organizationFacade.DeleteUserFromOrganization(userId, organizationId);
                return SendResponse();

            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetUserOrganizationRoleDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetUserOrganizationRoleDetail([FromQuery] string accessToken, [FromQuery] Guid userId, Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetUserOrganizationRoleDetailOpertation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_organizationFacade.GetUserOrganizationRoleDetail(userId, organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateUserInOrganizationRole(UpdateUserInOrganizationRoleDto updateUserInOrganizationRoleDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateUserInOrganizationRoleDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateUserToOrganizationOperation()),
                    OrganizationId = updateUserInOrganizationRoleDto.OrganizationId,
                    ValidateAccessToken = true
                });
                _organizationFacade.UpdateUserInOrganizationRole(updateUserInOrganizationRoleDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUserOrganizationRoleDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetUserOrganizationRole([FromQuery] string accessToken, [FromQuery] Guid objectId, [FromQuery] string type)
        {
            try
            {
                if (type == "branch")
                {
                    objectId = GetOrganizationIdByBranch(objectId);
                }
                else if (type == "classroom")
                {
                    objectId = GetOrganizationIdByClassRoom(objectId);
                }
                else if (type == "userinorganization")
                {
                    objectId = GetOrganizationByUserInOrganization(objectId);
                }
                else if (type == "question")
                {
                    objectId = GetOrganizationByQuestion(objectId);
                }
                else if (type == "answer")
                {
                    objectId = GetOrganizationByAnswer(objectId);
                }
                else if (type == "bankOfQuestion")
                {
                    objectId = GetOrganizationIdByBankOfQuestion(objectId);
                }
                else if (type == "course")
                {
                    objectId = GetOrganizationIdByCourse(objectId);
                }
                else if (type == "courseLesson")
                {
                    objectId = GetOrganizationByCourseLesson(objectId);
                }
                else if (type == "courseLessonItem")
                {
                    objectId = GetOrganizationByCourseLessonItem(objectId);
                }
                else if (type == "courseTerm")
                {
                    objectId = GetOrganizationIdByCourseTerm(objectId);
                }
                else if (type == "question")
                {
                    objectId = GetOrganizationByQuestion(objectId);
                }
                else if (type == "certificate")
                {
                    objectId = GetOrganizationByCertificate(objectId);
                }
                else if (type == "sendmessage")
                {
                    objectId = GetOrganizationBySendMessage(objectId);
                }
                else if (type == "studentgroup")
                {
                    objectId = GetOrganizationByStudentGroupId(objectId);
                }
                else if (type == "coursematerialedit")
                {
                    objectId = GetOrganizationByCourseMaterial(objectId);
                }
                else if (type == "courseBrowse")
                {
                    return SendResponse(_courseFacade.CanCourseBrowse(objectId, GetUserByAccessToken(accessToken).Id));
                }
                else if (type == "showStudentTestResult")
                {
                    return SendResponse(_courseFacade.CanShowStudentTestResult(objectId, GetUserByAccessToken(accessToken).Id));
                }
                return SendResponse(_organizationRoleFacade.GetUserOrganizationRole(GetUserByAccessToken(accessToken).Id, objectId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

    }
}
