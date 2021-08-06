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
    public class SendMessageRepository : BaseRepository, ISendMessageRepository
    {
        public SendMessageRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public void AddSendMessage(AddSendMessage addSendMessage)
        {
            CallSqlProcedure("AddSendMessage", new List<SqlParameter>()
            {
                new SqlParameter("@OrganizationId",addSendMessage.OrganizationId),
                new SqlParameter("@Html",addSendMessage.Html),
                new SqlParameter("@Name",addSendMessage.Name),
                new SqlParameter("@Reply",addSendMessage.Reply),
                new SqlParameter("@SendMessageType",addSendMessage.SendMessageType)
            });
        }

        public GetSendMessageDetail GetSendMessageDetail(Guid sendMessageId)
        {
            return CallSqlFunction<GetSendMessageDetail>("GetSendMessageDetail", new List<SqlParameter>()
            {
                new SqlParameter("@sendMessageId",sendMessageId)
            }).FirstOrDefault();
        }

        public HashSet<GetSendMessageInOrganization> GetSendMessageInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetSendMessageInOrganization>("GetSendMessageInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).ToHashSet();
        }

        public void UpdateSendMessage(UpdateSendMessage updateSendMessage)
        {
            CallSqlProcedure("UpdateSendMessage", new List<SqlParameter>()
            {
                new SqlParameter("@Id",updateSendMessage.Id),
                new SqlParameter("@Html",updateSendMessage.Html),
                new SqlParameter("@Name",updateSendMessage.Name),
                new SqlParameter("@Reply",updateSendMessage.Reply),
                new SqlParameter("@SendMessageType",updateSendMessage.SendMessageType)
            });
        }
    }
}
