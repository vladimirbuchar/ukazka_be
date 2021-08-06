using Core.DataTypes;
using Model.Functions.CourseTest;
using Model.Functions.Question;
using System;
using System.Collections.Generic;

namespace EduServices.TestService
{
    public interface ITestService : IBaseService
    {
        void AddCourseTest(AddCourseTest addCourseTest);
        GetCourseTestDetail GetCourseTestDetail(Guid courseLessonId);
        void UpdateCourseTest(UpdateCourseTest updateCourseTest);
        void ValidateCourseTestBankOfQuestion(List<Guid> guids, Result result);
        void ValidateCourseTestQuestionCountInTest(int questionCountInTest, Result result);
        void ValidateCourseTestTimeLimit(int timeLimit, Result result);
        void ValidateCourseTestDesiredSuccess(int desiredSuccess, Result result);

        /// <summary>
        /// generate test question for students
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
        List<GetQuestionsInBank> GenerateTest(Guid courseLessonId, Guid userId, Guid courseId);
        /// <summary>
        /// Evaluate test
        /// </summary>
        /// <param name="userTestSummaryId"></param>
        /// <param name="userAnswerRequests"></param>
        /// <returns></returns>
        EvaluateTestResult EvaluateTest(Guid userTestSummaryId);
        /// <summary>
        /// start test 
        /// </summary>
        /// <param name="testId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Guid StartTest(Guid testId, Guid userId, Guid courseId);
        ShowTestResult ShowStudentAnswer(Guid userTesId);
        HashSet<GetAllStudentTestResult> GetAllStudentTestResult(Guid couseId);
        // HashSet<GetStudentQuestion> ShowStudentAnswer(Guid studentTestResultId);
        void SetLectorControl(Guid questionId, bool isTrue, int score, Guid studentTestResultId);
        void EvaluateQuestion(Guid userTestSummaryId, Guid questionId, List<Guid> answerId, string textAnswer, Guid fileName);
        bool CanRunTest(Guid testId, Guid userId);
        HashSet<GetStudentTest> GetStudentTest(Guid userId);
    }
}
