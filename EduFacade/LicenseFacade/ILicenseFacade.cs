using EduCore.DataTypes;
using System;

namespace EduFacade.LicenseFacade
{
    public interface ILicenseFacade : IBaseFacade
    {
        bool ValidateLicence(Guid organizationId, BaseOperation operation);
    }
}
