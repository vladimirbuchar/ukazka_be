using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.ClassRoom;

namespace EduFacade.ClassRoomFacade
{
    public interface IClassRoomFacade : IBaseFacade
    {
        Result AddClassRoom(AddClassRoomDto addClassRoomDto);
        HashSet<GetAllClassRoomInBranchDto> GetAllClassRoomInBranch(Guid branchId);
        HashSet<GetAllClassRoomInBranchDto> GetAllClassRoomInOrganization(Guid organization);

        GetClassRoomDetailDto GetClassRoomDetail(Guid classRoomId);
        Result UpdateClassRoom(UpdateClassRoomDto updateClassRoomDto);
        void DeleteClassRoom(Guid classRoomId);
        GetClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId);
    }
}
