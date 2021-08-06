using Model.Functions.BankOfQuestion;
using System.Collections.Generic;
using System.Linq;
using WebModel.BankOfQuestion;

namespace EduFacade.BankOfQuestionFacade.Convertor
{
    public class BankOfQuestionConvertor : IBankOfQuestionConvertor
    {
        public AddBankOfQuestion ConvertToBussinessEntity(AddBankOfQuestionDto addBankOfQuestionDto)
        {
            return new AddBankOfQuestion()
            {
                Description = addBankOfQuestionDto.Description,
                Name = addBankOfQuestionDto.Name,
                OrganizationId = addBankOfQuestionDto.OrganizationId,
                IsDefault = false
            };
        }

        public UpdateBankOfQuestion ConvertToBussinessEntity(UpdateBankOfQuestionDto updateBankOfQuestionDto)
        {
            return new UpdateBankOfQuestion()
            {
                BankOfQuestionId = updateBankOfQuestionDto.BankOfQuestionId,
                Description = updateBankOfQuestionDto.Description,
                Name = updateBankOfQuestionDto.Name
            };
        }

        public HashSet<GetBankOfQuestionInOrganizationDto> ConvertToWebModel(HashSet<GetBankOfQuestionInOrganization> getBankOfQuestionInOrganizations)
        {
            return getBankOfQuestionInOrganizations.Select(item => new GetBankOfQuestionInOrganizationDto()
            {
                Description = item.Description,
                Name = item.Name,
                Id = item.Id,
                IsDefault = item.IsDefault
            }).ToHashSet();
        }

        public GetBankOfQuestionDetailDto ConvertToWebModel(GetBankOfQuestionDetail getBankOfQuestionDetail)
        {
            return new GetBankOfQuestionDetailDto()
            {
                Description = getBankOfQuestionDetail.Description,
                Name = getBankOfQuestionDetail.Name,
                Id = getBankOfQuestionDetail.Id,
                IsDefault = getBankOfQuestionDetail.IsDefault
            };
        }
    }
}
