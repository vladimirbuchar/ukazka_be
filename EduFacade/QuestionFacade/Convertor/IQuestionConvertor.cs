using Model.Functions.Question;
using System.Collections.Generic;
using WebModel.Question;

namespace EduFacade.QuestionFacade.Convertor
{
    public interface IQuestionConvertor
    {
        AddQuestion ConvertToBussinessEntity(AddQuestionDto addQuestionDto);
        HashSet<GetQuestionInOrganizationDto> ConvertToWebModel(HashSet<GetQuestionsInBank> getQuestionsInBanks);
        GetQuestionDetailDto ConvertToWebModel(GetQuestionDetail getQuestionDetail);
        UpdateQuestion ConvertToBussinessEntity(UpdateQuestionDto updateQuestionDto);
    }
}
