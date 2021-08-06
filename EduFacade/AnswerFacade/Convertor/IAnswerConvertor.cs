using Model.Functions.Answer;
using System.Collections.Generic;
using WebModel.Answer;

namespace EduFacade.AnswerFacade.Convertor
{
    public interface IAnswerConvertor
    {
        AddAnswer ConvertToBussinessEntity(AddAnswerDto addAnswerDto);
        HashSet<GetAnswersInQuestionDto> ConvertToWebModel(HashSet<GetAnswersInQuestion> getAnswersInQuestions);
        GetAnswerDetailDto ConvertToWebModel(GetAnswerDetail answerDetail);
        UpdateAnswer ConvertToBussinessEntity(UpdateAnswerDto updateAnswerDto);
    }
}
