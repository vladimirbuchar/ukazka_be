using Model.Functions.Answer;
using System;
using System.Collections.Generic;

namespace EduRepository.AnswerRepository
{
    public interface IAnswerRepository : IBaseRepository
    {
        HashSet<GetAnswersInQuestion> GetAnswersInQuestion(Guid questionId);
        Guid AddAnswer(AddAnswer addAnswer);
        GetAnswerDetail GetAnswerDetail(Guid answerId);
        void UpdateAnswer(UpdateAnswer updateAnswer);

    }
}
