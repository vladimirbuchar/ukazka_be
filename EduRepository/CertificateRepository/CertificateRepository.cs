using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduRepository.CertificateRepository
{
    public class CertificateRepository : BaseRepository, ICertificateRepository
    {
        public CertificateRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public void AddCertificate(AddCertificate addCertificate)
        {
            CallSqlProcedure("AddCertificate", new List<System.Data.SqlClient.SqlParameter>()
            {
                new System.Data.SqlClient.SqlParameter("@OrganizationId",addCertificate.OrganizationId),
                new System.Data.SqlClient.SqlParameter("@Name",addCertificate.Name),
                new System.Data.SqlClient.SqlParameter("@Html",addCertificate.Html),
                new System.Data.SqlClient.SqlParameter("@CertificateValidTo",addCertificate.CertificateValidTo),
            });
        }

        public GetCertificateDetail GetCertificateDetail(Guid certificateId)
        {
            return CallSqlFunction<GetCertificateDetail>("GetCertificateDetail", new List<System.Data.SqlClient.SqlParameter>()
            {
                new System.Data.SqlClient.SqlParameter("@certificateId",certificateId)
            }).FirstOrDefault();
        }

        public HashSet<GetCertificateInOrganization> GetCertificateInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetCertificateInOrganization>("GetCertificateInOrganization", new List<System.Data.SqlClient.SqlParameter>()
            {
                new System.Data.SqlClient.SqlParameter("@OrganizationId",organizationId)
            });
        }

        public HashSet<GetMyCertificate> GetMyCertificate(Guid userId)
        {
            return CallSqlFunction<GetMyCertificate>("GetMyCertificate", new List<System.Data.SqlClient.SqlParameter>()
            {
                new System.Data.SqlClient.SqlParameter("@userId",userId)
            });
        }

        public void SaveUserCertificate(string name, string fileName, Guid userId, DateTime certificateValidTo)
        {
            CallSqlProcedure("SaveUserCertificate", new List<System.Data.SqlClient.SqlParameter>()
            {
                new System.Data.SqlClient.SqlParameter("@name", name),
                new System.Data.SqlClient.SqlParameter("@fileName",fileName),
                new System.Data.SqlClient.SqlParameter("@userId",userId),
                new System.Data.SqlClient.SqlParameter("@certificateValidTo",certificateValidTo),

            });
        }

        public void UpdateCertificate(UpdateCertificate updateCertificate)
        {
            CallSqlProcedure("UpdateCertificate", new List<System.Data.SqlClient.SqlParameter>()
            {
                new System.Data.SqlClient.SqlParameter("@Id",updateCertificate.Id),
                new System.Data.SqlClient.SqlParameter("@Name",updateCertificate.Name),
                new System.Data.SqlClient.SqlParameter("@Html",updateCertificate.Html),
                new System.Data.SqlClient.SqlParameter("@CertificateValidTo",updateCertificate.CertificateValidTo),

            });
        }
    }
}
