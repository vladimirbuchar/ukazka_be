using Core.DataTypes;
using EduRepository.CourseStudentRepository;
using EduRepository.CourseTermRepository;
using Model.Functions.CourseStudent;
using Model.Functions.CourseTerm;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseStudentService
{
    public class CourseStudentService : BaseService, ICourseStudentService
    {
        private readonly ICourseStudentRepository _studentRepository;
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseStudentService(ICourseStudentRepository studentRepository, ICourseTermRepository courseTermRepository)
        {
            _studentRepository = studentRepository;
            _courseTermRepository = courseTermRepository;
        }

        public void AddStudentToCourseTerm(AddStudentToCourseTerm addStudentToCourseTerm)
        {
            _studentRepository.AddStudentToCourseTerm(addStudentToCourseTerm);
        }

        public void DeleteStudentFromCourseTerm(Guid courseStudentTermId)
        {
            _studentRepository.DeleteEntity<CourseStudent>(courseStudentTermId);
        }

        public HashSet<GetAllStudentInCourseTerm> GetAllStudentInCourseTerm(Guid termId)
        {
            return _studentRepository.GetAllStudentInCourseTerm(termId);
        }

        public void IsTermStudent(Guid termId, Guid studentId, Result result)
        {
            IEnumerable<GetAllStudentInCourseTerm> students = _studentRepository.GetAllStudentInCourseTerm(termId);
            if (students.Where(x => x.StudentId == studentId).FirstOrDefault() != null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_STUDENT", "STUDENT_IS_IN_COURSE"));
            }
        }
        public void ValidateStudentCount(Guid termId, Result validate)
        {
            GetCourseTermDetail term = _courseTermRepository.GetCourseTermDetail(termId);
            int maximumStudent = term?.MaximumStudent ?? 0;
            if (maximumStudent > 0)
            {
                if (maximumStudent < (_studentRepository.GetAllStudentInCourseTerm(termId).Count + 1))
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE", "ADD_MORE_STUDENTS_THAN_MAXIMUM"));
                }
            }
        }
        public HashSet<GetMyCourse> GetStudentCourse(Guid userId, bool hideFinishCourse)
        {
            if (hideFinishCourse)
            {
                return _studentRepository.GetStudentCourse(userId).Where(x => x.CourseFinish == false).ToHashSet();
            }
            return _studentRepository.GetStudentCourse(userId).OrderBy(x => x.CourseFinish).ToHashSet();
        }
    }
}
