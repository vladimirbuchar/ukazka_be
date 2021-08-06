using Core.DataTypes;
using EduRepository.AnswerRepository;
using Model.Functions.Answer;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.AnswerService
{
    public class AnswerService : BaseService, IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public Guid AddAnswer(AddAnswer addAnswer)
        {
            return _answerRepository.AddAnswer(addAnswer);
        }

        public void DeleteAnswer(Guid answerId)
        {
            _answerRepository.DeleteEntity<TestQuestionAnswer>(answerId);
        }

        public HashSet<GetAnswersInQuestion> GetAnswersInQuestion(Guid questionId)
        {
            return _answerRepository.GetAnswersInQuestion(questionId).OrderBy(x => x.Position).ToHashSet();
        }

        public GetAnswerDetail GetAnswerDetail(Guid answerId)
        {
            return _answerRepository.GetAnswerDetail(answerId);
        }

        public void UpdateAnswer(UpdateAnswer updateAnswer)
        {
            _answerRepository.UpdateAnswer(updateAnswer);
        }

        public void ValidateAnswer(string answer, Result result)
        {
            if (string.IsNullOrEmpty(answer))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ANSWER", "ANSWER_IS_EMPTY"));
            }
        }
    }
}
