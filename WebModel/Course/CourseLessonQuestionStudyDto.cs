using System;
using System.Collections.Generic;

namespace WebModel.Course
{
    public class CourseLessonQuestionStudyDto
    {
        public CourseLessonQuestionStudyDto()
        {
            Answers = new HashSet<CourseLessonAnswerDto>();
        }
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string AnswerMode { get; set; }
        public HashSet<CourseLessonAnswerDto> Answers { get; set; }
        public string QuestionMode { get; set; }
        public string FilePath { get; set; }

    }
}
