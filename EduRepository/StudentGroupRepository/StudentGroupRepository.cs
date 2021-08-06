using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseStudent;
using Model.Functions.SendMessage;
using Model.Functions.StudentGroup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.SendMessageRepository
{
    public class StudentGroupRepository : BaseRepository, IStudentGroupRepository
    {
        public StudentGroupRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public Guid AddStudentGroup(AddStudentGroup addStudentGroup)
        {
            Guid outGuid = Guid.Empty;
            CallSqlProcedure("AddStudentGroup", new List<SqlParameter>()
            {
                new SqlParameter("@OrganizationId",addStudentGroup.OrganizationId),
                new SqlParameter("@Name",addStudentGroup.Name),

            }, true, ref outGuid);
            return outGuid;
        }

        public void AddStudentToGroup(AddStudentToGroup addStudentToGroup)
        {
            CallSqlProcedure("AddStudentToGroup", new List<SqlParameter>()
            {
                new SqlParameter("@StudentGroupId",addStudentToGroup.StudentGroupId),
                new SqlParameter("@UserId",addStudentToGroup.UserId),
            });
        }

        public HashSet<GetAllStudentInGroup> GetAllStudentInGroup(Guid studentGroupId)
        {
            return CallSqlFunction<GetAllStudentInGroup>("GetAllStudentInGroup", new List<SqlParameter>()
            {
                new SqlParameter("@studentGroupId",studentGroupId)
            }).ToHashSet();
        }

        public HashSet<GetAllTermInGroup> GetAllTermInGroup(Guid studentGroupId)
        {
            return CallSqlFunction<GetAllTermInGroup>("GetAllTermInGroup", new List<SqlParameter>()
            {
                new SqlParameter("@studentGroupId",studentGroupId)
            }).ToHashSet();
        }

        public GetStudentGroupDetail GetStudentGroupDetail(Guid studentGroupId)
        {
            return CallSqlFunction<GetStudentGroupDetail>("GetStudentGroupDetail", new List<SqlParameter>()
            {
                new SqlParameter("@studentGroupId",studentGroupId)
            }).FirstOrDefault();
        }

        public HashSet<GetStudentGroupInOrganization> GetStudentGroupInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetStudentGroupInOrganization>("GetStudentGroupInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).ToHashSet();
        }

        public void UpdateStudentGroup(UpdateStudentGroup updateStudentGroup)
        {
            CallSqlProcedure("UpdateStudentGroup", new List<SqlParameter>()
            {
                new SqlParameter("@Id",updateStudentGroup.Id),
                new SqlParameter("@Name",updateStudentGroup.Name),
            });
        }
    }
}
