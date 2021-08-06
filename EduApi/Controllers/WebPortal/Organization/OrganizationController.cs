﻿using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.Organization;
using EduFacade.AuthFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using EduFacade.OrganizationFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Organization;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Organization
{
    public class OrganizationController : BaseWebPortalController
    {
        private readonly IOrganizationFacade _organizationFacade;
        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationFacade organizationFacade, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _organizationFacade = organizationFacade;
        }


        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20AddOrganization&pageId=2
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddOrganization([FromBody] AddOrganizationDto addOrganizationDto)
        {
            try
            {
                return SendResponse(_organizationFacade.AddOrganization(GetUserByAccessToken(addOrganizationDto.UserAccessToken).Id, addOrganizationDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20DeleteOrganization&pageId=18
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult DeleteOrganization(string accessToken, Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = organizationId,
                    OperationType = new OperationType(new DeleteOrganizationOperation()),
                    ValidateAccessToken = true
                });
                _organizationFacade.DeleteOrganization(organizationId);
                return SendResponse();
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetMyOrganizationsDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyOrganizations([FromQuery] string accessToken)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true
                });
                return SendResponse(_organizationFacade.GetMyOrganizations(GetUserByAccessToken(accessToken).Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20GetOrganizationDetail&pageId=19
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetOrganizationDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetOrganizationDetail([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new GetOrganizationDetailOperation()),
                    OrganizationId = organizationId
                });
                return SendResponse(_organizationFacade.GetOrganizationDetail(organizationId));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20UpdateOrganization&pageId=16
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateOrganization(UpdateOrganizationDto updateOrganizationDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateOrganizationDto.UserAccessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new UpdateOrganizationOperation()),
                    OrganizationId = updateOrganizationDto.Id
                });
                return SendResponse(_organizationFacade.UpdateOrganization(updateOrganizationDto));
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
        public ActionResult SaveOrganizationSetting(SaveOrganizationSettingDto saveOrganizationSettingDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = saveOrganizationSettingDto.UserAccessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new SaveOrganizationSettingOperation()),
                    OrganizationId = saveOrganizationSettingDto.OrganizationId
                });
                return SendResponse(_organizationFacade.SaveOrganizationSetting(saveOrganizationSettingDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetOrganizationSettingDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetOrganizationSetting([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new GetOrganizationSettingOperation()),
                    OrganizationId = organizationId
                });
                return SendResponse(_organizationFacade.GetOrganizationSetting(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetOrganizationCultureDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetOrganizationCulture([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new GetOrganizationCultureOperation()),
                    OrganizationId = organizationId
                });
                return SendResponse(_organizationFacade.GetOrganizationCulture(organizationId));
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
        public ActionResult AddStudyHours([FromBody] AddStudyHoursDto addOrganizationDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addOrganizationDto.UserAccessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new SaveOrganizationSettingOperation()),
                    OrganizationId = addOrganizationDto.OrganizationId
                });
                _organizationFacade.AddStudyHour(addOrganizationDto);
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
        public ActionResult UpdateStudyHours([FromBody] UpdateStudyHoursDto updateStudyHoursDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateStudyHoursDto.UserAccessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new SaveOrganizationSettingOperation()),
                    OrganizationId = updateStudyHoursDto.OrganizationId
                });
                _organizationFacade.UpdateStudyHour(updateStudyHoursDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<GetStudyHoursDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetStudyHours([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OperationType = new OperationType(new GetOrganizationSettingOperation()),
                    OrganizationId = organizationId
                });
                return SendResponse(_organizationFacade.GetStudyHours(organizationId));
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
        public ActionResult DeleteStudyHours(string accessToken, Guid organizationId, Guid studyHourId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OrganizationId = organizationId,
                    OperationType = new OperationType(new DeleteOrganizationOperation()),
                    ValidateAccessToken = true
                });
                _organizationFacade.DeleteStudyHour(studyHourId);
                return SendResponse();
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

    }
}
