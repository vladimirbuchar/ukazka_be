using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.CourseTest;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.TestRepository
{
    public class TestRepository : BaseRepository, ITestRepository
    {
        public TestRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
        }

        public Guid AddCourseTest(AddCourseTest addCourseTest)
        {
            Guid outGuid = Guid.Empty;
            CallSqlProcedure("AddCourseTest", new List<SqlParameter>()
            {
                new SqlParameter("@IsRandomGenerateQuestion",addCourseTest.IsRandomGenerateQuestion),
                new SqlParameter("@QuestionCountInTest",addCourseTest.QuestionCountInTest),
                new SqlParameter("@TimeLimit",addCourseTest.TimeLimit),
                new SqlParameter("@DesiredSuccess", addCourseTest.DesiredSuccess),
                new SqlParameter("@CourseLessonId",addCourseTest.CourseLessonId),
                new SqlParameter("@MaxRepetition",addCourseTest.MaxRepetition)
            }, true, ref outGuid);
            return outGuid;


        }

        public HashSet<GetBankOfQuestion> GetBankOfQuestion(Guid testId)
        {
            return CallSqlFunction<GetBankOfQuestion>("GetBankOfQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@CourseTestId",testId)
            });
        }

        public GetCourseTestDetail GetCourseTestDetail(Guid courseLessonId)
        {
            return CallSqlFunction<GetCourseTestDetail>("GetCourseTestDetail", new List<SqlParameter>()
            {
                new SqlParameter("@courseLessonId",courseLessonId)
            }).FirstOrDefault();
        }

        public void JoinTestWithBankOfQuestion(Guid testId, Guid bankOfQuestionId)
        {
            CallSqlProcedure("JoinTestWithBankOfQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@BankOfQuestionId",bankOfQuestionId),
                new SqlParameter("@CourseTestId",testId)
            });
        }

        public Guid StartTest(Guid testId, Guid userId, Guid courseId)
        {
            List<SqlParameter> sql = new List<SqlParameter>
            {
                new SqlParameter("@StartTime", DateTime.Now),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@Finish", DateTime.Now),
                new SqlParameter("@TestCompleted", false),
                new SqlParameter("@CourseTestId", testId),
                new SqlParameter("@CourseId",courseId)
            };
            Guid newGuid = Guid.Empty;
            CallSqlProcedure("StartTest", sql, true, ref newGuid);
            return newGuid;
        }

        public void EvaluateTest(Guid studentTestSummaryId)
        {
            List<SqlParameter> sql = new List<SqlParameter>
            {
                new SqlParameter("@StudentTestSummaryId", studentTestSummaryId)
            };
            CallSqlProcedure("EvaluateTest", sql);
        }


        public void UpdateCourseTest(UpdateCourseTest updateCourseTest)
        {
            CallSqlProcedure("UpdateCourseTest", new List<SqlParameter>()
            {
               new SqlParameter("@IsRandomGenerateQuestion", updateCourseTest.IsRandomGenerateQuestion),
               new SqlParameter("@QuestionCountInTest", updateCourseTest.QuestionCountInTest),
               new SqlParameter("@TimeLimit", updateCourseTest.TimeLimit),
               new SqlParameter("@DesiredSuccess",updateCourseTest.DesiredSuccess),
               new SqlParameter("@CourseLessonId",updateCourseTest.CourseLessonId),
               new SqlParameter("@MaxRepetition",updateCourseTest.MaxRepetition)
            });
        }

        public Guid SaveUserTestQuestion(Guid studentTestSummaryId, EvaluateTestQuestion evaluateTestQuestion)
        {
            Guid outGuid = Guid.Empty;
            CallSqlProcedure("AddStudentTestSummaryQuestion", new List<SqlParameter>()
            {
               new SqlParameter("@StudentTestSummaryId", studentTestSummaryId),
               new SqlParameter("@TestQuestionId", evaluateTestQuestion.Id),
               new SqlParameter("@Score", evaluateTestQuestion.Score),
               new SqlParameter("@IsAutomaticEvaluate",evaluateTestQuestion.IsAutomaticEvaluate),
               new SqlParameter("@IsTrue",evaluateTestQuestion.IsTrueUserAnswer),

            }, true, ref outGuid);
            return outGuid;
        }

        public void SaveUserTestAnswer(Guid studendTestQuestionId, EvaluateTestAnswer evaluateTestAnswer)
        {
            CallSqlProcedure("AddStudentTestSummaryAnswer", new List<SqlParameter>()
            {
               new SqlParameter("@TestQuestionAnswerId", evaluateTestAnswer.Id),
               new SqlParameter("@StudentTestSummaryQuestionId", studendTestQuestionId),
               new SqlParameter("@IsTrue", evaluateTestAnswer.IsUserAnswer),
               new SqlParameter("@Text",evaluateTestAnswer.Text??string.Empty)
            });
        }

        public HashSet<GetUserTestQuestion> GetUserTestQuestion(Guid studentTestSummaryId)
        {
            List<SqlParameter> sql = new List<SqlParameter>
            {
                new SqlParameter("@studentTestSummaryId", studentTestSummaryId)
            };
            return CallSqlFunction<GetUserTestQuestion>("GetUserTestQuestion", sql);
        }

        public HashSet<GetUserTestQuestionAnswer> GetUserTestQuestionAnswer(Guid questionId)
        {
            List<SqlParameter> sql = new List<SqlParameter>
            {
                new SqlParameter("@studentTestQuestionId", questionId)
            };
            return CallSqlFunction<GetUserTestQuestionAnswer>("GetUserTestQuestionAnswer", sql);
        }

        public HashSet<GetAllStudentTestResult> GetAllStudentTestResult(Guid courseId)
        {
            return CallSqlFunction<GetAllStudentTestResult>("GetAllStudentTestResult", new List<SqlParameter>()
            {
                new SqlParameter("@courseId",courseId)
            });
        }

        public HashSet<GetStudentQuestion> GetStudentQuestion(Guid studentTestResultId)
        {
            return CallSqlFunction<GetStudentQuestion>("GetStudentQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@studentTestSummaryId",studentTestResultId)
            });
        }

        public HashSet<GetStudentAnswer> GetStudentAnswer(Guid questionId)
        {
            return CallSqlFunction<GetStudentAnswer>("GetStudentAnswer", new List<SqlParameter>()
            {
                new SqlParameter("@StudentTestSummaryQuestionId",questionId)
            }).ToHashSet();
        }

        public ShowTestResult ShowTestResult(Guid userTestId)
        {
            return CallSqlFunction<ShowTestResult>("ShowTestResult", new List<SqlParameter>()
            {
                new SqlParameter("@userTestId",userTestId)
            }).FirstOrDefault();
        }

        public void SetLectorControl(Guid questionId, bool isTrue, int score)
        {
            CallSqlProcedure("SetLectorControl", new List<SqlParameter>()
            {
                new SqlParameter("@QuestionId",questionId),
                new SqlParameter("@IsTrue",isTrue),
                new SqlParameter("@Score",score)
            });
        }

        public void UpdateTestCompleted(Guid studentTestResultId)
        {
            CallSqlProcedure("UpdateTestCompleted", new List<SqlParameter>()
            {
                new SqlParameter("@StudentTestSummaryId",studentTestResultId),
            });
        }

        public Guid CreateUserTestQuestion(string question, bool isAutomaticEvaluate, Guid answerModeId, int position, Guid questionId, Guid questionModeId, string filePath)
        {
            Guid outGuid = Guid.Empty;
            CallSqlProcedure("CreateUserTestQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@Question", question),
                new SqlParameter("@IsAutomaticEvaluate", isAutomaticEvaluate),
                new SqlParameter("@AnswerModeId", answerModeId),
                new SqlParameter("@Position",position),
                new SqlParameter("@QuestionId",questionId),
                new SqlParameter("@QuestionModeId",questionModeId),
                new SqlParameter("@FilePath",filePath)

            }, true, ref outGuid);
            return outGuid;
        }
        public Guid CreateUserTestQuestionAnswer(Guid studentTestSummaryQuestionId, string answer, bool isTrueAnswer, int position, Guid answerId, string filePath)
        {
            Guid outGuid = Guid.Empty;
            CallSqlProcedure("CreateUserTestQuestionAnswer", new List<SqlParameter>()

                {
                    new SqlParameter("@StudentTestSummaryQuestionId",studentTestSummaryQuestionId),
                    new SqlParameter("@Answer", answer),
                    new SqlParameter("@IsTrueAnswer",isTrueAnswer),
                    new SqlParameter("@Position", position),
                    new SqlParameter("@AnswerId",answerId),
                    new SqlParameter("@FilePath",filePath)
            }
            , true, ref outGuid);
            return outGuid;
        }

        public void EvaluateAnswer(Guid answer, string text, Guid questionId, Guid fileName)
        {
            CallSqlProcedure("EvaluateAnswer", new List<SqlParameter>()
            {
                new SqlParameter("@AnswerId",answer),
                new SqlParameter("@AnswerText",text),
                new SqlParameter("@QuestionId",questionId),
                new SqlParameter("@fileName",fileName)

            });
        }

        public void EvaluateQuestion(Guid userTestSummaryId, Guid questionId)
        {
            CallSqlProcedure("EvaluateQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@UserTestSummaryId",userTestSummaryId),
                new SqlParameter("@QuestionId", questionId)
            });
        }

        public EvaluateTestResult GetTestResult(Guid userTestSummaryId)
        {
            return CallSqlFunction<EvaluateTestResult>("EvaluateTestResult", new List<SqlParameter>()
            {
                new SqlParameter("@UserTestSummaryId",userTestSummaryId)
            }).FirstOrDefault();
        }

        public HashSet<GetStudentTest> GetStudentTest(Guid userId)
        {
            return CallSqlFunction<GetStudentTest>("GetStudentTest", new List<SqlParameter>()
            {
                new SqlParameter("@userId",userId)
            }).ToHashSet();
        }
    }
}
