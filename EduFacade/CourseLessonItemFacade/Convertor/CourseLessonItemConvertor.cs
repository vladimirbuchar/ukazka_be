using Model.Functions.CourseLessonItem;
using System.Collections.Generic;
using System.Linq;
using WebModel.CourseLessonItem;
namespace EduFacade.CourseLessonItemFacade.Convertor
{
    public class CourseLessonItemConvertor : ICourseLessonItemConvertor
    {
        public AddCourseLessonItem ConvertToBussinessEntity(AddCourseLessonItemDto addCourseLessonItemDto)
        {
            return new AddCourseLessonItem()
            {
                CourseLessonId = addCourseLessonItemDto.CourseLessonId,
                Description = addCourseLessonItemDto.Description,
                Name = addCourseLessonItemDto.Name,
                Html = addCourseLessonItemDto.Html,
                TemplateId = addCourseLessonItemDto.TemplateId,
                Youtube = addCourseLessonItemDto.Youtube
            };
        }

        public HashSet<GetCourseLessonItemsDto> ConvertToWebModel(HashSet<GetCourseLessonItems> getCourseLessonItems)
        {
            return getCourseLessonItems.Select(item => new GetCourseLessonItemsDto()
            {
                Description = item.Description,
                Name = item.Name,
                Id = item.Id
            }).ToHashSet();
        }

        public GetCourseLessonItemDetailDto ConvertToWebModel(GetCourseLessonItemDetail getCourseLessonItemDetail)
        {
            return new GetCourseLessonItemDetailDto()
            {
                Description = getCourseLessonItemDetail.Description,
                Name = getCourseLessonItemDetail.Name,
                Id = getCourseLessonItemDetail.Id,
                Html = getCourseLessonItemDetail.Html,
                CourseLessonItemTemplateId = getCourseLessonItemDetail.CourseLessonItemTemplateId,
                TemplateIdentificator = getCourseLessonItemDetail.TemplateIdentificator,
                FileName = getCourseLessonItemDetail.FileName,
                OriginalFileName = getCourseLessonItemDetail.OriginalFileName,
                FileId = getCourseLessonItemDetail.FileId,
                Youtube = getCourseLessonItemDetail.Youtube
            };
        }

        public UpdateCourseLessonItem ConvertToBussinessEntity(UpdateCourseLessonItemDto updateCourseLessonItemDto)
        {
            return new UpdateCourseLessonItem()
            {
                CourseLessonItemId = updateCourseLessonItemDto.CourseLessonItemId,
                Description = updateCourseLessonItemDto.Description,
                Html = updateCourseLessonItemDto.Html,
                Name = updateCourseLessonItemDto.Name,
                Youtube = updateCourseLessonItemDto.Youtube,
                TemplateId = updateCourseLessonItemDto.TemplateId
            };
        }
    }
}
