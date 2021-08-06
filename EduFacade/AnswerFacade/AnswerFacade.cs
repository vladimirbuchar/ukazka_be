using Core.DataTypes;
using EduFacade.AnswerFacade.Convertor;
using EduServices.AnswerService;
using EduServices.CodeBookService;
using Model.Functions.Answer;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Answer;
namespace EduFacade.AnswerFacade
{
    public class AnswerFacade : BaseFacade, IAnswerFacade
    {
        private readonly IAnswerService _answerService;
        private readonly IAnswerConvertor _answerConvertor;
        private readonly HashSet<AnswerMode> _answerModes;
        public AnswerFacade(IAnswerService answerService, IAnswerConvertor answerConvertor, ICodeBookService codeBookService)
        {
            _answerService = answerService;
            _answerConvertor = answerConvertor;
            _answerModes = codeBookService.GetCodeBookItems<AnswerMode>();
        }

        public Result AddAnswer(AddAnswerDto addAnswerDto)
        {
            Result reslut = Validate(addAnswerDto);
            if (reslut.IsOk)
            {
                AddAnswer addAnswer = _answerConvertor.ConvertToBussinessEntity(addAnswerDto);
                return new Result<Guid>()
                {
                    Data = _answerService.AddAnswer(addAnswer)
                };
            }
            return reslut;
        }
        private Result Validate(AddAnswerDto addAnswerDto)
        {
            Result result = new Result();
            if (_answerModes.FirstOrDefault(x => x.Id == addAnswerDto.AnswerMode).SystemIdentificator == AnswerModeValues.SELECT_MANY || _answerModes.FirstOrDefault(x => x.Id == addAnswerDto.AnswerMode).SystemIdentificator == AnswerModeValues.SELECT_ONE)
            {
                _answerService.ValidateAnswer(addAnswerDto.Answer, result);
            }
            return result;
        }
        private Result Validate(UpdateAnswerDto updateAnswerDto)
        {
            Result result = new Result();
            if (_answerModes.FirstOrDefault(x => x.Id == updateAnswerDto.AnswerMode).SystemIdentificator == AnswerModeValues.SELECT_MANY || _answerModes.FirstOrDefault(x => x.Id == updateAnswerDto.AnswerMode).SystemIdentificator == AnswerModeValues.SELECT_ONE)
            {
                _answerService.ValidateAnswer(updateAnswerDto.Answer, result);
            }
            return result;
        }


        public HashSet<GetAnswersInQuestionDto> GetAnswersInQuestion(Guid questionId)
        {
            return _answerConvertor.ConvertToWebModel(_answerService.GetAnswersInQuestion(questionId));
        }

        public GetAnswerDetailDto GetAnswerDetail(Guid answerId)
        {
            return _answerConvertor.ConvertToWebModel(_answerService.GetAnswerDetail(answerId));
        }

        public Result UpdateAnswer(UpdateAnswerDto updateAnswerDto)
        {
            Result result = Validate(updateAnswerDto);
            if (result.IsOk)
            {
                UpdateAnswer updateAnswer = _answerConvertor.ConvertToBussinessEntity(updateAnswerDto);
                _answerService.UpdateAnswer(updateAnswer);
            }
            return result;
        }

        public void DeleteAnswer(Guid answerId)
        {
            _answerService.DeleteAnswer(answerId);
        }

        public void DeleteAnswerInQuestion(Guid questionId)
        {
            HashSet<GetAnswersInQuestion> answers = _answerService.GetAnswersInQuestion(questionId);
            foreach (GetAnswersInQuestion item in answers)
            {
                _answerService.DeleteAnswer(item.Id);
            }
        }
    }
}
