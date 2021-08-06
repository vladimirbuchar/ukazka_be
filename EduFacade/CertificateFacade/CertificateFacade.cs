using Core.DataTypes;
using EduFacade.BankOfQuestionFacade.Convertor;
using EduServices.CertificateService;
using System;
using System.Collections.Generic;
using WebModel.Certificate;

namespace EduFacade.CertificateFacade
{
    public class CertificateFacade : BaseFacade, ICertificateFacade
    {
        private readonly ICertificateService _certificateService;
        private readonly ICertificateConvertor _certificateConvertor;
        public CertificateFacade(ICertificateService certificateService, ICertificateConvertor certificateConvertor)
        {
            _certificateService = certificateService;
            _certificateConvertor = certificateConvertor;
        }

        public Result AddCertificate(AddCertificateDto addCertificateDto)
        {
            Result validate = Validate(addCertificateDto);
            if (validate.IsOk)
            {
                _certificateService.AddCertificate(_certificateConvertor.ConvertToBussinessEntity(addCertificateDto));
            }
            return validate;
        }

        public Result DeleteCertificate(Guid certificateId)
        {
            _certificateService.DeleteCertificate(certificateId);
            return new Result();
        }

        public GetCertificateDetailDto GetCertificateDetail(Guid certificateId)
        {
            return _certificateConvertor.ConvertToWebModel(_certificateService.GetCertificateDetail(certificateId));
        }

        public HashSet<GetCertificateInOrganizationDto> GetCertificateInOrganization(Guid organizationId)
        {
            return _certificateConvertor.ConvertToWebModel(_certificateService.GetCertificateInOrganization(organizationId));
        }

        public HashSet<GetMyCertificateDto> GetMyCertificate(Guid userId)
        {
            return _certificateConvertor.ConvertToWebModel(_certificateService.GetMyCertificate(userId));
        }

        public Result UpdateCertificate(UpdateCertificateDto updateBankOfQuestionDto)
        {
            Result validate = Validate(updateBankOfQuestionDto);
            if (validate.IsOk)
            {
                _certificateService.UpdateCertificate(_certificateConvertor.ConvertToBussinessEntity(updateBankOfQuestionDto));
            }
            return validate;
        }

        private Result Validate(AddCertificateDto addCertificateDto)
        {
            Result validate = new Result();
            _certificateService.ValidateName(addCertificateDto.Name, validate);
            return validate;
        }

        private Result Validate(UpdateCertificateDto updateCertificateDto)
        {
            Result validate = new Result();
            _certificateService.ValidateName(updateCertificateDto.Name, validate);
            return validate;
        }


    }
}
