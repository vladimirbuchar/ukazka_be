using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Answer;

namespace EduFacade.AnswerFacade
{
    public interface IAnswerFacade : IBaseFacade
    {
        Result AddAnswer(AddAnswerDto addAnswerDto);
        HashSet<GetAnswersInQuestionDto> GetAnswersInQuestion(Guid questionId);
        GetAnswerDetailDto GetAnswerDetail(Guid qestionId);
        Result UpdateAnswer(UpdateAnswerDto updateAnswerDto);
        void DeleteAnswer(Guid answerId);
        void DeleteAnswerInQuestion(Guid questionId);
    }
}

