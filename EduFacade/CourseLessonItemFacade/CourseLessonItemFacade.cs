using Core.DataTypes;
using EduFacade.CourseLessonItemFacade.Convertor;
using EduServices.CourseLessonItemService;
using Model.Functions.CourseLessonItem;
using System;
using System.Collections.Generic;
using WebModel.CourseLesson;
using WebModel.CourseLessonItem;

namespace EduFacade.CourseLessonItemFacade
{
    public class CourseLessonItemFacade : BaseFacade, ICourseLessonItemFacade
    {
        private readonly ICourseLessonItemService _courseLessonItemService;
        private readonly ICourseLessonItemConvertor _courseLessonItemConvertor;

        public CourseLessonItemFacade(ICourseLessonItemService courseLessonItemService, ICourseLessonItemConvertor courseLessonItemConvertor)
        {
            _courseLessonItemService = courseLessonItemService;
            _courseLessonItemConvertor = courseLessonItemConvertor;
        }

        public Result AddCourseLessonItem(AddCourseLessonItemDto addCourseLessonItemDto)
        {
            Result result = Validate(addCourseLessonItemDto);
            if (result.IsOk)
            {
                AddCourseLessonItem addCourseLessonItem = _courseLessonItemConvertor.ConvertToBussinessEntity(addCourseLessonItemDto);
                return new Result<Guid>()
                {
                    Data = _courseLessonItemService.AddCourseLessonItem(addCourseLessonItem)
                };
            }
            return result;

        }
        private Result Validate(AddCourseLessonItemDto addCourseLessonItemDto)
        {
            Result result = new Result();
            _courseLessonItemService.ValidateLessonItemName(addCourseLessonItemDto.Name, result);
            _courseLessonItemService.ValidateItemTemplate(addCourseLessonItemDto.TemplateId, result);
            return result;
        }
        private Result Validate(UpdateCourseLessonItemDto updateCourseLessonItemDto)
        {
            Result result = new Result();
            _courseLessonItemService.ValidateLessonItemName(updateCourseLessonItemDto.Name, result);
            _courseLessonItemService.ValidateItemTemplate(updateCourseLessonItemDto.TemplateId, result);

            return result;
        }
        public void DeleteCourseLessonItem(Guid courseLessonItemId)
        {
            _courseLessonItemService.DeleteCourseLessonItem(courseLessonItemId);
        }

        public HashSet<GetCourseLessonItemsDto> GetCourseLessonItems(Guid courseLessonId)
        {
            return _courseLessonItemConvertor.ConvertToWebModel(_courseLessonItemService.GetCourseLessonItems(courseLessonId));
        }
        public GetCourseLessonItemDetailDto GetCourseLessonItemDetail(Guid courseLessonItemId)
        {
            return _courseLessonItemConvertor.ConvertToWebModel(_courseLessonItemService.GetCourseLessonItemDetail(courseLessonItemId));
        }

        public Result UpdateCourseLessonItem(UpdateCourseLessonItemDto updateCourseLessonItemDto)
        {
            Result result = Validate(updateCourseLessonItemDto);
            if (result.IsOk)
            {
                UpdateCourseLessonItem updateCourseLessonItem = _courseLessonItemConvertor.ConvertToBussinessEntity(updateCourseLessonItemDto);
                _courseLessonItemService.UpdateCourseLessonItem(updateCourseLessonItem);
            }
            return result;
        }

        public void UpdatePositionCourseLessonItem(UpdatePositionCourseLessonItemDto updatePositionCourseLesson)
        {
            int position = 0;
            foreach (string item in updatePositionCourseLesson.Ids)
            {
                _courseLessonItemService.UpdatePositionCourseLessonItem(new UpdatePositionCourseLessonItem()
                {
                    Id = Guid.Parse(item),
                    NewPosition = position
                });
                position++;
            }
        }
    }
}
