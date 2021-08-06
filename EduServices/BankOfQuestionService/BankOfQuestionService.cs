using Core.DataTypes;
using EduRepository.CourseRepository;
using EduRepository.QuestionRepository;
using Model.Functions.BankOfQuestion;
using Model.Functions.Question;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseService
{
    public class BankOfQuestionService : BaseService, IBankOfQuestionService
    {
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository;
        private readonly IQuestionRepository _questionRepository;

        public BankOfQuestionService(IBankOfQuestionRepository bankOfQuestionRepository, IQuestionRepository questionRepository)
        {
            _bankOfQuestionRepository = bankOfQuestionRepository;
            _questionRepository = questionRepository;

        }

        public Guid AddBankOfQuestion(AddBankOfQuestion addBankOfQuestion)
        {
            return _bankOfQuestionRepository.AddBankOfQuestion(addBankOfQuestion);
        }

        public GetBankOfQuestionDetail GetBankOfQuestionDetail(Guid bankOfQuestionId)
        {
            return _bankOfQuestionRepository.GetBankOfQuestionDetail(bankOfQuestionId);
        }

        public void DeleteBankOfQuestion(Guid bankOfQuestionId, Guid organizationId)
        {
            HashSet<GetQuestionsInBank> getQuestionsInBanks = _questionRepository.GetQuestionInBank(bankOfQuestionId);
            Guid defaultBankOfQuestion = GetBankOfQuestionInOrganization(organizationId).FirstOrDefault(x => x.IsDefault).Id;

            foreach (GetQuestionsInBank item in getQuestionsInBanks)
            {
                _questionRepository.UpdateQuestion(new UpdateQuestion()
                {
                    AnswerModeId = item.AnswerModeId,
                    BankOfQuestionId = defaultBankOfQuestion,
                    Id = item.Id,
                    Question = item.Question,
                    QuestionModeId = item.QuestionModeId
                });
            }

            _bankOfQuestionRepository.DeleteEntity<BankOfQuestion>(bankOfQuestionId);
        }

        public void UpdateBankOfQuestion(UpdateBankOfQuestion updateBankOfQuestion)
        {
            _bankOfQuestionRepository.UpdateBankOfQuestion(updateBankOfQuestion);
        }

        public HashSet<GetBankOfQuestionInOrganization> GetBankOfQuestionInOrganization(Guid orgazizationId)
        {
            return _bankOfQuestionRepository.GetBankOfQuestionInOrganization(orgazizationId).OrderBy(x => x.Position).ToHashSet();
        }

        public void ValidateName(string name, Result result)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "BANK_OF_QUESTION", "NAME_IS_EMPTY"));
            }
        }
    }
}
