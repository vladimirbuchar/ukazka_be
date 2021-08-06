using Core.DataTypes;
using EduFacade.BankOfQuestionFacade.Convertor;
using EduServices.CourseService;
using Model.Functions.BankOfQuestion;
using System;
using System.Collections.Generic;
using WebModel.BankOfQuestion;

namespace EduFacade.BankOfQuestionFacade
{
    public class BankOfQuestionFacade : BaseFacade, IBankOfQuestionFacade
    {
        private readonly IBankOfQuestionService _bankOfQuestionService;
        private readonly IBankOfQuestionConvertor _bankOfQuestionConvertor;
        public BankOfQuestionFacade(IBankOfQuestionService bankOfQuestionService, IBankOfQuestionConvertor bankOfQuestionConvertor)
        {
            _bankOfQuestionService = bankOfQuestionService;
            _bankOfQuestionConvertor = bankOfQuestionConvertor;
        }

        public Result AddBankOfQuestion(AddBankOfQuestionDto addBankOfQuestionDto)
        {
            Result result = Validate(addBankOfQuestionDto);
            if (result.IsOk)
            {
                AddBankOfQuestion addBankOfQuestion = _bankOfQuestionConvertor.ConvertToBussinessEntity(addBankOfQuestionDto);
                return new Result<Guid>()
                {
                    Data = _bankOfQuestionService.AddBankOfQuestion(addBankOfQuestion)
                }
                ;
            }
            return result;
        }
        private Result Validate(AddBankOfQuestionDto addBankOfQuestionDto)
        {
            Result result = new Result();
            _bankOfQuestionService.ValidateName(addBankOfQuestionDto.Name, result);
            return result;
        }
        private Result Validate(UpdateBankOfQuestionDto updateBankOfQuestionDto)
        {
            Result result = new Result();
            _bankOfQuestionService.ValidateName(updateBankOfQuestionDto.Name, result);
            return result;
        }

        public HashSet<GetBankOfQuestionInOrganizationDto> GetBankOfQuestionInOrganization(Guid organizationId)
        {
            return _bankOfQuestionConvertor.ConvertToWebModel(_bankOfQuestionService.GetBankOfQuestionInOrganization(organizationId));
        }

        public GetBankOfQuestionDetailDto GetBankOfQuestionDetail(Guid bankOfQuestionId)
        {
            return _bankOfQuestionConvertor.ConvertToWebModel(_bankOfQuestionService.GetBankOfQuestionDetail(bankOfQuestionId));
        }

        public Result UpdateBankOfQuestion(UpdateBankOfQuestionDto updateBankOfQuestionDto)
        {
            Result result = Validate(updateBankOfQuestionDto);
            if (result.IsOk)
            {
                UpdateBankOfQuestion updateBankOfQuestion = _bankOfQuestionConvertor.ConvertToBussinessEntity(updateBankOfQuestionDto);
                _bankOfQuestionService.UpdateBankOfQuestion(updateBankOfQuestion);
            }
            return result;
        }

        public void DeleteBankOfQuestion(Guid bankOfQuestionId, Guid organizationId)
        {
            _bankOfQuestionService.DeleteBankOfQuestion(bankOfQuestionId, organizationId);
        }
    }
}
