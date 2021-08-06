namespace Model.Functions.CourseTest
{
    public class EvaluateTestResult : SqlFunction
    {
        public double Score { get; set; }
        public bool Sucess { get; set; }
        public bool IsAutomatic { get; set; }
    }
}
