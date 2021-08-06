using System.Collections.Generic;
using WebModel.Page;

namespace EduFacade.PageFacade
{
    public interface IPageFacade : IBaseFacade
    {
        HashSet<PriceListDto> PriceList();
    }
}
