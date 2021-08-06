using System.Collections.Generic;
using WebModel.CodeBook;

namespace EduFacade.CodeBookFacade
{
    public interface ICodeBookFacade : IBaseFacade
    {
        HashSet<GetCodeBookItemsDto> GetCodeBookItems(string codeBookName);
    }
}
