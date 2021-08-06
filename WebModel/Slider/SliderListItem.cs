using WebModel.Shared;

namespace WebModel.Slider
{
    public class GetSliderItemListDto : BaseDto, IBasicInformationDto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
