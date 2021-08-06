using Microsoft.Extensions.Configuration;
using Model.Functions.CourseTest;
using System.Collections.Generic;
using System.Linq;
using WebModel.CourseTest;

namespace EduFacade.TestFacade.Convertor
{
    public class TestConvertor : ITestConvertor
    {
        private readonly string _fileRepositoryPath;
        public TestConvertor(IConfiguration configuration)
        {
            _fileRepositoryPath = string.Format("{0}{1}", configuration.GetSection("FileServerUrl").Value, "test/");
        }
        public AddCourseTest ConvertToBussinessEntity(AddCourseTestDto addCourseTestDto)
        {
            return new AddCourseTest()
            {
                BankOfQuestion = addCourseTestDto.BankOfQuestion,
                DesiredSuccess = addCourseTestDto.DesiredSuccess,
                IsRandomGenerateQuestion = addCourseTestDto.IsRandomGenerateQuestion,
                QuestionCountInTest = addCourseTestDto.QuestionCountInTest,
                TimeLimit = addCourseTestDto.TimeLimit,
                MaxRepetition = addCourseTestDto.MaxRepetition
            };
        }

        public UpdateCourseTest ConvertToBussinessEntity(UpdateCourseTestDto updateCourseTestDto)
        {
            return new UpdateCourseTest()
            {
                BankOfQuestion = updateCourseTestDto.BankOfQuestion,
                CourseLessonId = updateCourseTestDto.Id,
                DesiredSuccess = updateCourseTestDto.DesiredSuccess,
                IsRandomGenerateQuestion = updateCourseTestDto.IsRandomGenerateQuestion,
                QuestionCountInTest = updateCourseTestDto.QuestionCountInTest,
                TimeLimit = updateCourseTestDto.TimeLimit,
                MaxRepetition = updateCourseTestDto.MaxRepetition
            };
        }

        public GetCourseTestDetailDto ConvertToWebModel(GetCourseTestDetail getCourseTestDetail)
        {
            return new GetCourseTestDetailDto()
            {
                Description = getCourseTestDetail.Description,
                DesiredSuccess = getCourseTestDetail.DesiredSuccess,
                Id = getCourseTestDetail.Id,
                IsRandomGenerateQuestion = getCourseTestDetail.IsRandomGenerateQuestion,
                Name = getCourseTestDetail.Name,
                QuestionCountInTest = getCourseTestDetail.QuestionCountInTest,
                TimeLimit = getCourseTestDetail.TimeLimit,
                BankOfQuestion = getCourseTestDetail.BankOfQuestion.Select(x => x.BankOfQuestionId).ToHashSet(),
                MaxRepetition = getCourseTestDetail.MaxRepetition
            };
        }

        public HashSet<GetAllStudentTestResultDto> ConvertToWebModel(HashSet<GetAllStudentTestResult> getAllStudentTestResults)
        {
            return getAllStudentTestResults.Select(x => new GetAllStudentTestResultDto()
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Name = x.Name,
                SecondName = x.SecondName,
                UserEmail = x.UserEmail,
                Finish = x.Finish,
                Score = x.Score,
                TestCompleted = x.TestCompleted
            }).ToHashSet();
        }

        public HashSet<ShowStudentAnswerDto> ConvertToWebModel(HashSet<GetStudentQuestion> showStudentAnswers)
        {
            return showStudentAnswers.Select(x => new ShowStudentAnswerDto()
            {
                AnswerMode = x.AnswerMode,
                Id = x.Id,
                IsTrue = x.IsTrue,
                Question = x.Question,
                Score = x.Score,
                Answer = x.Answers.Select(y => new StudentAswerResult()
                {
                    Answer = y.Answer,
                    AnswerId = y.AnswerId,
                    Id = y.Id,
                    IsTrueAnswer = y.IsTrueAnswer,
                    Text = y.Text,
                    UserAnswer = y.UserAnswer
                }).ToHashSet()
            }).ToHashSet();
        }

        public ShowTestResultDto ConvertToWebModel(ShowTestResult showTestResult)
        {
            return new ShowTestResultDto()
            {
                Finish = showTestResult.Finish,
                Id = showTestResult.Id,
                Question = showTestResult.GetUserTestQuestions.Select(x => new ShowTestResultQuestionDto()
                {
                    Id = x.Id,
                    IsTrue = x.IsTrue,
                    TestQuestionId = x.TestQuestionId,
                    AnswerMode = x.AnswerMode,
                    Question = x.Question,
                    Score = x.Score,
                    IsAutomaticEvaluate = x.IsAutomaticEvaluate,
                    UserAnswers = x.Answers.Select(y => new ShowTestResultAnswerDto()
                    {
                        Id = y.Id,
                        Answer = y.Answer,
                        IsTrueAnswer = y.IsTrue,
                        TestQuestionAnswerId = y.TestQuestionAnswerId,
                        Text = y.Text,
                        UserAnswer = y.UserAnswer,
                        UserAnswerIsCorrect = y.UserAnswerIsCorrect,
                        FilePath = y.FilePath,
                        UserTestImageAnswer =string.Format("{0}{1}.png",_fileRepositoryPath, y.UserTestImageAnswer)
                        

                    }).ToHashSet(),
                    FilePath = x.FilePath,
                    QuestionMode = x.QuestionMode,
                    QuestionModeId = x.QuestionModeId

                }).ToHashSet(),
                Score = showTestResult.Score,
                StartTime = showTestResult.StartTime,
                TestCompleted = showTestResult.TestCompleted,
                IsAutomaticEvaluate = showTestResult.IsAutomaticEvaluate,

            };
        }
    }
}
