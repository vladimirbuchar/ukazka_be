using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Question;

namespace EduFacade.CourseFacade
{
    public interface IQuestionFacade : IBaseFacade
    {
        Result AddQuestion(AddQuestionDto addQuestionDto);
        HashSet<GetQuestionInOrganizationDto> GetQuestionInOrganization(Guid questionBankId);
        GetQuestionDetailDto GetQuestionDetail(Guid qestionId);
        Result UpdateQuestion(UpdateQuestionDto updateQuestionDto);
        void DeleteQuestion(Guid qestionId);
    }
}
