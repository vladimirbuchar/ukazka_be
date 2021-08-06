using Model.Functions.CourseStudent;
using System.Collections.Generic;
using System.Linq;
using WebModel.Student;
namespace EduFacade.CourseStudentFacade.Convertor
{
    public class CourseStudentConvertor : ICourseStudentConvertor
    {


        public HashSet<GetAllStudentInCourseTermDto> ConvertToWebModel(HashSet<GetAllStudentInCourseTerm> getStudentsInTerms)
        {
            return getStudentsInTerms.Select(item => new GetAllStudentInCourseTermDto()
            {
                FirstName = item.FirstName,
                Id = item.Id,
                LastName = item.LastName,
                SecondName = item.SecondName,
                StudentId = item.StudentId,
                Email = item.UserEmail,
                CourseFinish = item.CourseFinish
            }).ToHashSet();
        }


    }
}
