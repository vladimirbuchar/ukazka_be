using Microsoft.Extensions.Configuration;
using Model.Functions.SendMessage;
using System.Collections.Generic;
using System.Linq;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade.Convertor
{
    public class CourseMaterialConvertor : ICourseMaterialConvertor
    {
        private readonly IConfiguration _configuration;
        public CourseMaterialConvertor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HashSet<GetCourseMaterialInOrganizationDto> ConvertToWebModel(HashSet<GetCourseMaterialInOrganization> getCourseMaterialInOrganizations)
        {
            return getCourseMaterialInOrganizations.Select(x => new GetCourseMaterialInOrganizationDto()
            {
                Description = "",
                Name = x.Name,
                Id = x.Id
            }).ToHashSet();
        }

        public GetCourseMaterialDetailDto ConvertToWebModel(GetCourseMaterialDetail getCourseMaterialDetail)
        {
            return new GetCourseMaterialDetailDto()
            {
                Description = "",
                Id = getCourseMaterialDetail.Id,
                Name = getCourseMaterialDetail.Name
            };
        }

        public HashSet<GetFilesDto> ConvertToWebModel(HashSet<GetFiles> getFiles)
        {
            return getFiles.Select(x => new GetFilesDto()
            {
                FileName =x.FileName,
                Id =x.Id,
                ObjectOwner=x.ObjectOwner,
                OriginalFileName =x.OriginalFileName,
                Url = string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, x.ObjectOwner, x.FileName)
            }).ToHashSet();
        }

        public AddCourseMaterial CovertToBussinessEntity(AddCourseMaterialDto addCourseMaterialDto)
        {
            return new AddCourseMaterial()
            {
                Name = addCourseMaterialDto.Name,
                OrganizationId = addCourseMaterialDto.OrganizationId
            };
        }

        public UpdateCourseMaterial CovertToBussinessEntity(UpdateCourseMaterialDto updateCourseMaterialDto)
        {
            return new UpdateCourseMaterial()
            {
                Name = updateCourseMaterialDto.Name,
                Id = updateCourseMaterialDto.Id
            };
        }
    }
}
