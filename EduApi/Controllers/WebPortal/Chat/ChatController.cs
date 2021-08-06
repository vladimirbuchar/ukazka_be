using Core.DataTypes;
using EduApi.Controllers.WebPortal.Course;
using EduCore.DataTypes;
using EduCore.EduOperation.Course;
using EduFacade.AnswerFacade;
using EduFacade.AuthFacade;
using EduFacade.CourseFacade;
using EduFacade.LicenseFacade;
using EduFacade.NoteFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Answer;
using WebModel.CourseTest;
using WebModel.Note;
using WebModel.Shared;
using WebModel.Student;

namespace EduApi.Controllers.WebPortal.Note
{
    public class ChatController : BaseWebPortalController
    {
        private readonly IChatFacade _chatFacade;
        public ChatController(IChatFacade chatFacade, ILogger<NoteController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _chatFacade = chatFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddChatItem(AddChatItemDto  addChatItemDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addChatItemDto.UserAccessToken,
                    Request = addChatItemDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_chatFacade.AddChatItem(addChatItemDto));
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
        public ActionResult UpdateChatItem(UpdateChatItemDto updateChatItemDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateChatItemDto.UserAccessToken,
                    Request = updateChatItemDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _chatFacade.UpdateChatItem(updateChatItemDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(HashSet<GetAllChatItemDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllChatItem([FromQuery] string accessToken, [FromQuery] Guid courseTermId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    
                });
                return SendResponse(_chatFacade.GetAllChatItem(courseTermId, GetUserByAccessToken(accessToken).Id));
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
        public ActionResult DeleteChatItem([FromQuery] string accessToken, [FromQuery] Guid chatItemId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true
                });
                _chatFacade.DeleteChatItem(chatItemId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        
        



    }

}
