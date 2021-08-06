using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.SendMessage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.SendMessageRepository
{
    public class CourseMaterialRepository : BaseRepository, ICourseMaterialRepository
    {
        public CourseMaterialRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public Guid AddCourseMaterial(AddCourseMaterial addCourseMaterial)
        {
            Guid outGuid = Guid.Empty;
            CallSqlProcedure("AddCourseMaterial", new List<SqlParameter>()
            {
                new SqlParameter("@OrganizationId",addCourseMaterial.OrganizationId),
                new SqlParameter("@Name",addCourseMaterial.Name),

            }, true, ref outGuid);
            return outGuid;
        }

        public GetCourseMaterialDetail GetCourseMaterialDetail(Guid courseMaterialId)
        {
            return CallSqlFunction<GetCourseMaterialDetail>("GetCourseMaterialDetail", new List<SqlParameter>()
            {
                new SqlParameter("@courseMaterialId",courseMaterialId)
            }).FirstOrDefault();
        }

        public HashSet<GetCourseMaterialInOrganization> GetCourseMaterialInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetCourseMaterialInOrganization>("GetCourseMaterialInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).ToHashSet();
        }

        public HashSet<GetFiles> GetFiles(Guid courseMaterialId)
        {
            return CallSqlFunction<GetFiles>("GetCourseMaterialFiles", new List<SqlParameter>()
            {
                new SqlParameter("@courseMaterialId",courseMaterialId)
            }).ToHashSet();
        }

        public void UpdateCourseMaterial(UpdateCourseMaterial updateCourseMaterial)
        {
            CallSqlProcedure("UpdateCourseMaterial", new List<SqlParameter>()
            {
                new SqlParameter("@Id",updateCourseMaterial.Id),
                new SqlParameter("@Name",updateCourseMaterial.Name),
            });
        }
    }
}
