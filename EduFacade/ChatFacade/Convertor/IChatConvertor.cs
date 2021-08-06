using Model.Functions.Answer;
using Model.Functions.Chat;
using System.Collections.Generic;
using WebModel.Answer;

namespace EduFacade.AnswerFacade.Convertor
{
    public interface IChatConvertor
    {
        AddChatItem ConvertToBussinessEntity(AddChatItemDto addChatItemDto);
        HashSet<GetAllChatItemDto> ConvertToWebModel(HashSet<GetAllChatItem> getAllChatItems);
        UpdateChatItem ConvertToBussinessEntity(UpdateChatItemDto updateChatItemDto);
    }
}
