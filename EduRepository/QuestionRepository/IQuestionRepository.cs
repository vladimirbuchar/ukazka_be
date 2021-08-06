using Model.Functions.Question;
using System;
using System.Collections.Generic;

namespace EduRepository.QuestionRepository
{
    public interface IQuestionRepository : IBaseRepository
    {
        HashSet<GetQuestionsInBank> GetQuestionInOrganization(Guid questionBankId);
        Guid AddQuestion(AddQuestion addQuestion);
        GetQuestionDetail GetQuestionDetail(Guid questionId);
        void UpdateQuestion(UpdateQuestion updateQuestion);
        HashSet<GetQuestionsInBank> GetQuestionInBank(Guid bankOfQuestionId);
    }
}
