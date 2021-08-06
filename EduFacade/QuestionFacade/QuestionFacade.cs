using Core.DataTypes;
using EduFacade.QuestionFacade.Convertor;
using EduServices.AnswerService;
using EduServices.CodeBookService;
using EduServices.QuestionService;
using Model.Functions.Question;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Question;

namespace EduFacade.CourseFacade
{
    public class QuestionFacade : BaseFacade, IQuestionFacade
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionConvertor _questionConvertor;
        private readonly IAnswerService _answerService;
        private readonly HashSet<AnswerMode> _answerModes;
        public QuestionFacade(IQuestionService questionService, IQuestionConvertor questionConvertor, IAnswerService answerService, ICodeBookService codebookService)
        {
            _questionService = questionService;
            _questionConvertor = questionConvertor;
            _answerService = answerService;
            _answerModes = codebookService.GetCodeBookItems<AnswerMode>();
        }

        public Result AddQuestion(AddQuestionDto addQuestionDto)
        {
            Result result = Validate(addQuestionDto);
            if (result.IsOk)
            {
                AddQuestion addQuestion = _questionConvertor.ConvertToBussinessEntity(addQuestionDto);
                Guid qid = _questionService.AddQuestion(addQuestion);
                string answerMode = _answerModes.FirstOrDefault(x => x.Id == addQuestionDto.AnswerModeId).SystemIdentificator;
                if (answerMode == AnswerModeValues.YES_NO_TRUE_YES || answerMode == AnswerModeValues.YES_NO_TRUE_NO)
                {
                    GenerateYesNoAnswer(qid, answerMode);
                }
                return new Result<Guid>()
                {
                    Data = qid
                };
            }

            return result;
        }
        private Result Validate(AddQuestionDto addQuestionDto)
        {
            Result result = new Result();
            if (addQuestionDto.Validate)
            {
                _questionService.ValidateQuestionName(addQuestionDto.Question, result);
                _questionService.ValidateAnswerMode(addQuestionDto.AnswerModeId, result);
                _questionService.ValidateQuestionMode(addQuestionDto.QuestionModeId, result);
            }
            return result;
        }
        private Result Validate(UpdateQuestionDto updateQuestionDto)
        {
            Result result = new Result();
            _questionService.ValidateQuestionName(updateQuestionDto.Question, result);
            _questionService.ValidateAnswerMode(updateQuestionDto.AnswerModeId, result);
            _questionService.ValidateQuestionMode(updateQuestionDto.QuestionModeId, result);
            return result;
        }

        public HashSet<GetQuestionInOrganizationDto> GetQuestionInOrganization(Guid organizationId)
        {
            return _questionConvertor.ConvertToWebModel(_questionService.GetQuestionInOrganization(organizationId));
        }

        public GetQuestionDetailDto GetQuestionDetail(Guid qestionId)
        {
            return _questionConvertor.ConvertToWebModel(_questionService.GetQuestionDetail(qestionId));
        }

        public Result UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            Result result = Validate(updateQuestionDto);
            if (result.IsOk)
            {
                GetQuestionDetail oldData = _questionService.GetQuestionDetail(updateQuestionDto.Id);
                UpdateQuestion updateQuestion = _questionConvertor.ConvertToBussinessEntity(updateQuestionDto);
                if (oldData.AnswerModeId != updateQuestionDto.AnswerModeId)
                {
                    string answerMode = _answerModes.FirstOrDefault(x => x.Id == updateQuestionDto.AnswerModeId).SystemIdentificator;
                    if (answerMode == AnswerModeValues.YES_NO_TRUE_YES || answerMode == AnswerModeValues.YES_NO_TRUE_NO)
                    {
                        GenerateYesNoAnswer(updateQuestionDto.Id, answerMode);
                    }
                }
                _questionService.UpdateQuestion(updateQuestion);

            }
            return result;
        }

        public void DeleteQuestion(Guid questionId)
        {
            _questionService.DeleteQuestion(questionId);
        }
        private void GenerateYesNoAnswer(Guid questionId, string answerMode)
        {
            _answerService.AddAnswer(new Model.Functions.Answer.AddAnswer()
            {
                QuestionId = questionId,
                Answer = "TEST_ANSWER_YES",
                IsTrueAnswer = answerMode == AnswerModeValues.YES_NO_TRUE_YES
            });
            _answerService.AddAnswer(new Model.Functions.Answer.AddAnswer()
            {
                QuestionId = questionId,
                Answer = "TEST_ANSWER_NO",
                IsTrueAnswer = answerMode == AnswerModeValues.YES_NO_TRUE_NO
            });
        }
    }
}
