using System;
using System.Collections.Generic;

namespace Model.Functions.CourseTest
{
    public class EvaluateTest : SqlFunction
    {
        public EvaluateTest()
        {
            EvaluateTestQuestion = new List<EvaluateTestQuestion>();
        }
        public Guid Id { get; set; }
        public List<EvaluateTestQuestion> EvaluateTestQuestion { get; set; }
        public bool IsAutomatic { get; set; }
        public double Score { get; set; }
        public bool IsSucess { get; set; }
    }
    public class EvaluateTestQuestion
    {
        public EvaluateTestQuestion()
        {
            EvaluateTestAnswer = new List<EvaluateTestAnswer>();
        }
        public Guid Id { get; set; }
        public List<EvaluateTestAnswer> EvaluateTestAnswer { get; set; }
        public int Score { get; set; }
        public bool IsTrueUserAnswer { get; set; }
        public bool IsAutomaticEvaluate { get; set; }
    }
    public class EvaluateTestAnswer
    {
        public Guid? Id { get; set; }
        public string Text { get; set; }
        public bool IsUserAnswer { get; set; }
    }
}
