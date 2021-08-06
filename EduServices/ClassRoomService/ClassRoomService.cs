using Core.DataTypes;
using Core.Extension;
using EduRepository.ClassRoomRepository;
using Model.Functions;
using Model.Functions.ClassRoom;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.ClassRoomService
{
    public class ClassRoomService : BaseService, IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public ClassRoomService(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }
        public Guid AddClassRoom(AddClassRoom classRoom)
        {
            return _classRoomRepository.AddClassRoom(classRoom);
        }
        public void UpdateClassRoom(UpdateClassRoom updateClassRoom)
        {
            _classRoomRepository.UpdateClassRoom(updateClassRoom);
        }

        public void DeleteClassRoom(Guid classRoomId)
        {
            _classRoomRepository.DeleteEntity<ClassRoom>(classRoomId);
        }

        public HashSet<GetAllClassRoomInBranch> GetAllClassRoomInBranch(Guid branchId)
        {
            return _classRoomRepository.GetAllClassRoomInBranch(branchId);
        }

        public GetClassRoomDetail GetClassRoomDetail(Guid classRoomId)
        {
            return _classRoomRepository.GetClassRoomDetail(classRoomId);
        }


        public void ValidateClassRoomName(string name, Result result)
        {
            if (name.IsNullOrEmptyWithTrim())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "CLASS_ROOM", "CLASS_ROOM_NAME_IS_EMPTY"));
            }
        }

        public void ValidateClassRoomMaxCapacity(int maxCapacity, Result result)
        {
            if (maxCapacity < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "CLASS_ROOM", "MAX_CAPACITY_IS_LESS_THEN_ZERO"));
            }
        }

        public Guid GetOnlineClassRoom(Guid organizationId)
        {
            return _classRoomRepository.GetOnlineClassRoom(organizationId);
        }

        public HashSet<GetAllClassRoomInBranch> GetAllClassRoomInOrganization(Guid organizationId)
        {
            return _classRoomRepository.GetAllClassRoomInOrganization(organizationId);
        }

        public HashSet<GetClassRoomTimeTable> GetClassRoomTimeTable(Guid classRoomId)
        {
            return _classRoomRepository.GetClassRoomTimeTable(classRoomId);
        }
    }
}
