using Core.DataTypes;
using EduRepository.CodeBookRepository;
using EduRepository.CourseLessonItemRepository;
using EduRepository.CourseLessonRepository;
using EduRepository.CourseRepository;
using Model.Functions.CourseLesson;
using Model.Functions.CourseLessonItem;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseLessonItemService
{

    public class CourseLessonItemService : BaseService, ICourseLessonItemService
    {
        private readonly ICourseLessonItemRepository _courseLessonItemRepository;
        private readonly ICourseLessonRepository _couseLessonRepository;
        private readonly HashSet<CourseLessonItemTemplate> _courseLessonItemTemplates;
        private readonly ICourseRepository _courseRepository;

        public CourseLessonItemService(ICourseLessonItemRepository courseLessonItemRepository, ICourseLessonRepository couseLessonRepository, ICodeBookRepository codeBookRepository, ICourseRepository courseRepository)
        {
            _courseLessonItemRepository = courseLessonItemRepository;
            _couseLessonRepository = couseLessonRepository;
            _courseLessonItemTemplates = codeBookRepository.GetCodeBookItems<CourseLessonItemTemplate>();
            _courseRepository = courseRepository;
        }
        public Guid AddCourseLessonItem(AddCourseLessonItem addCourseLessonItem)
        {
            return _courseLessonItemRepository.AddCourseLessonItem(addCourseLessonItem);
        }

        public void DeleteCourseLessonItem(Guid courseLessonItemId)
        {
            _courseLessonItemRepository.DeleteEntity<CourseLessonItem>(courseLessonItemId);
        }

        public HashSet<GetCourseLessonItems> GetCourseLessonItems(Guid courseLessonId)
        {
            return _courseLessonItemRepository.GetCourseLessonItems(courseLessonId);
        }

        public GetCourseLessonItemDetail GetCourseLessonItemDetail(Guid courseLessonItemId)
        {
            return _courseLessonItemRepository.GetCourseLessonItemDetail(courseLessonItemId);
        }

        public void UpdateCourseLessonItem(UpdateCourseLessonItem updateCourseLessonItem)
        {
            _courseLessonItemRepository.UpdateCourseLessonItem(updateCourseLessonItem);
        }

        public void ValidateLessonItemName(string name, Result result)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_LESSON_ITEM", "COURSE_LESSON_ITEM_NAME_IS_EMPTY"));
            }
        }
        public void ValidateItemTemplate(Guid templateId, Result result)
        {
            if (_courseLessonItemTemplates.FirstOrDefault(x => x.Id == templateId).SystemIdentificator == CodeBookValues.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_LESSON_ITEM", "COURSE_LESSON_ITEM_TEMPLATE_IS_EMPTY"));
            }
        }

        public GetUserCourseItem GetUserCourseItem(Guid courseId, Guid userId)
        {
            GetUserCourseItem item = _courseLessonItemRepository.GetUserCourseItem(courseId, userId);
            if (item == null || item.CourseLessonItem == Guid.Empty)
            {
                GetAllLessonInCourse getAllLessonInCourse = _couseLessonRepository.GetAllLessonInCourse(_courseRepository.GetCourseDetail(courseId).CourseMaterialId).FirstOrDefault();
                if (getAllLessonInCourse.Type == CourseLessonType.COURSE_TEST)
                {
                    return new GetUserCourseItem()
                    {
                        CourseLessonItem = getAllLessonInCourse.Id,
                        ItemType = CourseLessonType.COURSE_TEST
                    };
                }
                return new GetUserCourseItem()
                {
                    CourseLessonItem = _courseLessonItemRepository.GetCourseLessonItems(getAllLessonInCourse.Id).FirstOrDefault().Id,
                    ItemType = CourseLessonType.COURSE_ITEM
                };
            }
            return item;
        }

        public void UpdatePositionCourseLessonItem(UpdatePositionCourseLessonItem updatePositionCourseLessonItem)
        {
            _courseLessonItemRepository.UpdatePositionCourseLessonItem(updatePositionCourseLessonItem);
        }

        public GetCourseLessonPowerPointFile GetCourseLessonPowerPointFile(Guid courseLessonItemId)
        {
            return _courseLessonItemRepository.GetCourseLessonPowerPointFile(courseLessonItemId);
        }
    }
}
