using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.Linq;
using WebModel.CodeBook;
namespace EduFacade.CodeBookFacade.Convertor
{
    public class CodeBookConvertor : ICodeBookConvertor
    {
        public HashSet<GetCodeBookItemsDto> ConvertToWebModel<T>(HashSet<T> codebookItems) where T : CodeBook
        {
            return codebookItems.Select(item => new GetCodeBookItemsDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Name,
                SystemIdentificator = item.SystemIdentificator
            }).ToHashSet();
        }
    }
}
