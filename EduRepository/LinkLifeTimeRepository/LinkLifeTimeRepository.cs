
using EduRepository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;

namespace EduFacade.LinkLifeTimeRepository
{
    public class LinkLifeTimeRepository : BaseRepository, ILinkLifeTimeRepository
    {
        public LinkLifeTimeRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public Guid SaveLink(Guid userId, DateTime endTime)
        {
            Guid outGuid = Guid.Empty;
            CallSqlProcedure("SaveLink", new List<System.Data.SqlClient.SqlParameter>()
            {
                new System.Data.SqlClient.SqlParameter("@UserId",userId),
                new System.Data.SqlClient.SqlParameter("@EndTime",endTime)
            }, true, ref outGuid);
            return outGuid;
        }
    }
}
