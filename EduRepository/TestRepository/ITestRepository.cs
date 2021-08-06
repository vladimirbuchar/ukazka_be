using Model.Functions.CourseTest;
using System;
using System.Collections.Generic;

namespace EduRepository.TestRepository
{
    public interface ITestRepository : IBaseRepository
    {
        Guid AddCourseTest(AddCourseTest addCourseTest);
        void JoinTestWithBankOfQuestion(Guid testId, Guid bankOfQuestionId);
        GetCourseTestDetail GetCourseTestDetail(Guid courseLessonId);
        HashSet<GetBankOfQuestion> GetBankOfQuestion(Guid testId);
        void UpdateCourseTest(UpdateCourseTest updateCourseTest);
        Guid StartTest(Guid testId, Guid userId, Guid courseId);
        void EvaluateTest(Guid studentTestSummaryId);
        Guid SaveUserTestQuestion(Guid studentTestSummaryId, EvaluateTestQuestion evaluateTestQuestion);
        void SaveUserTestAnswer(Guid studendTestQuestionId, EvaluateTestAnswer evaluateTestQuestion);
        HashSet<GetUserTestQuestion> GetUserTestQuestion(Guid studentTestSummaryId);
        HashSet<GetUserTestQuestionAnswer> GetUserTestQuestionAnswer(Guid questionId);
        HashSet<GetAllStudentTestResult> GetAllStudentTestResult(Guid courseId);
        HashSet<GetStudentQuestion> GetStudentQuestion(Guid studentTestResultId);
        HashSet<GetStudentAnswer> GetStudentAnswer(Guid questionId);
        ShowTestResult ShowTestResult(Guid userTestId);
        void SetLectorControl(Guid questionId, bool isTrue, int score);
        void UpdateTestCompleted(Guid studentTestResultId);
        Guid CreateUserTestQuestion(string question, bool isAutomaticEvaluate, Guid answerModeId, int position, Guid questionId, Guid questionModeId, string filePath);
        Guid CreateUserTestQuestionAnswer(Guid studentTestSummaryQuestionId, string answer, bool isTrueAnswer, int position, Guid answerId, string filePath);
        void EvaluateAnswer(Guid answer, string answerText, Guid questionId, Guid fileName);
        void EvaluateQuestion(Guid userTestSummaryId, Guid questionId);
        EvaluateTestResult GetTestResult(Guid userTestSummaryId);
        HashSet<GetStudentTest> GetStudentTest(Guid userId);
    }

}
