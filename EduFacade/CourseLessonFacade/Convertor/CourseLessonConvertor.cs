using Model.Functions.CourseLesson;
using System.Collections.Generic;
using System.Linq;
using WebModel.CourseLesson;
namespace EduFacade.CourseLessonFacade.Convertor
{
    public class CourseLessonConvertor : ICourseLessonConvertor
    {
        public AddCourseLesson ConvertToBussinessEntity(AddCourseLessonDto addCourseLessonDto)
        {
            return new AddCourseLesson()
            {
                MaterialId = addCourseLessonDto.MaterialId,
                Description = addCourseLessonDto.Description,
                Name = addCourseLessonDto.Name,
                Type = addCourseLessonDto.Type
            };
        }

        public HashSet<GetAllLessonInCourseDto> ConvertToWebModel(HashSet<GetAllLessonInCourse> getAllLessonInCourses)
        {
            return getAllLessonInCourses.Select(item => new GetAllLessonInCourseDto()
            {
                Description = item.Description,
                Name = item.Name,
                Id = item.Id,
                Type = item.Type
            }).ToHashSet();
        }

        public GetCourseLessonDetailDto ConvertToWebModel(GetCourseLessonDetail getCourseLessonDetail)
        {
            return new GetCourseLessonDetailDto()
            {
                Description = getCourseLessonDetail.Description,
                Name = getCourseLessonDetail.Name,
                Id = getCourseLessonDetail.Id,
                Type = getCourseLessonDetail.Type
            };
        }

        public UpdateCourseLesson ConvertToWebModel(UpdateCourseLessonDto updateCourseLessonDto)
        {
            return new UpdateCourseLesson()
            {
                Description = updateCourseLessonDto.Description,
                Id = updateCourseLessonDto.Id,
                Name = updateCourseLessonDto.Name
            };
        }
    }
}
