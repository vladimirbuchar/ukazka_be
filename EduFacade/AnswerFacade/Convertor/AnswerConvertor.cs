using Microsoft.Extensions.Configuration;
using Model.Functions.Answer;
using System.Collections.Generic;
using System.Linq;
using WebModel.Answer;

namespace EduFacade.AnswerFacade.Convertor
{
    public class AnswerConvertor : IAnswerConvertor
    {
        private readonly IConfiguration _configuration;
        public AnswerConvertor(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AddAnswer ConvertToBussinessEntity(AddAnswerDto addAnswerDto)
        {
            return new AddAnswer()
            {
                Answer = addAnswerDto.Answer,
                IsTrueAnswer = addAnswerDto.IsTrueAnswer,
                QuestionId = addAnswerDto.QuestionId
            };
        }

        public UpdateAnswer ConvertToBussinessEntity(UpdateAnswerDto updateAnswerDto)
        {
            return new UpdateAnswer()
            {
                Answer = updateAnswerDto.Answer,
                AnswerId = updateAnswerDto.Id,
                IsTrueAnswer = updateAnswerDto.IsTrueAnswer
            };
        }

        public HashSet<GetAnswersInQuestionDto> ConvertToWebModel(HashSet<GetAnswersInQuestion> getAnswersInQuestions)
        {
            return getAnswersInQuestions.Select(item => new GetAnswersInQuestionDto()
            {
                Answer = item.Answer,
                Id = item.Id,
                IsTrueAnswer = item.IsTrueAnswer,
                FileId = item.FileId,
                FileName = item.FileName,
                PreivewUrl = string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, item?.ObjectOwner, item?.FileName),

            }).ToHashSet();
        }

        public GetAnswerDetailDto ConvertToWebModel(GetAnswerDetail answerDetail)
        {
            return new GetAnswerDetailDto()
            {
                Answer = answerDetail.Answer,
                Id = answerDetail.Id,
                IsTrueAnswer = answerDetail.IsTrueAnswer,
                FileId = answerDetail.FileId,
                FileName = answerDetail.FileName
            };
        }
    }
}
