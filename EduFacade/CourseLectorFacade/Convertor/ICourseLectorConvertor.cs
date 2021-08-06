using Model.Functions.CourseLector;
using System.Collections.Generic;
using WebModel.CourseLector;

namespace EduFacade.CourseLectorFacade.Convertor
{
    public interface ICourseLectorConvertor
    {
        AddCourseLector ConvertToBussinessEntity(AddCourseLectorDto addCourseLectorDto);
        HashSet<GetAllLectorCourseTermDto> ConvertToWebModel(HashSet<CourseTermLector> courseTermLectors);
    }
}
