using Model.Functions.BankOfQuestion;
using System.Collections.Generic;
using WebModel.BankOfQuestion;

namespace EduFacade.BankOfQuestionFacade.Convertor
{
    public interface IBankOfQuestionConvertor
    {
        AddBankOfQuestion ConvertToBussinessEntity(AddBankOfQuestionDto addBankOfQuestionDto);
        HashSet<GetBankOfQuestionInOrganizationDto> ConvertToWebModel(HashSet<GetBankOfQuestionInOrganization> getBankOfQuestionInOrganizations);
        GetBankOfQuestionDetailDto ConvertToWebModel(GetBankOfQuestionDetail getBankOfQuestionDetail);
        UpdateBankOfQuestion ConvertToBussinessEntity(UpdateBankOfQuestionDto updateBankOfQuestionDto);
    }
}
