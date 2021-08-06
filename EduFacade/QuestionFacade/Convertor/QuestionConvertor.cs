using Model.Functions.Question;
using System.Collections.Generic;
using System.Linq;
using WebModel.Question;
namespace EduFacade.QuestionFacade.Convertor
{
    public class QuestionConvertor : IQuestionConvertor
    {
        public AddQuestion ConvertToBussinessEntity(AddQuestionDto addQuestionDto)
        {
            return new AddQuestion()
            {
                AnswerModeId = addQuestionDto.AnswerModeId,
                BankOfQUestionId = addQuestionDto.BankOfQUestionId,
                Question = addQuestionDto.Question,
                QuestionModeId = addQuestionDto.QuestionModeId
            };
        }

        public UpdateQuestion ConvertToBussinessEntity(UpdateQuestionDto updateQuestionDto)
        {
            return new UpdateQuestion()
            {
                AnswerModeId = updateQuestionDto.AnswerModeId,
                Id = updateQuestionDto.Id,
                Question = updateQuestionDto.Question,
                BankOfQuestionId = updateQuestionDto.BankOfQuestionId,
                QuestionModeId = updateQuestionDto.QuestionModeId
            };
        }

        public HashSet<GetQuestionInOrganizationDto> ConvertToWebModel(HashSet<GetQuestionsInBank> getQuestionsInBanks)
        {
            return getQuestionsInBanks.Select(item => new GetQuestionInOrganizationDto()
            {
                AnswerMode = item.AnswerModeId,
                Id = item.Id,
                Question = item.Question,
                BankOfQuestionName = item.BankOfQuestionName,
                IsDefault = item.IsDefault,
                BankOfQuestionId = item.BankOfQuestionId
            }).ToHashSet();
        }

        public GetQuestionDetailDto ConvertToWebModel(GetQuestionDetail getQuestionDetail)
        {
            return new GetQuestionDetailDto()
            {
                AnswerModeId = getQuestionDetail.AnswerModeId,
                Id = getQuestionDetail.Id,
                Question = getQuestionDetail.Question,
                BankOfQuestionId = getQuestionDetail.BankOfQuestionId,
                QuestionModeId = getQuestionDetail.QuestionModeId,
                FileId = getQuestionDetail.FileId,
                OriginalFileName = getQuestionDetail.OriginalFileName
            };
        }
    }
}
