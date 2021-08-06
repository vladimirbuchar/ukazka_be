using System.Collections.Generic;
using WebModel.Slider;

namespace EduFacade.SliderFacade
{
    public interface ISliderFacade : IBaseFacade
    {
        IEnumerable<GetSliderItemListDto> GetSliderItemList();
    }
}
