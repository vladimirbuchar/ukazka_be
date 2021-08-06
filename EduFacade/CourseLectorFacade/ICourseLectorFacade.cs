using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.CourseLector;

namespace EduFacade.CourseLectorFacade
{
    public interface ICourseLectorFacade : IBaseFacade
    {
        Result AddCourseLector(AddCourseLectorDto addCourseLectorDto);
        void DeleteCourseTermLector(Guid oid);
        HashSet<GetAllLectorCourseTermDto> GetAllLectorCourseTerm(Guid courseTermId);
    }
}
