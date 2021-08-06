using Model.Functions.Slider;
using System.Collections.Generic;
using System.Linq;
using WebModel.Slider;

namespace EduFacade.SliderFacade.Convertor
{
    public class SliderConvertor : ISliderConvertor
    {
        public IEnumerable<GetSliderItemListDto> ConvertToWebModel(IEnumerable<GetAllSliderItems> getAllSliderItems)
        {
            return getAllSliderItems.Select(x => ConvertItem(x));
        }

        private GetSliderItemListDto ConvertItem(GetAllSliderItems item)
        {
            return new GetSliderItemListDto()
            {
                Description = item.Description,
                Image = item.Image,
                Name = item.Name

            };
        }
    }
}
