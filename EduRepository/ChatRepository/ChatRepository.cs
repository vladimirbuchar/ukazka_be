using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Answer;
using Model.Functions.Chat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.AnswerRepository
{
    public class ChatRepository : BaseRepository, IChatRepository
    {
        public ChatRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }

        public void AddChatItem(AddChatItem addChatItem)
        {
            CallSqlProcedure("AddChatItem", new List<SqlParameter>()
            {
                new SqlParameter("@UserId",addChatItem.UserId),
                new SqlParameter("@Text",addChatItem.Text),
                new SqlParameter("@ParentId",addChatItem.ParentId ),
                new SqlParameter("@CourseTermId",addChatItem.CourseTermId)
            });
        }

        public void UpdateChatItem(UpdateChatItem updateChatItem)
        {
            CallSqlProcedure("UpdateChatItem", new List<SqlParameter>()
            {
                new SqlParameter("@Text",updateChatItem.Text),
                new SqlParameter("@Id",updateChatItem.Id),
            });
        }
        public HashSet<GetAllChatItem> GetAllChatItem(Guid courseTermId)
        {
            return CallSqlFunction<GetAllChatItem>("GetAllChatItem", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",courseTermId)
            }).ToHashSet();
        }

    }
}
