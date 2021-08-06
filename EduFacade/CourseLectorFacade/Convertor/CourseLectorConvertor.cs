using Model.Functions.CourseLector;
using System.Collections.Generic;
using System.Linq;
using WebModel.CourseLector;

namespace EduFacade.CourseLectorFacade.Convertor
{
    public class CourseLectorConvertor : ICourseLectorConvertor
    {
        public AddCourseLector ConvertToBussinessEntity(AddCourseLectorDto addCourseLectorDto)
        {
            return new AddCourseLector()
            {
                CourseLector = addCourseLectorDto.CourseLector,
                CourseTerm = addCourseLectorDto.CourseTerm
            };
        }

        public HashSet<GetAllLectorCourseTermDto> ConvertToWebModel(HashSet<CourseTermLector> courseTermLectors)
        {
            return courseTermLectors.Select(item => new GetAllLectorCourseTermDto()
            {
                FirstName = item.FirstName,
                Id = item.Id,
                LastName = item.LastName,
                SecondName = item.SecondName
            }).ToHashSet();
        }
    }
}
