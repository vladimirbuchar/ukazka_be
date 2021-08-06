﻿using EduRepository.CourseLectorRepository;
using Model.Functions.CourseLector;
using Model.Functions.CourseStudent;
using Model.Tables.Link;
using System;
using System.Collections.Generic;

namespace EduServices.CourseLectorService
{
    public class CourseLectorService : BaseService, ICourseLectorService
    {
        private readonly ICourseLectorRepository _courseLectorRepository;
        public CourseLectorService(ICourseLectorRepository courseLectorRepository)
        {
            _courseLectorRepository = courseLectorRepository;
        }

        public void AddCourseLector(AddCourseLector addCourseLector)
        {
            _courseLectorRepository.AddCourseLector(addCourseLector);
        }
        public void DeleteCourseTermLector(Guid courseLectorTemId)
        {
            _courseLectorRepository.DeleteEntity<CourseLector>(courseLectorTemId);
        }


        public HashSet<CourseTermLector> GetAllLectorCourseTerm(Guid courseTermId)
        {
            return _courseLectorRepository.GetAllLectorCourseTerm(courseTermId);
        }

        public HashSet<GetMyCourse> GetLectorCourse(Guid userId)
        {
            return _courseLectorRepository.GetLectorCourse(userId);
        }
    }
}
