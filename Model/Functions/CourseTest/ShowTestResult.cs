using System;
using System.Collections.Generic;

namespace Model.Functions.CourseTest
{
    public class ShowTestResult : SqlFunction
    {
        public ShowTestResult()
        {
            GetUserTestQuestions = new HashSet<GetUserTestQuestion>();
        }
        public Guid Id { get; set; }
        public double Score { get; set; }
        public DateTime? Finish { get; set; }
        public bool TestCompleted { get; set; }
        public DateTime? StartTime { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
        public HashSet<GetUserTestQuestion> GetUserTestQuestions { get; set; }



    }
}
