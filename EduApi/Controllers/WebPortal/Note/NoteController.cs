using Core.DataTypes;
using EduApi.Controllers.WebPortal.Course;
using EduCore.DataTypes;
using EduCore.EduOperation.Course;
using EduFacade.AuthFacade;
using EduFacade.CourseFacade;
using EduFacade.LicenseFacade;
using EduFacade.NoteFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.CourseTest;
using WebModel.Note;
using WebModel.Shared;
using WebModel.Student;

namespace EduApi.Controllers.WebPortal.Note
{
    public class NoteController : BaseWebPortalController
    {
        private readonly INoteFacade _noteFacade;
        public NoteController(INoteFacade noteFacade, ILogger<NoteController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _noteFacade = noteFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddNote(AddNoteDto addNoteDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addNoteDto.UserAccessToken,
                    Request = addNoteDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_noteFacade.AddNote(addNoteDto, GetUserByAccessToken(addNoteDto.UserAccessToken).Id));
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
        public ActionResult SaveTableAsNote(SaveTableAsNoteDto saveTableAsNoteDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = saveTableAsNoteDto.UserAccessToken,
                    Request = saveTableAsNoteDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_noteFacade.SaveTableAsNote(saveTableAsNoteDto, GetUserByAccessToken(saveTableAsNoteDto.UserAccessToken).Id));
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
        public ActionResult UpdateNote(UpdateNoteDto updateNoteDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateNoteDto.UserAccessToken,
                    Request = updateNoteDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _noteFacade.UpdateNote(updateNoteDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(HashSet<GetMyNoteDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyNote([FromQuery] string accessToken, [FromQuery] Guid userId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    ValidateByUserId = true,
                    UserId = userId
                });
                return SendResponse(_noteFacade.GetMyNote(userId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(GetNoteDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetNoteDetail([FromQuery] string accessToken, [FromQuery] Guid noteId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    
                });
                return SendResponse(_noteFacade.GetNoteDetail(noteId));
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
        public ActionResult DeleteNote([FromQuery] string accessToken, [FromQuery] Guid noteId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true
                });
                _noteFacade.DeleteNote(noteId);
                return SendResponse();
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
        public ActionResult AddNoteImage(SaveImageNoteDto saveImageNoteDto )
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = saveImageNoteDto.UserAccessToken,
                    ValidateAccessToken = true
                });
                return SendResponse(_noteFacade.SaveFile(saveImageNoteDto, GetUserByAccessToken(saveImageNoteDto.UserAccessToken).Id));
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
        public ActionResult UpdateNoteImage(UpdateNoteImageDto updateNoteImageDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateNoteImageDto.UserAccessToken,
                    Request = updateNoteImageDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                _noteFacade.UpdateNoteImage(updateNoteImageDto);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }



    }

}
