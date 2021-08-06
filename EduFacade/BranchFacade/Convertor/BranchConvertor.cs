﻿using Model.Functions.Branch;
using System.Collections.Generic;
using System.Linq;
using WebModel.Branch;
namespace EduFacade.BranchFacade.Convertor
{
    public class BranchConvertor : IBranchConvertor
    {
        public AddBranch ConvertToBussinessEntity(AddBranchDto addBranchDto)
        {
            return new AddBranch()
            {
                AddressCity = addBranchDto.Address.City,
                ContactInformationEmail = addBranchDto.ContactInformation.Email,
                OrganizationId = addBranchDto.OrganizationId,
                IsMainBranch = addBranchDto.IsMainBranch,
                AddressCountryId = addBranchDto.Address.CountryId,
                AddressHouseNumber = addBranchDto.Address.HouseNumber,
                AddressRegion = addBranchDto.Address.Region,
                AddressStreet = addBranchDto.Address.Street,
                AddressZipCode = addBranchDto.Address.ZipCode,
                BasicInformationDescription = addBranchDto.Description,
                BasicInformationName = string.IsNullOrEmpty(addBranchDto.Name) ? addBranchDto.Address.FullAddress : addBranchDto.Name,
                ContactInformationPhoneNumber = addBranchDto.ContactInformation.PhoneNumber,
                ContactInformationWWW = addBranchDto.ContactInformation.WWW
            };
        }

        public UpdateBranch ConvertToBussinessEntity(UpdateBranchDto updateBranchDto)
        {
            return new UpdateBranch()
            {
                AddressCity = updateBranchDto.Address.City,
                AddressCountryId = updateBranchDto.Address.CountryId,
                AddressHouseNumber = updateBranchDto.Address.HouseNumber,
                AddressRegion = updateBranchDto.Address.Region,
                AddressStreet = updateBranchDto.Address.Street,
                AddressZipCode = updateBranchDto.Address.ZipCode,
                BasicInformationDescription = updateBranchDto.Description,
                BasicInformationName = string.IsNullOrEmpty(updateBranchDto.Name) ? updateBranchDto.Address.FullAddress : updateBranchDto.Name,
                ContactInformationEmail = updateBranchDto.ContactInformation.Email,
                ContactInformationPhoneNumber = updateBranchDto.ContactInformation.PhoneNumber,
                ContactInformationWWW = updateBranchDto.ContactInformation.WWW,
                Id = updateBranchDto.Id,
                IsMainBranch = updateBranchDto.IsMainBranch,
            };
        }

        public HashSet<GetAllBranchInOrganizationDto> ConvertToWebModel(HashSet<GetAllBranchInOrganization> getAllBranchInOrganizations)
        {
            return getAllBranchInOrganizations.Select(item => new GetAllBranchInOrganizationDto()
            {
                Address = new WebModel.Shared.AddressDto()
                {
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    CountryName = item.CountryName
                },
                Description = item.Description,
                Name = item.Name,
                ContactInformation = new WebModel.Shared.ContactInformationDto()
                {
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    WWW = item.WWW
                },
                Id = item.Id,
                IsMainBranch = item.IsMainBranch,
                IsOnline = item.IsOnline
            }).ToHashSet();
        }

        public GetBranchDetailDto ConvertToWebModel(GetBranchDetail getBranchDetail)
        {
            return new GetBranchDetailDto()
            {
                Address = new WebModel.Shared.AddressDto()
                {
                    City = getBranchDetail.City,
                    CountryId = getBranchDetail.CountryId,
                    HouseNumber = getBranchDetail.HouseNumber,
                    Region = getBranchDetail.Region,
                    Street = getBranchDetail.Street,
                    ZipCode = getBranchDetail.ZipCode
                },
                Description = getBranchDetail.Description,
                Name = getBranchDetail.Name,
                ContactInformation = new WebModel.Shared.ContactInformationDto()
                {
                    Email = getBranchDetail.Email,
                    PhoneNumber = getBranchDetail.PhoneNumber,
                    WWW = getBranchDetail.WWW
                },
                Id = getBranchDetail.Id,
                IsMainBranch = getBranchDetail.IsMainBranch
            };
        }
    }
}
