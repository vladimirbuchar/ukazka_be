using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Question;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.QuestionRepository
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public GetQuestionDetail GetQuestionDetail(Guid questionId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@questionId", questionId)
            };
            return CallSqlFunction<GetQuestionDetail>("GetQuestionDetail", sqlParameters).FirstOrDefault();
        }

        public HashSet<GetQuestionsInBank> GetQuestionInOrganization(Guid organizationId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@OrganizationId", organizationId)
            };

            return CallSqlFunction<GetQuestionsInBank>("GetQuestionInOrganization", sqlParameters);
        }
        public HashSet<GetQuestionsInBank> GetQuestionInBank(Guid bankOfQuestionId)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@BankOfQuestionId", bankOfQuestionId)
            };

            return CallSqlFunction<GetQuestionsInBank>("GetQuestionInBank", sqlParameters);
        }

        public Guid AddQuestion(AddQuestion addQuestion)
        {
            Guid outGuid = Guid.Empty;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Question", addQuestion.Question),
                new SqlParameter("@AnswerModeId", addQuestion.AnswerModeId),
                new SqlParameter("@BankOfQUestionId", addQuestion.BankOfQUestionId),
                new SqlParameter("@QuestionModeId", addQuestion.QuestionModeId),
            };
            CallSqlProcedure("AddQuestion", sqlParameters, true, ref outGuid);
            return outGuid;
        }

        public void UpdateQuestion(UpdateQuestion updateQuestion)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Question", updateQuestion.Question),
                new SqlParameter("@AnswerModeId", updateQuestion.AnswerModeId),
                new SqlParameter("@QuestionId", updateQuestion.Id),
                new SqlParameter("@BankOfQuestionId",updateQuestion.BankOfQuestionId),
                new SqlParameter("@QuestionModeId", updateQuestion.QuestionModeId),
            };
            CallSqlProcedure("UpdateQuestion", sqlParameters);
        }
    }
}
