using Core.DataTypes;
using System;
using System.Collections.Generic;
using WebModel.Branch;

namespace EduFacade.BranchFacade
{
    public interface IBranchFacade : IBaseFacade
    {
        Result AddBranch(AddBranchDto addBranchDto);
        HashSet<GetAllBranchInOrganizationDto> GetAllBranchInOrganization(Guid organizationId);
        void DeleteBranch(Guid branchId);
        GetBranchDetailDto GetBranchDetail(Guid branchId);
        Result UpdateBranch(UpdateBranchDto updateBranchDto);
    }
}
