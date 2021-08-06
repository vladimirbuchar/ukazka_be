using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.CourseTest
{
    public class ShowTestResultDto : BaseDto
    {
        public ShowTestResultDto()
        {
            Question = new HashSet<ShowTestResultQuestionDto>();
        }
        public Guid Id { get; set; }
        public double Score { get; set; }
        public DateTime? Finish { get; set; }
        public bool TestCompleted { get; set; }
        public DateTime? StartTime { get; set; }
        public HashSet<ShowTestResultQuestionDto> Question { get; set; }
        public bool IsAutomaticEvaluate { get; set; }


    }
}
