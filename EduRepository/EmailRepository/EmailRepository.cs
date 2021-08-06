using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions;
using System.Collections.Generic;
using System.Linq;

namespace EduRepository.EmailRepository
{
    public class EmailRepository : BaseRepository, IEmailRepository
    {
        public EmailRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public GetEmail GetEmail(string identificator)
        {
            HashSet<GetEmail> emails = CallSqlFunction<GetEmail>("GetMail", new List<System.Data.SqlClient.SqlParameter>()
            {
                {  new System.Data.SqlClient.SqlParameter("@Identificator",identificator) }
            }).ToHashSet();

            GetEmail email = emails.FirstOrDefault(x => x.SystemIdentificator == identificator);
            if (email == null)
            {
                email = emails.FirstOrDefault(x => x.SystemIdentificator.StartsWith(identificator));
            }
            return email;
        }
    }
}
