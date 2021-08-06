using Model.Functions.Branch;
using System;
using System.Collections.Generic;

namespace EduRepository.BranchRepository
{
    public interface IBranchRepository : IBaseRepository
    {
        HashSet<GetAllBranchInOrganization> GetAllBranchInOrganization(Guid organizationId);
        GetBranchDetail GetBranchDetail(Guid branchId);
        Guid AddBranch(AddBranch addBranch);
        void UpdateBranch(UpdateBranch updateBranch);
    }
}
