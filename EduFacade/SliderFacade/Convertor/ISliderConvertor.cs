using Model.Functions.Slider;
using System.Collections.Generic;
using WebModel.Slider;

namespace EduFacade.SliderFacade.Convertor
{
    public interface ISliderConvertor
    {
        IEnumerable<GetSliderItemListDto> ConvertToWebModel(IEnumerable<GetAllSliderItems> getAllSliderItems);
    }
}
