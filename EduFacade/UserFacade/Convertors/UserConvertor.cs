﻿using Core.Extension;
using EduServices.CodeBookService;
using Model.Functions.Shared;
using Model.Functions.User;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using Model.Tables.Shared;
using System.Collections.Generic;
using System.Linq;
using WebModel.Shared;
using WebModel.User;

namespace EduFacade.UserFacade.Convertors
{
    public class UserConvertor : IUserConvertor
    {
        private readonly HashSet<AddressType> _addressTypes;
        private readonly HashSet<Country> _countries;
        private readonly ICodeBookService _codeBookService;

        public UserConvertor(ICodeBookService codeBookService)
        {
            _codeBookService = codeBookService;
            _addressTypes = _codeBookService.GetCodeBookItems<AddressType>();
            _countries = _codeBookService.GetCodeBookItems<Country>();
        }

        public User ConvertToBussinessEntity(AddUserDto webModel)
        {
            HashSet<Address> address = webModel.Person.Address.Select(item => new Address()
            {
                AddressType = _addressTypes.FirstOrDefault(x => x.Id == item.AddressTypeId),
                City = item.City,
                Country = _countries.FirstOrDefault(x => x.Id == item.CountryId),
                HouseNumber = item.HouseNumber,
                Region = item.Region,
                Street = item.Street,
                ZipCode = item.ZipCode
            }).ToHashSet();
            return new User()
            {
                UserEmail = webModel.UserEmail,
                UserPassword = webModel.UserPassword,
                Person = new Person()
                {
                    FirstName = webModel.Person.FirstName,
                    LastName = webModel.Person.LastName,
                    SecondName = webModel.Person.SecondName,
                    PersonAddress = address,
                    AvatarUrl = webModel.Person.AvatarUrl
                }
            };
        }

        public UpdateUser ConvertToBussinessEntity(UpdateUserDto userUpdateDto)
        {
            HashSet<FAddress> addresses = userUpdateDto.Person.Address.Select(item => new FAddress()
            {
                AddressTypeId = item.AddressTypeId,
                AddressTypeIdentificator = _addressTypes.FirstOrDefault(x => x.Id == item.AddressTypeId)?.SystemIdentificator,
                City = item.City,
                CountryId = item.CountryId,
                HouseNumber = item.HouseNumber,
                Region = item.Region,
                Street = item.Street,
                ZipCode = item.ZipCode
            }).ToHashSet();

            return new UpdateUser()
            {
                Id = userUpdateDto.Id,
                FirstName = userUpdateDto.Person.FirstName,
                LastName = userUpdateDto.Person.LastName,
                SecondName = userUpdateDto.Person.SecondName,
                UserId = userUpdateDto.Id,
                Addresses = addresses
            };
        }

        public LoginUserDto ConvertToWebModel(LoginUser loginUser)
        {
            return new LoginUserDto()
            {
                Id = loginUser.Id,
                Token = loginUser.UserToken,
                IsAvatarUrl = loginUser.AvatarUrl?.IsValidUri(),
                Avatar = loginUser.AvatarUrl == null ? string.Format("{0}{1}", loginUser.FirstName.FirstOrDefault(), loginUser.LastName.FirstOrDefault()) : (loginUser.AvatarUrl.IsValidUri() ? loginUser.AvatarUrl : string.Format("{0}{1}", loginUser.FirstName.FirstOrDefault(), loginUser.LastName.FirstOrDefault())),
                FullName = string.Format("{0} {1}", loginUser.FirstName, loginUser.LastName)
            };
        }

        public GetUserDetailDto ConvertToWebModel(GetUserDetail getUserDetail, HashSet<GetUserAddress> getUserAddress)
        {
            HashSet<AddressDto> address = getUserAddress.Select(item => new AddressDto()
            {
                AddressTypeId = item.AddressTypeId,
                City = item.City,
                CountryId = item.CountryId,
                HouseNumber = item.HouseNumber,
                Region = item.Region,
                Street = item.Street,
                ZipCode = item.ZipCode

            }).ToHashSet();
            return new GetUserDetailDto()
            {
                Id = getUserDetail.Id,
                Person = new PersonDto()
                {
                    FirstName = getUserDetail.FirstName,
                    Address = address,
                    LastName = getUserDetail.LastName,
                    SecondName = getUserDetail.SecondName
                },
                UserEmail = getUserDetail.UserEmail

            };
        }


    }
}
