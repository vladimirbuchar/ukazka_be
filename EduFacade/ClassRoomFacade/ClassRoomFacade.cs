using Core.DataTypes;
using EduFacade.ClassRoomFacade.Convertor;
using EduServices.ClassRoomService;
using EduServices.OrganizationService;
using Model.Functions.ClassRoom;
using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.ClassRoom;
using WebModel.User;

namespace EduFacade.ClassRoomFacade
{
    public class ClassRoomFacade : BaseFacade, IClassRoomFacade
    {
        private readonly IClassRoomService _classRoomService;
        private readonly IClassRoomConvertor _classRoomConvertor;
        private readonly IOrganizationService _organizationService;
        public ClassRoomFacade(IClassRoomService classRoomService, IClassRoomConvertor classRoomConvertor, IOrganizationService organizationService)
        {
            _classRoomService = classRoomService;
            _classRoomConvertor = classRoomConvertor;
            _organizationService = organizationService;
        }
        public Result AddClassRoom(AddClassRoomDto addClassRoomDto)
        {
            Result validate = Validate(addClassRoomDto);
            if (validate.IsOk)
            {
                AddClassRoom addClassRoom = _classRoomConvertor.ConvertToBussinessEntity(addClassRoomDto);
                return new Result<Guid>()
                {
                    Data = _classRoomService.AddClassRoom(addClassRoom)
                };
            }
            return validate;
        }
        private Result Validate(AddClassRoomDto addClassRoomDto)
        {
            Result result = new Result();
            _classRoomService.ValidateClassRoomName(addClassRoomDto.Name, result);
            _classRoomService.ValidateClassRoomMaxCapacity(addClassRoomDto.MaxCapacity, result);
            return result;
        }
        private Result Validate(UpdateClassRoomDto updateClassRoomDto)
        {
            Result result = new Result();
            _classRoomService.ValidateClassRoomName(updateClassRoomDto.Name, result);
            _classRoomService.ValidateClassRoomMaxCapacity(updateClassRoomDto.MaxCapacity, result);
            return result;
        }
        public void DeleteClassRoom(Guid classRoomId)
        {
            _classRoomService.DeleteClassRoom(classRoomId);
        }

        public HashSet<GetAllClassRoomInBranchDto> GetAllClassRoomInBranch(Guid branchId)
        {
            return _classRoomConvertor.ConvertToWebModel(_classRoomService.GetAllClassRoomInBranch(branchId));
        }

        public GetClassRoomDetailDto GetClassRoomDetail(Guid classRoomId)
        {
            return _classRoomConvertor.ConvertToWebModel(_classRoomService.GetClassRoomDetail(classRoomId));
        }

        public Result UpdateClassRoom(UpdateClassRoomDto updateClassRoomDto)
        {
            Result validate = Validate(updateClassRoomDto);
            if (validate.IsOk)
            {
                UpdateClassRoom updateClassRoom = _classRoomConvertor.ConvertToBussinessEntity(updateClassRoomDto);
                _classRoomService.UpdateClassRoom(updateClassRoom);
            }
            return validate;

        }

        public HashSet<GetAllClassRoomInBranchDto> GetAllClassRoomInOrganization(Guid organizationId)
        {
            return _classRoomConvertor.ConvertToWebModel(_classRoomService.GetAllClassRoomInOrganization(organizationId));
        }

        public GetClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId)
        {
            GetClassRoomTimeTableDto getClassRoomTimeTableDtos = new GetClassRoomTimeTableDto();
            HashSet<GetClassRoomTimeTable> getClassRoomTimeTables = _classRoomService.GetClassRoomTimeTable(classRoomId);
            HashSet<GetStudyHours> getStudyHours = _organizationService.GetStudyHours(organizationId).OrderBy(x => x.Position).ToHashSet();
            getClassRoomTimeTableDtos.StudyHours = getStudyHours.Select(x => new WebModel.Organization.GetStudyHoursDto()
            {
                ActiveFrom = x.ActiveFrom,
                ActiveFromId = x.ActiveFromId,
                ActiveTo = x.ActiveTo,
                ActiveToId = x.ActiveToId,
                Id = x.Id,
                OrganizationId = x.OrganizationId,
                Position = x.Position
            }).ToHashSet();
            HashSet<GetClassRoomTimeTable> monday = getClassRoomTimeTables.Where(x => x.Monday).ToHashSet();
            HashSet<GetClassRoomTimeTable> tuesday = getClassRoomTimeTables.Where(x => x.Tuesday).ToHashSet();
            HashSet<GetClassRoomTimeTable> wednesday = getClassRoomTimeTables.Where(x => x.Wednesday).ToHashSet();
            HashSet<GetClassRoomTimeTable> thursday = getClassRoomTimeTables.Where(x => x.Thursday).ToHashSet();
            HashSet<GetClassRoomTimeTable> friday = getClassRoomTimeTables.Where(x => x.Friday).ToHashSet();
            HashSet<GetClassRoomTimeTable> saturday = getClassRoomTimeTables.Where(x => x.Saturday).ToHashSet();
            HashSet<GetClassRoomTimeTable> sunday = getClassRoomTimeTables.Where(x => x.Sunday).ToHashSet();
            PrepareTimeTable(monday, getStudyHours, getClassRoomTimeTableDtos, "TIME_TABLE_MONDAY");
            PrepareTimeTable(tuesday, getStudyHours, getClassRoomTimeTableDtos, "TIME_TABLE_TUESDAY");
            PrepareTimeTable(wednesday, getStudyHours, getClassRoomTimeTableDtos, "TIME_TABLE_WEDNESDAY");
            PrepareTimeTable(thursday, getStudyHours, getClassRoomTimeTableDtos, "TIME_TABLE_THURSDAY");
            PrepareTimeTable(friday, getStudyHours, getClassRoomTimeTableDtos, "TIME_TABLE_FRIDAY");
            PrepareTimeTable(saturday, getStudyHours, getClassRoomTimeTableDtos, "TIME_TABLE_SATURDAY");
            PrepareTimeTable(sunday, getStudyHours, getClassRoomTimeTableDtos, "TIME_TABLE_SUNDAY");
            return getClassRoomTimeTableDtos;
        }
        private void PrepareTimeTable(HashSet<GetClassRoomTimeTable> day, HashSet<GetStudyHours> getStudyHours, GetClassRoomTimeTableDto timeTableItem, string dayName)
        {
            TimeTableDto timeTableDto = new TimeTableDto
            {
                DayOfWeek = dayName
            };
            foreach (GetStudyHours item in getStudyHours)
            {
                string courseName = "";
                courseName = day.FirstOrDefault(x => x.TimeFromId == item.ActiveFromId && x.TimeToId == item.ActiveToId)?.CourseName;
                timeTableDto.CourseTerm.Add(courseName);
            }
            timeTableItem.TimeTable.Add(timeTableDto);
        }

    }
}