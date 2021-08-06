using Model.Functions.Branch;
using System.Collections.Generic;
using WebModel.Branch;

namespace EduFacade.BranchFacade.Convertor
{
    public interface IBranchConvertor
    {
        AddBranch ConvertToBussinessEntity(AddBranchDto addBranchDto);
        UpdateBranch ConvertToBussinessEntity(UpdateBranchDto updateBranchDto);
        HashSet<GetAllBranchInOrganizationDto> ConvertToWebModel(HashSet<GetAllBranchInOrganization> getAllBranchInOrganizations);
        GetBranchDetailDto ConvertToWebModel(GetBranchDetail getBranchDetail);
    }
}
