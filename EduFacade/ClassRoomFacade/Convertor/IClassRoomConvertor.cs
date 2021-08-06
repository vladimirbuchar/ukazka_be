using Model.Functions;
using Model.Functions.ClassRoom;
using System.Collections.Generic;
using WebModel.ClassRoom;

namespace EduFacade.ClassRoomFacade.Convertor
{
    public interface IClassRoomConvertor
    {
        AddClassRoom ConvertToBussinessEntity(AddClassRoomDto addClassRoomDto);
        UpdateClassRoom ConvertToBussinessEntity(UpdateClassRoomDto updateClassRoomDto);
        HashSet<GetAllClassRoomInBranchDto> ConvertToWebModel(HashSet<GetAllClassRoomInBranch> getAllClassRoomInBranches);
        GetClassRoomDetailDto ConvertToWebModel(GetClassRoomDetail getClassRoomDetail);
    }
}
