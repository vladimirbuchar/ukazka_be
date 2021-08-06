using Core.DataTypes;
using Model.Functions.Question;
using System;
using System.Collections.Generic;

namespace EduServices.QuestionService
{
    public interface IQuestionService : IBaseService
    {
        Guid AddQuestion(AddQuestion addQuestion);
        void UpdateQuestion(UpdateQuestion updateQuestion);
        void DeleteQuestion(Guid questionOid);
        GetQuestionDetail GetQuestionDetail(Guid questionId);
        HashSet<GetQuestionsInBank> GetQuestionInOrganization(Guid bankOfQuestionId);
        void ValidateQuestionName(string name, Result result);
        void ValidateAnswerMode(Guid answerMode, Result result);
        void ValidateQuestionMode(Guid questionMode, Result result);
    }
}
