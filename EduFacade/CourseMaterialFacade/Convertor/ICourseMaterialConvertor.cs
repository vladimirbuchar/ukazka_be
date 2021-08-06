using Model.Functions.SendMessage;
using System.Collections.Generic;
using WebModel.SendMessage;

namespace EduFacade.SendMessageFacade.Convertor
{
    public interface ICourseMaterialConvertor
    {
        AddCourseMaterial CovertToBussinessEntity(AddCourseMaterialDto addCourseMaterialDto);
        HashSet<GetCourseMaterialInOrganizationDto> ConvertToWebModel(HashSet<GetCourseMaterialInOrganization> getCourseMaterialInOrganizations);
        UpdateCourseMaterial CovertToBussinessEntity(UpdateCourseMaterialDto updateCourseMaterialDto);
        GetCourseMaterialDetailDto ConvertToWebModel(GetCourseMaterialDetail getCourseMaterialDetail);
        HashSet<GetFilesDto> ConvertToWebModel(HashSet<GetFiles> getFiles);
    }

}
