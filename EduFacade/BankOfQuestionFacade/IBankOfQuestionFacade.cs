using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.BankOfQuestion;

namespace EduFacade.BankOfQuestionFacade
{
    public interface IBankOfQuestionFacade : IBaseFacade
    {
        Result AddBankOfQuestion(AddBankOfQuestionDto addBankOfQuestionDto);
        HashSet<GetBankOfQuestionInOrganizationDto> GetBankOfQuestionInOrganization(Guid organizationId);
        GetBankOfQuestionDetailDto GetBankOfQuestionDetail(Guid bankOfQuestionId);
        Result UpdateBankOfQuestion(UpdateBankOfQuestionDto updateBankOfQuestionDto);
        void DeleteBankOfQuestion(Guid bankOfQuestionId, Guid organizationId);
    }
}
