using EduCore.DataTypes;
using EduCore.EduOperation.Branch;
using EduCore.EduOperation.Course;
using EduCore.EduOperation.UserInOrganization;
using EduRepository.BranchRepository;
using EduRepository.CourseRepository;
using EduRepository.OrganizationRepository;
using EduRepository.OrganizationRoleRepository;
using Model.Functions.License;
using System;
using System.Linq;

namespace EduServices.LicenseService
{
    public class LicenseService : BaseService, ILicenseService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IOrganizationRoleRepository _organizationRoleRepository;
        public LicenseService(IOrganizationRepository organizationRepository, IBranchRepository branchRepository, ICourseRepository courseRepository, IOrganizationRoleRepository organizationRoleRepository)
        {
            _branchRepository = branchRepository;
            _organizationRepository = organizationRepository;
            _courseRepository = courseRepository;
            _organizationRoleRepository = organizationRoleRepository;

        }

        public bool ValidateLicence(Guid organizationId, BaseOperation operation)
        {
            GetLicenseByOrganization license = _organizationRepository.GetLicenseByOrganization(organizationId);
            if (license == null)
            {
                return false;
            }
            if (operation.OperationCode == new AddBranchOperation().OperationCode)
            {
                return license.MaximumBranch > 0 ?
                    _branchRepository.GetAllBranchInOrganization(organizationId).Where(x => x.IsOnline == false).ToList().Count + 1 <= license.MaximumBranch :
                     true;
            }
            if (operation.OperationCode == new AddCourseOperation().OperationCode)
            {
                return license.MaximumCourse > 0 ?
                    _courseRepository.GetAllCourseInOrganization(organizationId).Count + 1 <= license.MaximumCourse :
                    true;
            }
            if (operation.OperationCode == new AdUserToOrganizationOperation().OperationCode)
            {
                return license.MaximumUser > 0 ? _organizationRoleRepository.GetAllUserInOrganization(organizationId).Count + 1 <= license.MaximumUser : true;
            }
            return true;
        }
    }
}