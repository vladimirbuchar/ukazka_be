using Model.Functions.CourseLessonItem;
using System.Collections.Generic;
using WebModel.CourseLessonItem;

namespace EduFacade.CourseLessonItemFacade.Convertor
{
    public interface ICourseLessonItemConvertor
    {
        AddCourseLessonItem ConvertToBussinessEntity(AddCourseLessonItemDto addCourseLessonItemDto);
        HashSet<GetCourseLessonItemsDto> ConvertToWebModel(HashSet<GetCourseLessonItems> getCourseLessonItems);
        GetCourseLessonItemDetailDto ConvertToWebModel(GetCourseLessonItemDetail getCourseLessonItemDetail);
        UpdateCourseLessonItem ConvertToBussinessEntity(UpdateCourseLessonItemDto updateCourseLessonItemDto);
    }
}
