using Core.DataTypes;
using Core.Extension;
using EduRepository.AnswerRepository;
using EduRepository.CourseRepository;
using EduRepository.QuestionRepository;
using EduRepository.TestRepository;
using Microsoft.Extensions.Configuration;
using Model.Functions.Answer;
using Model.Functions.Course;
using Model.Functions.CourseTest;
using Model.Functions.Question;
using Model.Tables.CodeBook;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.TestService
{
    public class TestService : BaseService, ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IConfiguration _configuration;
        private readonly ICourseRepository _courseRepository;

        public TestService(ITestRepository testRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, IConfiguration configuration, ICourseRepository courseRepository)
        {
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _configuration = configuration;
            _courseRepository = courseRepository;
        }

        public void AddCourseTest(AddCourseTest addCourseTest)
        {
            Guid testId = _testRepository.AddCourseTest(addCourseTest);
            foreach (Guid bankOfQuestionId in addCourseTest.BankOfQuestion)
            {
                _testRepository.JoinTestWithBankOfQuestion(testId, bankOfQuestionId);
            }

        }
        public GetCourseTestDetail GetCourseTestDetail(Guid courseLessonId)
        {
            GetCourseTestDetail getCourseTestDetail = _testRepository.GetCourseTestDetail(courseLessonId);
            if (getCourseTestDetail == null)
            {
                return null;
            }
            getCourseTestDetail.BankOfQuestion = _testRepository.GetBankOfQuestion(getCourseTestDetail.TestId);
            return getCourseTestDetail;
        }
        public void UpdateCourseTest(UpdateCourseTest updateCourseTest)
        {
            _testRepository.UpdateCourseTest(updateCourseTest);
            GetCourseTestDetail getCourseTestDetail = GetCourseTestDetail(updateCourseTest.CourseLessonId);
            foreach (GetBankOfQuestion item in getCourseTestDetail.BankOfQuestion)
            {
                if (!updateCourseTest.BankOfQuestion.Contains(item.BankOfQuestionId))
                {
                    _testRepository.DeleteEntity<LinkTestBankOfQuestion>(item.Id);
                }
            }
            foreach (Guid bankOfQuestionId in updateCourseTest.BankOfQuestion)
            {
                if (!getCourseTestDetail.BankOfQuestion.Select(x => x.BankOfQuestionId).Contains(bankOfQuestionId))
                {
                    _testRepository.JoinTestWithBankOfQuestion(getCourseTestDetail.TestId, bankOfQuestionId);
                }
            }
        }

        public EvaluateTestResult EvaluateTest(Guid userTestSummaryId)
        {
            _testRepository.EvaluateTest(userTestSummaryId);
            return _testRepository.GetTestResult(userTestSummaryId);
        }

        public List<GetQuestionsInBank> GenerateTest(Guid courseLessonId, Guid userId, Guid courseId)
        {
            if (CanRunTest(courseLessonId, userId))
            {
                GetCourseTestDetail getCourseTestDetail = GetCourseTestDetail(courseLessonId);
                GetCourseDetail courseDetail = _courseRepository.GetCourseDetail(courseId);
                List<GetQuestionsInBank> getQuestionsInBanks = new List<GetQuestionsInBank>();
                foreach (GetBankOfQuestion item in getCourseTestDetail.BankOfQuestion)
                {
                    getQuestionsInBanks = getQuestionsInBanks.Concat(_questionRepository.GetQuestionInBank(item.BankOfQuestionId).ToList()).ToList();
                }
                if (getCourseTestDetail.IsRandomGenerateQuestion)
                {
                    getQuestionsInBanks = getQuestionsInBanks.ToList().Shuffle().ToList();
                }
                if (getCourseTestDetail.QuestionCountInTest > 0)
                {
                    getQuestionsInBanks = getQuestionsInBanks.ToList().Limit(getCourseTestDetail.QuestionCountInTest).ToList();
                }
                foreach (GetQuestionsInBank item in getQuestionsInBanks)
                {
                    bool isAutomatic = item.AnswerMode == AnswerModeValues.SELECT_MANY || item.AnswerMode == AnswerModeValues.SELECT_ONE || item.AnswerMode == AnswerModeValues.YES_NO_TRUE_NO
                        || item.AnswerMode == AnswerModeValues.YES_NO_TRUE_YES || item.AnswerMode == AnswerModeValues.SELECT_ONE_IMAGE || item.AnswerMode == AnswerModeValues.SELECT_MANY_IMAGE
                        || item.AnswerMode == AnswerModeValues.SELECT_ONE_VIDEO || item.AnswerMode == AnswerModeValues.SELECT_MANY_VIDEO
                        || item.AnswerMode == AnswerModeValues.SELECT_ONE_AUDIO || item.AnswerMode == AnswerModeValues.SELECT_MANY_AUDIO;
                    item.IsAutomatic = isAutomatic;
                    Guid questionId = _testRepository.CreateUserTestQuestion(item.Question, isAutomatic, item.AnswerModeId, item.Position, item.Id, item.QuestionModeId, string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, item?.ObjectOwner, item?.FileName));

                    if (getCourseTestDetail.IsRandomGenerateQuestion)
                    {
                        item.Answer = _answerRepository.GetAnswersInQuestion(item.Id).ToList().Shuffle().ToHashSet();
                    }
                    else
                    {
                        item.Answer = _answerRepository.GetAnswersInQuestion(item.Id);
                    }
                    item.Id = questionId;
                    foreach (GetAnswersInQuestion answer in item.Answer)
                    {
                        answer.Id = _testRepository.CreateUserTestQuestionAnswer(questionId, answer.Answer, answer.IsTrueAnswer, answer.Position, answer.Id, string.Format("{0}{1}/{2}", _configuration.GetSection("FileServerUrl").Value, answer?.ObjectOwner, answer?.FileName));
                    }
                }
                if (!courseDetail.CourseWithLector)
                {
                    return getQuestionsInBanks.Where(x => x.IsAutomatic).ToList();
                }

                return getQuestionsInBanks;
            }
            return new List<GetQuestionsInBank>();
        }

        public Guid StartTest(Guid testId, Guid userId, Guid courseId)
        {
            return _testRepository.StartTest(testId, userId, courseId);
        }

        public void ValidateCourseTestBankOfQuestion(List<Guid> guids, Result result)
        {
            if (guids.Count == 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TEST", "BANK_OF_QUESTION_IS_NOT_SELECTED"));
            }
        }

        public void ValidateCourseTestQuestionCountInTest(int questionCountInTest, Result result)
        {
            if (questionCountInTest < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TEST", "QUESTION_COUNT_IS_NOT_VALID_VALUE"));
            }
        }

        public void ValidateCourseTestTimeLimit(int timeLimit, Result result)
        {
            if (timeLimit < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TEST", "TIME_LIMIT_IS_NOT_VALID_VALUE"));
            }
        }

        public void ValidateCourseTestDesiredSuccess(int desiredSuccess, Result result)
        {
            if (desiredSuccess < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TEST", "DESIRED_SUCCESS_IS_NOT_VALID_VALUE"));
            }
        }

        public HashSet<GetUserTestQuestion> ShowTestResult(Guid userTestId)
        {

            HashSet<GetUserTestQuestion> getUserTestQuestions = _testRepository.GetUserTestQuestion(userTestId);
            return getUserTestQuestions.Select(x => new GetUserTestQuestion()
            {
                Id = x.Id,
                IsTrue = x.IsTrue,
                TestQuestionId = x.TestQuestionId,
                Answers = _testRepository.GetUserTestQuestionAnswer(x.Id)
            }).ToHashSet();
        }

        public HashSet<GetAllStudentTestResult> GetAllStudentTestResult(Guid courseId)
        {
            return _testRepository.GetAllStudentTestResult(courseId).OrderByDescending(x => x.Finish).ToHashSet();
        }

        public ShowTestResult ShowStudentAnswer(Guid studentTestResultId)
        {
            ShowTestResult showTestResult = _testRepository.ShowTestResult(studentTestResultId);
            HashSet<GetStudentQuestion> getStudentQuestions = _testRepository.GetStudentQuestion(studentTestResultId);
            showTestResult.GetUserTestQuestions = getStudentQuestions.Select(x => new GetUserTestQuestion()
            {
                AnswerMode = x.AnswerMode,
                Id = x.Id,
                IsAutomaticEvaluate = x.IsAutomaticEvaluate,
                IsTrue = x.IsTrue,
                Question = x.Question,
                Score = x.Score,
                FilePath = x.FilePath,
                QuestionModeId = x.QuestionModeId,
                TestQuestionId = x.TestQuestionId,
                QuestionMode = x.QuestionMode,
                Answers = _testRepository.GetStudentAnswer(x.Id).Select(y => new GetUserTestQuestionAnswer()
                {
                    Id = y.Id,
                    Answer = y.Answer,
                    IsTrue = y.IsTrueAnswer,
                    UserAnswer = y.UserAnswer,
                    Text = y.UserTestAnswer,
                    UserAnswerIsCorrect = y.UserAnswerIsCorrect,
                    FilePath = y.FilePath,
                    TestQuestionAnswerId = y.TestQuestionAnswerId,
                    UserTestImageAnswer = y.UserTestImageAnswer

                }).ToHashSet()
            }).ToHashSet();
            return showTestResult;
        }

        public void SetLectorControl(Guid questionId, bool isTrue, int score, Guid studentTestResultId)
        {
            _testRepository.SetLectorControl(questionId, isTrue, score);
            _testRepository.UpdateTestCompleted(studentTestResultId);

        }

        public void EvaluateQuestion(Guid userTestSummaryId, Guid questionId, List<Guid> answerId, string textAnswer, Guid fileName)
        {
            if (answerId != null && answerId.Count > 0)
            {
                foreach (Guid answer in answerId)
                {
                    _testRepository.EvaluateAnswer(answer, "", questionId, fileName);
                }
            }
            else
            {
                _testRepository.EvaluateAnswer(Guid.Empty, textAnswer, questionId, fileName);
            }
            _testRepository.EvaluateQuestion(userTestSummaryId, questionId);
        }
        public HashSet<GetStudentTest> GetStudentTest(Guid userId)
        {
            return _testRepository.GetStudentTest(userId).OrderByDescending(x => x.Finish).ToHashSet();
        }

        public bool CanRunTest(Guid slideId, Guid userId)
        {
            GetCourseTestDetail getCourseTestDetail = _testRepository.GetCourseTestDetail(slideId);
            HashSet<GetStudentTest> tests = _testRepository.GetStudentTest(userId).Where(x => x.TestId == getCourseTestDetail.TestId).ToHashSet();
            if (getCourseTestDetail.MaxRepetition == 0)
            {
                return true;
            }
            else if (getCourseTestDetail.MaxRepetition == -1 && tests.FirstOrDefault(x => x.TestCompleted) == null)
            {
                return true;

            }
            else if (getCourseTestDetail.MaxRepetition >= tests.Count)
            {
                return true;
            }
            return false;

        }
    }
}
