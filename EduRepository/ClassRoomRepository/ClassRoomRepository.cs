using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions;
using Model.Functions.ClassRoom;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.ClassRoomRepository
{
    public class ClassRoomRepository : BaseRepository, IClassRoomRepository
    {
        public ClassRoomRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }


        public HashSet<GetAllClassRoomInBranch> GetAllClassRoomInBranch(Guid branchId)
        {
            return CallSqlFunction<GetAllClassRoomInBranch>("GetAllClassRoomInBranch", new List<SqlParameter>()
            {
                new SqlParameter("@branchId",branchId)
            });
        }
        public GetClassRoomDetail GetClassRoomDetail(Guid classRoomId)
        {
            return CallSqlFunction<GetClassRoomDetail>("GetClassRoomDetail", new List<SqlParameter>()
            {
                new SqlParameter("@classRoomId",classRoomId)
            }).FirstOrDefault();
        }

        public Guid AddClassRoom(AddClassRoom addClassRoom)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Floor", addClassRoom.Floor),
                new SqlParameter("@BranchId", addClassRoom.BranchId),
                new SqlParameter("@MaxCapacity", addClassRoom.MaxCapacity),
                new SqlParameter("@BasicInformationName", addClassRoom.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", addClassRoom.BasicInformationDescription),
                new SqlParameter("@IsOnline",addClassRoom.IsOnline)
            };
            CallSqlProcedure("CreateClassRoom", parameters, true, ref outGuid);
            return outGuid;
        }
        public void UpdateClassRoom(UpdateClassRoom updateClassRoom)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Floor", updateClassRoom.Floor),
                new SqlParameter("@ClassRoomId", updateClassRoom.ClassRoomId),
                new SqlParameter("@MaxCapacity", updateClassRoom.MaxCapacity),
                new SqlParameter("@BasicInformationName", updateClassRoom.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", updateClassRoom.BasicInformationDescription)
            };
            CallSqlProcedure("UpdateClassRoom", parameters);
        }

        public Guid GetOnlineClassRoom(Guid organizationId)
        {
            return CallSqlFunction<GetClassRoomDetail>("GetOnlineClassRoom", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).FirstOrDefault().Id;
        }

        public HashSet<GetAllClassRoomInBranch> GetAllClassRoomInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetAllClassRoomInBranch>("GetAllClassRoomInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            });
        }

        public HashSet<GetClassRoomTimeTable> GetClassRoomTimeTable(Guid classRoomId)
        {
            return CallSqlFunction<GetClassRoomTimeTable>("GetClassRoomTimeTable", new List<SqlParameter>()
            {
                new SqlParameter("@classRoomId",classRoomId)
            }).ToHashSet();
        }
    }
}
