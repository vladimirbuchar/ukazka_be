using Core.DataTypes;
using EduFacade.UserFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebModel.Shared;
using WebModel.User;

namespace EduApi.Controllers.Web.User
{
    public class UserController : BaseWebController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade, ILogger<UserController> logger) : base(logger)
        {
            _userFacade = userFacade;
        }
        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEduGit/_wiki/wikis/MyEduGit.wiki?wikiVersion=GBwikiMaster&pagePath=%2FU%C5%BEivatelsk%C3%A9%20%C3%BA%C4%8Dty%2FREST%20slu%C5%BEby%2FCreateNewUser&pageId=72
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult AddUser(AddUserDto addUserDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    TestRequest = true,
                    Request = addUserDto
                });
                return SendResponse(_userFacade.AddUser(addUserDto, true));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(LoginUserDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetUserToken([FromQuery] GetUserTokenDto getUserTokenDto)
        {
            try
            {
                return SendResponse(_userFacade.GetUserToken(getUserTokenDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(LoginUserDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult LoginSocialNetwork([FromQuery] LoginSocialNetworkDto getUserTokenDto)
        {
            try
            {
                return SendResponse(_userFacade.LoginSocialNetwork(getUserTokenDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult ActivateUser(ActivateUserDto activateUserDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    TestRequest = true,
                    Request = activateUserDto
                });
                return SendResponse(_userFacade.ActivateUser(activateUserDto.UserId));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GeneratePasswordResetEmail(GeneratePasswordResetEmailDto generatePasswordResetEmailDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    TestRequest = true,
                    Request = generatePasswordResetEmailDto
                });
                _userFacade.GeneratePasswordResetEmail(generatePasswordResetEmailDto);
                return SendResponse();
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult SetNewPassword(SetNewPasswordDto setNewPasswordDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    TestRequest = true,
                    Request = setNewPasswordDto
                });
                return SendResponse(_userFacade.SetNewPassword(setNewPasswordDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}

