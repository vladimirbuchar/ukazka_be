using Model.Functions;
using Model.Functions.ClassRoom;
using System.Collections.Generic;
using System.Linq;
using WebModel.ClassRoom;

namespace EduFacade.ClassRoomFacade.Convertor
{
    public class ClasssRoomConvertor : IClassRoomConvertor
    {
        public AddClassRoom ConvertToBussinessEntity(AddClassRoomDto addClassRoomDto)
        {
            return new AddClassRoom()
            {
                BasicInformationDescription = addClassRoomDto.Description,
                BasicInformationName = addClassRoomDto.Name,
                Floor = addClassRoomDto.Floor,
                MaxCapacity = addClassRoomDto.MaxCapacity,
                BranchId = addClassRoomDto.BranchId
            };
        }

        public UpdateClassRoom ConvertToBussinessEntity(UpdateClassRoomDto updateClassRoomDto)
        {
            return new UpdateClassRoom()
            {
                BasicInformationDescription = updateClassRoomDto.Description,
                BasicInformationName = updateClassRoomDto.Name,
                Floor = updateClassRoomDto.Floor,
                ClassRoomId = updateClassRoomDto.Id,
                MaxCapacity = updateClassRoomDto.MaxCapacity
            };
        }

        public HashSet<GetAllClassRoomInBranchDto> ConvertToWebModel(HashSet<GetAllClassRoomInBranch> getAllClassRoomInBranches)
        {
            return getAllClassRoomInBranches.Select(item => new GetAllClassRoomInBranchDto()
            {
                Description = item.Description,
                Floor = item.Floor,
                Id = item.Id,
                MaxCapacity = item.MaxCapacity,
                Name = item.Name,
                IsOnline = item.IsOnline
            }).ToHashSet();
        }

        public GetClassRoomDetailDto ConvertToWebModel(GetClassRoomDetail getClassRoomDetail)
        {
            return new GetClassRoomDetailDto()
            {
                Description = getClassRoomDetail.Description,
                Floor = getClassRoomDetail.Floor,
                Id = getClassRoomDetail.Id,
                MaxCapacity = getClassRoomDetail.MaxCapacity,
                Name = getClassRoomDetail.Name
            };
        }



    }
}
