using EduCore.DataTypes;
using EduCore.EduOperation.Answer;
using EduCore.EduOperation.CourseLesson;
using EduCore.EduOperation.CourseLessonItem;
using EduCore.EduOperation.Organization;
using EduCore.EduOperation.Question;
using EduCore.EduOperation.SendMessage;
using EduFacade.AuthFacade;
using EduFacade.FileUploadFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Course
{
    public class FileUploadController : BaseWebPortalController
    {
        private readonly IFileUploadFacade _fileUploadFacade;
        public FileUploadController(IFileUploadFacade fileUploadFacade, ILogger<FileUploadController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _fileUploadFacade = fileUploadFacade;
        }
        [HttpDelete]
        public IActionResult FileDelete([FromQuery] string accessToken, [FromQuery] Guid objectId, [FromQuery] Guid parentId, [FromQuery] string operation)
        {
            Guid organizationId = Guid.Empty;
            OperationType operationType = null;
            if (operation == "courseLessonItem")
            {
                organizationId = GetOrganizationByCourseLessonItem(parentId);
                operationType = new OperationType(new AddCourseLessonItemOperation());
            }
            else if (operation == "courseMaterial")
            {
                organizationId = GetOrganizationByCourseMaterial(parentId);
                operationType = new OperationType(new AddCourseMaterialOperation());
            }
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OrganizationId = organizationId,
                    OperationType = operationType
                });
                _fileUploadFacade.FileDelete(objectId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        
        [HttpPost]
        public IActionResult FileUpload([FromQuery] string accessToken, [FromQuery] Guid objectOwner, List<IFormFile> file, [FromQuery] string afterUploadEvent, string importType)
        {
            Guid organizationId = Guid.Empty;
            OperationType operationType = null;
            bool delete = true;
            if (importType == "courseLesson")
            {
                organizationId = GetOrganizationByCourseMaterial(objectOwner);
                operationType = new OperationType(new AddCourseLessonOperation());
            }
            else if (importType == "courseLessonItem")
            {
                organizationId = GetOrganizationByCourseLessonItem(objectOwner);
                operationType = new OperationType(new AddCourseLessonItemOperation());
            }
            else if (importType == "organization")
            {
                organizationId = objectOwner;
                operationType = new OperationType(new SaveOrganizationSettingOperation());
            }
            else if (importType == "answer")
            {
                organizationId = GetOrganizationByAnswer(objectOwner);
                operationType = new OperationType(new AddAnswerOperation());
            }
            else if (importType == "question")
            {
                organizationId = GetOrganizationByQuestion(objectOwner);
                operationType = new OperationType(new AddQuestionOperation());
            }
            else if (importType == "courseMaterial")
            {
                organizationId = GetOrganizationByCourseMaterial(objectOwner);
                operationType = new OperationType(new AddCourseMaterialOperation());
                delete = false;
            }

            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true,
                    OrganizationId = organizationId,
                    OperationType = operationType
                });
                _fileUploadFacade.FileUpload(objectOwner, file, afterUploadEvent, accessToken, delete);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
