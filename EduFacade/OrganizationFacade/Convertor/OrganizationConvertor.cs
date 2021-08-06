using EduServices.CodeBookService;
using Model.Functions.Organization;
using Model.Functions.Shared;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Organization;
using WebModel.Shared;

namespace EduFacade.OrganizationFacade.Convertor
{
    public class OrganizationConvertor : IOrganizationConvertor
    {
        private readonly ICodeBookService _codeBookService;
        private readonly HashSet<AddressType> _addressTypes;
        public OrganizationConvertor(ICodeBookService codeBookService)
        {
            _codeBookService = codeBookService;
            _addressTypes = _codeBookService.GetCodeBookItems<AddressType>();
        }
        public AddOrganization ConvertToBussinessEntity(AddOrganizationDto addOrganizationDto, Guid userId)
        {
            HashSet<FAddress> addresses = addOrganizationDto.Addresses.Select(item => new FAddress()
            {
                AddressTypeId = item.AddressTypeId,
                City = item.City,
                CountryId = item.CountryId,
                HouseNumber = item.HouseNumber,
                Region = item.Region,
                Street = item.Street,
                ZipCode = item.ZipCode,
                AddressTypeIdentificator = _addressTypes.FirstOrDefault(x => x.Id == item.AddressTypeId)?.SystemIdentificator
            }).ToHashSet();
            return new AddOrganization()
            {
                CanSendCourseInquiry = addOrganizationDto.CanSendCourseInquiry,
                BasicInformationDescription = addOrganizationDto.Description,
                BasicInformationName = addOrganizationDto.Name,
                ContactInformationEmail = addOrganizationDto.ContactInformation.Email,
                ContactInformationPhoneNumber = addOrganizationDto.ContactInformation.PhoneNumber,
                ContactInformationWWW = addOrganizationDto.ContactInformation.WWW,
                OrganizationRoleIdentificator = OrganizationRoleValue.ORGANIZATION_OWNER,
                LicenseIdentificator = LicenseValues.FREE,
                UserId = userId,
                Addresses = addresses,
                DefaultCulture = addOrganizationDto.DefaultCulture
            };
        }

        public UpdateOrganization ConvertToBussinessEntity(UpdateOrganizationDto updateOrganizationDto)
        {
            HashSet<FAddress> addresses = updateOrganizationDto.Addresses.Select(item => new FAddress()
            {
                AddressTypeId = item.AddressTypeId,
                City = item.City,
                CountryId = item.CountryId,
                HouseNumber = item.HouseNumber,
                Region = item.Region,
                Street = item.Street,
                ZipCode = item.ZipCode,
                AddressTypeIdentificator = _addressTypes.FirstOrDefault(x => x.Id == item.AddressTypeId)?.SystemIdentificator
            }).ToHashSet();
            return new UpdateOrganization()
            {
                BasicInformationDescription = updateOrganizationDto.Description,
                BasicInformationName = updateOrganizationDto.Name,
                CanSendCourseInquiry = updateOrganizationDto.CanSendCourseInquiry,
                ContactInformationEmail = updateOrganizationDto.ContactInformation.Email,
                ContactInformationPhoneNumber = updateOrganizationDto.ContactInformation.PhoneNumber,
                ContactInformationWWW = updateOrganizationDto.ContactInformation.WWW,
                OrganizationId = updateOrganizationDto.Id,
                Addresses = addresses
            };
        }

        public SaveOrganizationSetting ConvertToBussinessEntity(SaveOrganizationSettingDto saveOrganizationSettingDto)
        {
            SaveOrganizationSetting result = new SaveOrganizationSetting
            {
                OrganizationId = saveOrganizationSettingDto.OrganizationId,
                UserDefaultPassword = saveOrganizationSettingDto.UserDefaultPassword,
                LicenseId = saveOrganizationSettingDto.LicenseId,
                DefaultCulture = saveOrganizationSettingDto.DefaultCulture,
                UrlElearning = saveOrganizationSettingDto.UrlElearning,
                Registration = saveOrganizationSettingDto.Registration,
                PasswordReset = saveOrganizationSettingDto.PasswordReset,
                GoogleLogin = saveOrganizationSettingDto.GoogleLogin,
                FacebookLogin = saveOrganizationSettingDto.FacebookLogin,
                LessonLength = saveOrganizationSettingDto.LessonLength,
                BackgroundColor = saveOrganizationSettingDto.BackgroundColor,
                TextColor = saveOrganizationSettingDto.TextColor,
                SmtpServerPassword = saveOrganizationSettingDto.SmtpServerPassword,
                SmtpServerPort = saveOrganizationSettingDto.SmtpServerPort,
                SmtpServerUrl = saveOrganizationSettingDto.SmtpServerUrl,
                SmtpServerUserName = saveOrganizationSettingDto.SmtpServerUserName,
                UseCustomSmtpServer = saveOrganizationSettingDto.UseCustomSmtpServer,
                GoogleApiToken = saveOrganizationSettingDto.GoogleApiToken

    };
            return result;
        }

        public AddStudyHours ConvertToBussinessEntity(AddStudyHoursDto addStudyHoursDto)
        {
            Guid activeFromId = Guid.Empty;
            Guid activeToId = Guid.Empty;
            if (!string.IsNullOrEmpty(addStudyHoursDto.ActiveFromId))
            {
                Guid.TryParse(addStudyHoursDto.ActiveFromId, out activeFromId);
            }
            if (!string.IsNullOrEmpty(addStudyHoursDto.ActiveToId))
            {
                Guid.TryParse(addStudyHoursDto.ActiveToId, out activeToId);
            }
            return new AddStudyHours()
            {
                ActiveFromId = activeFromId,
                ActiveToId = activeToId,
                OrganizationId = addStudyHoursDto.OrganizationId,
                Position = addStudyHoursDto.Position,
                LessonLength = addStudyHoursDto.LessonLength
            };
        }

        public UpdateStudyHours ConvertToBussinessEntity(UpdateStudyHoursDto updateStudyHoursDto)
        {
            Guid activeFromId = Guid.Empty;
            Guid activeToId = Guid.Empty;
            if (!string.IsNullOrEmpty(updateStudyHoursDto.ActiveFromId))
            {
                Guid.TryParse(updateStudyHoursDto.ActiveFromId, out activeFromId);
            }
            if (!string.IsNullOrEmpty(updateStudyHoursDto.ActiveToId))
            {
                Guid.TryParse(updateStudyHoursDto.ActiveToId, out activeToId);
            }
            return new UpdateStudyHours()
            {
                ActiveFromId = activeFromId,
                ActiveToId = activeToId,
                Id = updateStudyHoursDto.Id,
                Position = updateStudyHoursDto.Position
            };
        }

        public HashSet<GetMyOrganizationsDto> ConvertToWebModel(HashSet<GetMyOrganizations> getMyOrganizations)
        {
            HashSet<GetMyOrganizationsDto> data = new HashSet<GetMyOrganizationsDto>();
            foreach (GetMyOrganizations item in getMyOrganizations)
            {
                GetMyOrganizationsDto find = data.FirstOrDefault(x => x.Id == item.Id);
                if (find == null)
                {
                    data.Add(new GetMyOrganizationsDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        OrganizationRole = new List<OrganizationRoleDto>()
                        {
                            new OrganizationRoleDto()
                            {
                                IsOrganizationOwner = item.IsOrganizationOwner,
                                IsCourseAdministrator = item.IsCourseAdministrator,
                                IsCourseEditor = item.IsCourseEditor,
                                IsLector = item.IsLector,
                                IsOrganizationAdministrator = item.IsOrganizationAdministrator,
                                IsStudent = item.IsStudent,
                                UserInOrganizationRoleId = item.UserInOrganizationRoleId
                            }
                        }
                    });
                }
                else
                {
                    find.OrganizationRole.Add(new OrganizationRoleDto()
                    {
                        IsOrganizationOwner = item.IsOrganizationOwner,
                        IsCourseAdministrator = item.IsCourseAdministrator,
                        IsCourseEditor = item.IsCourseEditor,
                        IsLector = item.IsLector,
                        IsOrganizationAdministrator = item.IsOrganizationAdministrator,
                        IsStudent = item.IsStudent,
                        UserInOrganizationRoleId = item.UserInOrganizationRoleId
                    });
                }

            }
            return data;
        }

        public GetOrganizationDetailDto ConvertToWebModel(GetOrganizationDetail getOrganizationDetail, HashSet<GetOrganizationAddress> organizationAddresses)
        {
            HashSet<AddressDto> addresss = organizationAddresses.Select(item => new AddressDto()
            {
                AddressTypeId = item.AddressTypeId,
                City = item.City,
                CountryId = item.CountryId,
                HouseNumber = item.HouseNumber,
                Region = item.Region,
                Street = item.Street,
                ZipCode = item.ZipCode
            }).ToHashSet();
            return new GetOrganizationDetailDto()
            {
                Id = getOrganizationDetail.Id,
                Description = getOrganizationDetail.Description,
                Name = getOrganizationDetail.Name,
                ContactInformation = new WebModel.Shared.ContactInformationDto()
                {
                    Email = getOrganizationDetail.Email,
                    PhoneNumber = getOrganizationDetail.PhoneNumber,
                    WWW = getOrganizationDetail.WWW
                },
                CanSendCourseInquiry = getOrganizationDetail.CanSendCourseInquiry,
                LicenseId = getOrganizationDetail.LicenseId,
                Addresses = addresss
            };
        }

        public HashSet<GetOrganizationListDto> ConvertToWebModel(HashSet<GetAllOrganizations> getAllOrganizations)
        {
            return getAllOrganizations.Select(item => new GetOrganizationListDto()
            {
                Description = item.Description,
                Id = item.Id,
                Name = item.Name,
            }).ToHashSet();
        }

        public HashSet<FindOrganizationDto> ConvertToWebModel(HashSet<FindOrganization> findOrganizations)
        {
            return findOrganizations.Select(item => new FindOrganizationDto()
            {
                City = item.City,
                Country = item.Country,
                HouseNumber = item.HouseNumber,
                Id = item.Id,
                OrganizationDescription = item.OrganizationDescription,
                OrganizationName = item.OrganizationName,
                Region = item.Region,
                Street = item.Street
            }).ToHashSet();
        }

        public HashSet<GetAllUserInOrganizationDto> ConvertToWebModel(HashSet<GetAllUserInOrganization> getAllUserInOrganizations)
        {
            HashSet<GetAllUserInOrganizationDto> data = new HashSet<GetAllUserInOrganizationDto>();
            foreach (GetAllUserInOrganization item in getAllUserInOrganizations)
            {
                GetAllUserInOrganizationDto find = data.FirstOrDefault(x => x.Id == item.UserId);
                if (find == null)
                {
                    data.Add(new GetAllUserInOrganizationDto()
                    {
                        FirstName = item.FirstName,
                        Id = item.UserId,
                        LastName = item.LastName,
                        SecondName = item.SecondName,
                        UserRole = new List<string>() { item.UserRole },
                        UserEmail = item.UserEmail,
                        UioId = item.Id

                    });
                }
                else
                {
                    find.UserRole.Add(item.UserRole);

                }
            }
            return data;
        }

        public HashSet<GetOrganizationRolesDto> ConvertToWebModel(HashSet<OrganizationRole> organizationRoles)
        {
            return organizationRoles.Select(item => new GetOrganizationRolesDto()
            {
                RoleIndentificator = item.SystemIdentificator,
                RoleId = item.Id
            }).ToHashSet();
        }

        public GetOrganizationSettingDto ConvertToWebModel(GetOrganizationSetting getOrganizationSetting)
        {
            return new GetOrganizationSettingDto()
            {
                OrganizationId = getOrganizationSetting.OrganizationId,
                UserDefaultPassword = getOrganizationSetting.UserDefaultPassword,
                LicenseId = getOrganizationSetting.LicenseId,
                DefaultCulture = getOrganizationSetting.DefaultCulture,
                ElearningUrl = getOrganizationSetting.ElearningUrl,
                FacebookLogin = getOrganizationSetting.FacebookLogin,
                GoogleLogin = getOrganizationSetting.GoogleLogin,
                PasswordReset = getOrganizationSetting.PasswordReset,
                Registration = getOrganizationSetting.Registration,
                LessonLength = getOrganizationSetting.LessonLength,
                TextColor = getOrganizationSetting.TextColor,
                BackgroundColor = getOrganizationSetting.BackgroundColor,
                BackgroundImage = getOrganizationSetting.BackgroundImage,
                OriginalFileName = getOrganizationSetting.OriginalFileName,
                UseCustomSmtpServer = getOrganizationSetting.UseCustomSmtpServer,
                SmtpServerUserName = getOrganizationSetting.SmtpServerUserName,
                SmtpServerUrl = getOrganizationSetting.SmtpServerUrl,
                SmtpServerPort = getOrganizationSetting.SmtpServerPort,
                SmtpServerPassword = getOrganizationSetting.SmtpServerPassword, GoogleApiToken = getOrganizationSetting.GoogleApiToken
            };
        }

        public HashSet<GetOrganizationCultureDto> ConvertToWebModel(HashSet<GetOrganizationCulture> getOrganizationCultures)
        {
            return getOrganizationCultures.Select(x => new GetOrganizationCultureDto()
            {
                Id = x.Id,
                IsDefault = x.IsDefault,
                Name = x.Name
            }).ToHashSet();
        }

        public GetOrganizationSettingByUrlDto ConvertToWebModel(GetOrganizationSettingByUrl getOrganizationSettingByUrl)
        {
            if (getOrganizationSettingByUrl == null)
            {
                return null;
            }
            return new GetOrganizationSettingByUrlDto()
            {
                Description = "",
                Id = getOrganizationSettingByUrl.Id,
                Name = getOrganizationSettingByUrl.Name,
                Registration = getOrganizationSettingByUrl.Registration,
                PasswordReset = getOrganizationSettingByUrl.PasswordReset,
                GoogleLogin = getOrganizationSettingByUrl.GoogleLogin,
                FacebookLogin = getOrganizationSettingByUrl.FacebookLogin
            };
        }

        public HashSet<GetStudyHoursDto> ConvertToWebModel(HashSet<GetStudyHours> getStudyHours)
        {
            return getStudyHours.Select(x => new GetStudyHoursDto()
            {
                Position = x.Position,
                ActiveFrom = x.ActiveFrom,
                ActiveFromId = x.ActiveFromId,
                ActiveTo = x.ActiveTo,
                ActiveToId = x.ActiveToId,
                Id = x.Id,
                OrganizationId = x.OrganizationId
            }).ToHashSet();
        }

        public GetOrganizationDetailWebDto ConvertToWebModelWeb(GetOrganizationDetail getOrganizationDetail)
        {
            return new GetOrganizationDetailWebDto()
            {
                Id = getOrganizationDetail.Id,
                Description = getOrganizationDetail.Description,
                Name = getOrganizationDetail.Name,
                ContactInformation = new ContactInformationDto()
                {
                    Email = getOrganizationDetail.Email,
                    PhoneNumber = getOrganizationDetail.PhoneNumber,
                    WWW = getOrganizationDetail.WWW
                }
            };
        }
    }
}
