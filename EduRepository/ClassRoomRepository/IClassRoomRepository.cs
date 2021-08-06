using Model.Functions;
using Model.Functions.ClassRoom;
using System;
using System.Collections.Generic;
namespace EduRepository.ClassRoomRepository
{
    public interface IClassRoomRepository : IBaseRepository
    {
        HashSet<GetAllClassRoomInBranch> GetAllClassRoomInBranch(Guid branchId);
        GetClassRoomDetail GetClassRoomDetail(Guid classRoomId);
        Guid AddClassRoom(AddClassRoom addClassRoom);
        void UpdateClassRoom(UpdateClassRoom updateClassRoom);
        Guid GetOnlineClassRoom(Guid organizationId);
        HashSet<GetAllClassRoomInBranch> GetAllClassRoomInOrganization(Guid organizationId);
        HashSet<GetClassRoomTimeTable> GetClassRoomTimeTable(Guid classRoomId);
    }
}
