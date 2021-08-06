using System;
using WebModel.Shared;

namespace WebModel.Branch
{
    public class GetAllBranchInOrganizationDto : BaseDto, IBasicInformationDto
    {
        public Guid Id { get; set; }
        public bool IsMainBranch { get; set; }
        public AddressDto Address { get; set; }
        public ContactInformationDto ContactInformation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOnline { get; set; }
    }
}
