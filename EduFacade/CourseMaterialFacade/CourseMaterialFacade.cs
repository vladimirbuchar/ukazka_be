using Core.DataTypes;
using EduFacade.SendMessageFacade.Convertor;
using EduServices.CertificateService;
using EduServices.CourseService;
using System;
using System.Collections.Generic;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade
{
    public class CourseMaterialFacade : BaseFacade, ICourseMaterialFacade
    {
        private readonly ICourseMaterialConvertor _courseMaterialConvertor;
        private readonly ICourseMaterialService _courseMaterialService;
        private readonly ICourseService _courseService;
        public CourseMaterialFacade(ICourseMaterialService courseMaterialService, ICourseMaterialConvertor courseMaterialConvertor, ICourseService courseService)
        {
            _courseMaterialConvertor = courseMaterialConvertor;
            _courseMaterialService = courseMaterialService;
            _courseService = courseService;
        }

        public Result AddCourseMaterial(AddCourseMaterialDto addCourseMaterialDto)
        {
            Result result = new Result();
            _courseMaterialService.ValidateName(addCourseMaterialDto.Name, result);
            if (result.IsOk)
            {
                Model.Functions.SendMessage.AddCourseMaterial addCourseMaterial = _courseMaterialConvertor.CovertToBussinessEntity(addCourseMaterialDto);
                return new Result<Guid>()
                {
                    Data = _courseMaterialService.AddCourseMaterial(addCourseMaterial)
                };

            }
            return result;
        }

        public void DeleteCourseMaterial(Guid sendMessageId)
        {
            _courseMaterialService.DeleteCourseMaterial(sendMessageId);
        }

        public GetCourseMaterialDetailDto GetCourseMaterial(Guid studentGroupId)
        {
            return _courseMaterialConvertor.ConvertToWebModel(_courseMaterialService.GetCourseMaterialDetail(studentGroupId));
        }

        public HashSet<GetCourseMaterialInOrganizationDto> GetCourseMaterialInOrganization(Guid organizationId)
        {
            return _courseMaterialConvertor.ConvertToWebModel(_courseMaterialService.GetCourseMaterialInOrganization(organizationId));
        }

        public HashSet<GetFilesDto> GetFiles(Guid courseMaterialId)
        {
            return _courseMaterialConvertor.ConvertToWebModel(_courseMaterialService.GetFiles(courseMaterialId));
        }

        public HashSet<GetFilesDto> GetFilesStudent(Guid courseId)
        {
            Guid courseMaterialId = _courseService.GetCourseDetail(courseId).CourseMaterialId;
            return GetFiles(courseMaterialId);
        }

        public Result UpdateCourseMaterial(UpdateCourseMaterialDto updateCourseMaterialDto)
        {
            Result result = new Result();
            _courseMaterialService.ValidateName(updateCourseMaterialDto.Name, result);
            if (result.IsOk)
            {
                Model.Functions.SendMessage.UpdateCourseMaterial updateCourseMaterial = _courseMaterialConvertor.CovertToBussinessEntity(updateCourseMaterialDto);
                _courseMaterialService.UpdateCourseMaterial(updateCourseMaterial);
            }
            return result;
        }
    }
}
