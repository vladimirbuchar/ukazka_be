using Core.DataTypes;
using EduCore.DataTypes;
using EduCore.EduOperation.BankOfQuestion;
using EduCore.EduOperation.Certificate;
using EduFacade.AuthFacade;
using EduFacade.CertificateFacade;
using EduFacade.LicenseFacade;
using EduFacade.OraganizationRoleFacade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebModel.Certificate;
using WebModel.Shared;

namespace EduApi.Controllers.WebPortal.Certificate
{

    public class CertificateController : BaseWebPortalController
    {
        private readonly ICertificateFacade _certificateFacade;
        public CertificateController(ICertificateFacade certificateFacade, ILogger<CertificateController> logger, IAuthFacade accessTokenFacade, IOrganizationRoleFacade organizationRoleFacade, ILicenseFacade licenseFacade) : base(logger, accessTokenFacade, organizationRoleFacade, licenseFacade)
        {
            _certificateFacade = certificateFacade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult AddCertificate(AddCertificateDto addCertificateDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = addCertificateDto.UserAccessToken,
                    OrganizationId = addCertificateDto.OrganizationId,
                    OperationType = new OperationType(new AddCertificateOperation()),
                    Request = addCertificateDto,
                    TestRequest = true,
                    ValidateAccessToken = true,
                    ValidateLicense = true
                });
                return SendResponse(_certificateFacade.AddCertificate(addCertificateDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCertificateInOrganizationDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCertificateInOrganization([FromQuery] string accessToken, [FromQuery] Guid organizationId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new GetCertificateInOrganizationOperation()),
                    OrganizationId = organizationId,
                    ValidateAccessToken = true
                });
                return SendResponse(_certificateFacade.GetCertificateInOrganization(organizationId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult UpdateCertificate(UpdateCertificateDto updateCertificateDto)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = updateCertificateDto.UserAccessToken,
                    OperationType = new OperationType(new UpdateCertificateOperation()),
                    OrganizationId = GetOrganizationByCertificate(updateCertificateDto.Id),
                    Request = updateCertificateDto,
                    TestRequest = true,
                    ValidateAccessToken = true
                });
                return SendResponse(_certificateFacade.UpdateCertificate(updateCertificateDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult DeleteCertificate(string accessToken, Guid certificateId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DeleteCertificateOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByCertificate(certificateId)
                });
                _certificateFacade.DeleteCertificate(certificateId);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetMyCertificateDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyCertificate([FromQuery] string accessToken)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    ValidateAccessToken = true
                });
                return SendResponse(_certificateFacade.GetMyCertificate(GetUserByAccessToken(accessToken).Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        //
        [HttpGet]
        [ProducesResponseType(typeof(GetCertificateDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCertificateDetail([FromQuery] string accessToken, Guid certificateId)
        {
            try
            {
                Test(new TestRequestSettings()
                {
                    AccessToken = accessToken,
                    OperationType = new OperationType(new DetailCertificateOperation()),
                    ValidateAccessToken = true,
                    OrganizationId = GetOrganizationByCertificate(certificateId)
                });
                return SendResponse(_certificateFacade.GetCertificateDetail(certificateId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
