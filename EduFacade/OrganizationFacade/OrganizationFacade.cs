using Core.DataTypes;
using Core.Extension;
using EduFacade.OrganizationFacade.Convertor;
using EduServices.BranchService;
using EduServices.ClassRoomService;
using EduServices.CodeBookService;
using EduServices.CourseService;
using EduServices.NotificationService;
using EduServices.OrganizationRoleService;
using EduServices.OrganizationService;
using EduServices.RoleService;
using EduServices.SendMailService;
using EduServices.UserService;
using Microsoft.Extensions.Configuration;
using Model.Functions.Organization;
using Model.Functions.User;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Organization;
namespace EduFacade.OrganizationFacade
{
    public class OrganizationFacade : BaseFacade, IOrganizationFacade
    {
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly IOrganizationConvertor _organizationConvertor;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;
        private readonly HashSet<NotificationType> _notificationTypes;
        private readonly IRoleService _roleService;
        private readonly IConfiguration _configuration;
        private readonly ISendMailService _sendMailService;
        private readonly IBranchService _branchService;
        private readonly IClassRoomService _classRoomService;
        private readonly HashSet<Country> _cbCountries;
        private readonly IBankOfQuestionService _bankOfQuestionService;

        public OrganizationFacade(ISendMailService sendMailService, IConfiguration configuration, IRoleService roleService, ICodeBookService codeBookService, INotificationService notificationService, IUserService userService, IOrganizationService organizationService, IOrganizationRoleService organizationRoleService, IOrganizationConvertor organizationConvertor, IBranchService branchService, IClassRoomService classRoomService, IBankOfQuestionService bankOfQuestionService)
        {
            _organizationService = organizationService;
            _organizationRoleService = organizationRoleService;
            _organizationConvertor = organizationConvertor;
            _userService = userService;
            _notificationService = notificationService;
            _notificationTypes = codeBookService.GetCodeBookItems<NotificationType>();
            _roleService = roleService;
            _configuration = configuration;
            _sendMailService = sendMailService;
            _branchService = branchService;
            _classRoomService = classRoomService;
            _cbCountries = codeBookService.GetCodeBookItems<Country>();
            _bankOfQuestionService = bankOfQuestionService;
        }

        public Result AddOrganization(Guid userId, AddOrganizationDto addOrganizationDto)
        {
            Result validate = Validate(addOrganizationDto);
            if (validate.IsOk)
            {
                AddOrganization addOrganization = _organizationConvertor.ConvertToBussinessEntity(addOrganizationDto, userId);
                Guid orgId = _organizationService.AddOrganization(addOrganization);
                Guid branchId = _branchService.AddBranch(new Model.Functions.Branch.AddBranch()
                {
                    AddressCity = "",
                    AddressCountryId = _cbCountries.FirstOrDefault(x => x.IsDefault).Id,
                    AddressHouseNumber = "",
                    AddressRegion = "",
                    AddressStreet = "",
                    AddressZipCode = "",
                    BasicInformationDescription = "",
                    BasicInformationName = "ONLINE_BRANCH",
                    ContactInformationEmail = "",
                    ContactInformationPhoneNumber = "",
                    ContactInformationWWW = "",
                    IsMainBranch = false,
                    IsOnline = true,
                    OrganizationId = orgId

                });
                _classRoomService.AddClassRoom(new Model.Functions.ClassRoom.AddClassRoom()
                {
                    BasicInformationDescription = "",
                    BasicInformationName = "ONLINE_CLASSROOM",
                    BranchId = branchId,
                    Floor = 0,
                    IsOnline = true,
                    MaxCapacity = 0
                });
                _bankOfQuestionService.AddBankOfQuestion(new Model.Functions.BankOfQuestion.AddBankOfQuestion()
                {
                    Description = "",
                    IsDefault = true,
                    OrganizationId = orgId,
                    Name = "DEFAULT_BANK_OF_QUESTION"
                });
                return new Result<Guid>()
                {
                    Data = orgId
                };
            }
            return validate;
        }

        public void AddStudyHour(AddStudyHoursDto addStudyHoursDto)
        {
            AddStudyHours addStudyHours = _organizationConvertor.ConvertToBussinessEntity(addStudyHoursDto);
            _organizationService.AddStudyHour(addStudyHours);
        }

        public Result AddUserToOrganization(AddUserToOrganizationDto addUserToOrganizationDto)
        {
            Result result = new Result();
            foreach (string email in addUserToOrganizationDto.UserEmails.Distinct())
            {
                if (email.IsValidEmail())
                {
                    GetUserDetail user = _userService.GetUserDetail(email);
                    if (user == null)
                    {
                        string defaultPassword = _organizationService.GetOrganizationSetting(addUserToOrganizationDto.OrganizationId).UserDefaultPassword;
                        _userService.AddUserByEmail(email, _roleService.GetUserRole(UserRoleValues.REGISTERED_USER), defaultPassword);
                        user = _userService.GetUserDetail(email);
                        Dictionary<string, string> replaceData = new Dictionary<string, string>
                            {
                                { "activationLink", string.Format("{0}/?id={1}", _configuration.GetSection("ClientUrlActivate").Value, user.Id) }
                            };
                        _sendMailService.SendMail(EduEmailValue.REGISTRATION_USER, addUserToOrganizationDto.ClientCulture, new EmailAddress()
                        {
                            Email = email,
                            Name = ""
                        }, replaceData, Guid.Empty, "");

                    }
                    foreach (Guid role in addUserToOrganizationDto.OrganizationRoleId)
                    {
                        _organizationRoleService.AddUserToOrganization(new AddUserToOrganization()
                        {
                            OrganizationId = addUserToOrganizationDto.OrganizationId,
                            OrganizationRoleId = role,
                            UserId = user.Id
                        });
                    }
                    _notificationService.AddNotification(new Model.Functions.Notification.AddNotification()
                    {
                        IsNew = true,
                        NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationTypeValues.INVITE_TO_ORGANIZATION).Id,
                        ObjectId = addUserToOrganizationDto.OrganizationId,
                        UserId = user.Id
                    });

                }
                else
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ADD_USER_TO_ORGANIZATION", "EMAIL_IS_NOT_VALID", email, 0));
                }
            }
            return result;
        }

        public void DeleteOrganization(Guid organizationId)
        {
            _organizationService.DeleteOrganization(organizationId);
        }
        public void DeleteStudyHour(Guid studyHourId)
        {
            _organizationService.DeleteStudyHour(studyHourId);
        }

        public void DeleteUserFromOrganization(Guid userId, Guid organizationId)
        {
            HashSet<GetUserOrganizationRole> getUserOrganizationRoles = _organizationRoleService.GetUserOrganizationRole(userId, organizationId).Where(x => !x.IsOrganizationOwner()).ToHashSet();
            foreach (GetUserOrganizationRole item in getUserOrganizationRoles)
            {
                _organizationRoleService.DeleteUserFromOrganization(item.UioId);
            }
        }

        public HashSet<FindOrganizationDto> FindOrganization(string findText)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationRoleService.FindOrganization(findText));
        }

        public HashSet<GetAllUserInOrganizationDto> GetAllUserInOrganization(Guid organizationId)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationRoleService.GetAllUserInOrganization(organizationId));
        }


        public HashSet<GetMyOrganizationsDto> GetMyOrganizations(Guid userId)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetMyOrganizations(userId));
        }

        public HashSet<GetOrganizationCultureDto> GetOrganizationCulture(Guid organizationId)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetOrganizationCulture(organizationId));
        }

        public GetOrganizationDetailDto GetOrganizationDetail(Guid organizationId)
        {
            GetOrganizationDetail getOrganizationDetail = _organizationService.GetOrganizationDetail(organizationId);
            HashSet<GetOrganizationAddress> organizationAddresses = _organizationService.GetOrganizationAddress(organizationId);
            return _organizationConvertor.ConvertToWebModel(getOrganizationDetail, organizationAddresses);
        }

        public GetOrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId)
        {
            return _organizationConvertor.ConvertToWebModelWeb(_organizationService.GetOrganizationDetail(organizationId));
        }

        public HashSet<GetOrganizationListDto> GetOrganizationList()
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetOrganizationList());
        }

        public HashSet<GetOrganizationRolesDto> GetOrganizationRoles()
        {
            HashSet<OrganizationRole> organizationRoles = _organizationRoleService.GetOrganizationRoles();
            return _organizationConvertor.ConvertToWebModel(organizationRoles);

        }

        public GetOrganizationSettingDto GetOrganizationSetting(Guid organizationId)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetOrganizationSetting(organizationId));
        }

        public GetOrganizationSettingByUrlDto GetOrganizationSettingByUrl(string url)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetOrganizationSettingByUrl(url));
        }

        public HashSet<GetStudyHoursDto> GetStudyHours(Guid organizationId)
        {
            return _organizationConvertor.ConvertToWebModel(_organizationService.GetStudyHours(organizationId));
        }

        public GetUserOrganizationRoleDetailDto GetUserOrganizationRoleDetail(Guid userId, Guid organizationId)
        {
            HashSet<GetUserOrganizationRole> getUserOrganizationRoles = _organizationRoleService.GetUserOrganizationRole(userId, organizationId);
            if (getUserOrganizationRoles.Where(x => x.IsOrganizationOwner()).ToHashSet().Count > 0)
            {
                return null;
            }
            return new GetUserOrganizationRoleDetailDto()
            {
                Id = getUserOrganizationRoles.Select(x => x.Id).ToHashSet()
            };

        }

        public Result SaveOrganizationSetting(SaveOrganizationSettingDto saveOrganizationSettingDto)
        {
            Result validate = new Result();
            _organizationService.ValidateDefaultCulture(saveOrganizationSettingDto.DefaultCulture, validate);
            _organizationService.ValidateOrganizationUrl(saveOrganizationSettingDto.UrlElearning, saveOrganizationSettingDto.OrganizationId, validate);
            _organizationService.ValidateLessonLength(saveOrganizationSettingDto.LessonLength, validate);
            if (saveOrganizationSettingDto.UseCustomSmtpServer)
            {
                _organizationService.ValidateSmtp(saveOrganizationSettingDto.SmtpServerUrl, saveOrganizationSettingDto.SmtpServerUserName, saveOrganizationSettingDto.SmtpServerPassword, saveOrganizationSettingDto.SmtpServerPort, validate);
            }
            if (validate.IsOk)
            {
                SaveOrganizationSetting saveOrganizationSetting = _organizationConvertor.ConvertToBussinessEntity(saveOrganizationSettingDto);
                _organizationService.SaveOrganizationSetting(saveOrganizationSetting);
            }
            return validate;
        }

        public Result UpdateOrganization(UpdateOrganizationDto updateOrganizationDto)
        {
            Result result = Validate(updateOrganizationDto);
            if (result.IsOk)
            {
                UpdateOrganization updateOrganization = _organizationConvertor.ConvertToBussinessEntity(updateOrganizationDto);
                _organizationService.UpdateOrganization(updateOrganization);
            }
            return result;
        }

        public void UpdateStudyHour(UpdateStudyHoursDto updateStudyHoursDto)
        {
            UpdateStudyHours updateStudyHours = _organizationConvertor.ConvertToBussinessEntity(updateStudyHoursDto);
            _organizationService.UpdateStudyHour(updateStudyHours);
        }

        public void UpdateUserInOrganizationRole(UpdateUserInOrganizationRoleDto updateUserInOrganizationRoleDto)
        {
            HashSet<GetUserOrganizationRole> getUserOrganizationRoles = _organizationRoleService.GetUserOrganizationRole(updateUserInOrganizationRoleDto.UserId, updateUserInOrganizationRoleDto.OrganizationId);
            if (getUserOrganizationRoles.Where(x => x.IsOrganizationOwner()).ToList().Count > 0)
            {
                return;
            }
            foreach (GetUserOrganizationRole item in getUserOrganizationRoles)
            {
                if (!updateUserInOrganizationRoleDto.OrganizationRoleId.Contains(item.Id))
                {
                    _organizationRoleService.DeleteUserFromOrganization(item.UioId);
                }
            }
            foreach (Guid role in updateUserInOrganizationRoleDto.OrganizationRoleId)
            {
                if (getUserOrganizationRoles.FirstOrDefault(x => x.Id == role) == null)
                {
                    _organizationRoleService.AddUserToOrganization(new AddUserToOrganization()
                    {
                        OrganizationId = updateUserInOrganizationRoleDto.OrganizationId,
                        OrganizationRoleId = role,
                        UserId = updateUserInOrganizationRoleDto.UserId
                    });
                }
            }
        }

        private Result Validate(AddOrganizationDto addOrganizationDto)
        {
            Result validate = new Result();
            _organizationService.ValidateOrganizationName(addOrganizationDto.Name, validate);
            _organizationService.ValidateUri(addOrganizationDto.ContactInformation.WWW, validate);
            _organizationService.ValidateEmail(addOrganizationDto.ContactInformation.Email, validate);
            _organizationService.ValidatePhoneNumber(addOrganizationDto.ContactInformation.PhoneNumber, validate);
            _organizationService.ValidateDefaultCulture(addOrganizationDto.DefaultCulture, validate);
            return validate;
        }
        private Result Validate(UpdateOrganizationDto updateOrganizationDto)
        {
            Result validate = new Result();
            _organizationService.ValidateOrganizationName(updateOrganizationDto.Name, validate);
            _organizationService.ValidateUri(updateOrganizationDto.ContactInformation.WWW, validate);
            _organizationService.ValidateEmail(updateOrganizationDto.ContactInformation.Email, validate);
            _organizationService.ValidatePhoneNumber(updateOrganizationDto.ContactInformation.PhoneNumber, validate);
            return validate;
        }
    }
}
