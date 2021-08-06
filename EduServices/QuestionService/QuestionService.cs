using Core.DataTypes;
using EduRepository.CodeBookRepository;
using EduRepository.QuestionRepository;
using Model.Functions.Question;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.QuestionService
{
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly HashSet<AnswerMode> _answerModes;
        private readonly HashSet<QuestionMode> _questionModes;

        public QuestionService(IQuestionRepository questionRepository, ICodeBookRepository codeBookRepository)
        {
            _questionRepository = questionRepository;
            _answerModes = codeBookRepository.GetCodeBookItems<AnswerMode>();
            _questionModes = codeBookRepository.GetCodeBookItems<QuestionMode>();
        }
        public Guid AddQuestion(AddQuestion addQuestion)
        {
            return _questionRepository.AddQuestion(addQuestion);
        }

        public void DeleteQuestion(Guid questionId)
        {
            _questionRepository.DeleteEntity<TestQuestion>(questionId);
        }

        public void UpdateQuestion(UpdateQuestion updateQuestion)
        {
            _questionRepository.UpdateQuestion(updateQuestion);
        }


        public GetQuestionDetail GetQuestionDetail(Guid questionId)
        {
            return _questionRepository.GetQuestionDetail(questionId);
        }

        public HashSet<GetQuestionsInBank> GetQuestionInOrganization(Guid organizationId)
        {
            return _questionRepository.GetQuestionInOrganization(organizationId).OrderBy(x => x.BankOfQuestionPosition).ThenBy(x => x.Position).ToHashSet();

        }

        public void ValidateQuestionName(string name, Result result)
        {
            if (string.IsNullOrEmpty(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "QUESTION", "QUESTION_IS_EMPTY"));
            }
        }

        public void ValidateAnswerMode(Guid answerModeId, Result result)
        {
            AnswerMode answerMode = _answerModes.FirstOrDefault(x => x.Id == answerModeId);
            if (answerMode.SystemIdentificator == CodeBookValues.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "QUESTION", "SELECT_ANSWER_MODE"));
            }
        }

        public void ValidateQuestionMode(Guid questionMode, Result result)
        {
            QuestionMode qmode = _questionModes.FirstOrDefault(x => x.Id == questionMode);
            if (qmode.SystemIdentificator == CodeBookValues.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "QUESTION", "SELECT_QUESTION_MODE"));
            }
        }
    }
}
