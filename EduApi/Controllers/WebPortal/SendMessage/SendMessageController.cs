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

    public class SendMessageController : BaseWebPortalController
    {
        private readonly ISendMessageFacade _sendMessageFacade;
        public SendMessageController(ISendMessageFacade sendMessageFacade, ILogger<SendMessageController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _sendMessageFacade = sendMessageFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddSendMessage(AddSendMessageDto addSendMessageDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addSendMessageDto.UserAccessToken,
                    OrganizationId = addSendMessageDto.OrganizationId,
                    OperationType = new OperationType(new AddSendMessageOperation()),
                    Request = addSendMessageDto,
                    TestRequest = true,
                    ValidateAccessToken = true,

                });
                return SendResponse(_sendMessageFacade.AddSendMessage(addSendMessageDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetSendMessageInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetSendMessageInOrganization([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetSendMessageInOrganizationOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_sendMessageFacade.GetSendMessageInOrganization(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetSendMessageInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetSendMessageInOrganizationEmail([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetSendMessageInOrganizationOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_sendMessageFacade.GetSendMessageInOrganizationEmail(organizationId));
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
        public ActionResult UpdateSendMessage(UpdateSendMessageDto updateSendMessageDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateSendMessageDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateSendMessageOperation()),
                    OrganizationId = GetOrganizationBySendMessage(updateSendMessageDto.Id),
                    Request = updateSendMessageDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_sendMessageFacade.UpdateSendMessage(updateSendMessageDto));
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
        public ActionResult DeleteSendMessage(string accessToken, Guid sendMessageId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteSendMessageOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationBySendMessage(sendMessageId)
                });
                _sendMessageFacade.DeleteSendMessage(sendMessageId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }



        //
        [HttpGet]
        [ProducesResponseType(typeof(GetSendMessageDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetSendMessageDetail([FromQuery] string accessToken, Guid sendMessageId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DetailSendMessageOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationBySendMessage(sendMessageId)
                });
                return SendResponse(_sendMessageFacade.GetSendMessageDetail(sendMessageId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
