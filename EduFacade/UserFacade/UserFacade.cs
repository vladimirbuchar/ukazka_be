using Core.DataTypes;
using Core.Exceptions;
using EduCore.EduOperation.UserInOrganization;
using EduFacade.OrganizationFacade.Convertor;
using EduFacade.UserFacade.Convertors;
using EduServices.BranchService;
using EduServices.ClassRoomService;
using EduServices.CodeBookService;
using EduServices.CourseLectorService;
using EduServices.CourseService;
using EduServices.CourseStudentService;
using EduServices.CourseTermService;
using EduServices.LicenseService;
using EduServices.LinkLifeTimeService;
using EduServices.OrganizationRoleService;
using EduServices.OrganizationService;
using EduServices.RoleService;
using EduServices.SendMailService;
using EduServices.UserService;
using Microsoft.Extensions.Configuration;
using Model.Functions.CourseStudent;
using Model.Functions.CourseTerm;
using Model.Functions.Organization;
using Model.Functions.User;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using Model.Tables.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Shared;
using WebModel.User;

namespace EduFacade.UserFacade
{
    public class UserFacade : BaseFacade, IUserFacade
    {
        private readonly IUserService _userService;
        private readonly IUserConvertor _userConvertor;
        private readonly IRoleService _roleService;
        private readonly ISendMailService _sendMailService;
        private readonly IAddressConvertor _addressConvertor;
        private readonly IConfiguration _configuration;
        private readonly ILinkLifeTimeService _linkLifeTimeService;
        private readonly IOrganizationService _organizationService;
        private readonly IBankOfQuestionService _bankOfQuestionService;
        private readonly IOrganizationConvertor _organizationConvertor;
        private readonly IClassRoomService _classRoomService;
        private readonly HashSet<Country> _cbCountries;
        private readonly IBranchService _branchService;
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly ILicenseService _licenseService;
        private readonly ICourseStudentService _courseStudentService;
        private readonly ICourseLectorService _courseLectorService;
        private readonly ICourseTermService _courseTermService;


        public UserFacade(IUserService userService, IRoleService roleService, ISendMailService sendMailService, IUserConvertor userConvertor, IAddressConvertor addressConvertor, IConfiguration configuration, ILinkLifeTimeService linkLifeTimeService, IOrganizationService organizationService, IBankOfQuestionService bankOfQuestionService, IOrganizationConvertor organizationConvertor, IClassRoomService classRoomService, ICodeBookService codeBookService, IBranchService branchService, IOrganizationRoleService organizationRoleService, ILicenseService licenseService, ICourseStudentService courseStudentService, ICourseLectorService courseLectorService, ICourseTermService courseTermService)
        {
            _userService = userService;
            _roleService = roleService;
            _sendMailService = sendMailService;
            _userConvertor = userConvertor;
            _addressConvertor = addressConvertor;
            _configuration = configuration;
            _linkLifeTimeService = linkLifeTimeService;
            _organizationService = organizationService;
            _bankOfQuestionService = bankOfQuestionService;
            _organizationConvertor = organizationConvertor;
            _classRoomService = classRoomService;
            _cbCountries = codeBookService.GetCodeBookItems<Country>();
            _branchService = branchService;
            _organizationRoleService = organizationRoleService;
            _licenseService = licenseService;
            _courseStudentService = courseStudentService;
            _courseLectorService = courseLectorService;
            _courseTermService = courseTermService;
        }

        public Result AddUser(AddUserDto userCreateDto, bool sendActivateEmail)
        {
            Result validate = ValidateUser(userCreateDto);
            if (validate.IsOk)
            {
                User user = _userConvertor.ConvertToBussinessEntity(userCreateDto);
                user.UserRole = _roleService.GetUserRole(UserRoleValues.REGISTERED_USER);
                _userService.AddUser(user);
                if (userCreateDto.CreateNewOrganization)
                {
                    AddOrganization addOrganization = _organizationConvertor.ConvertToBussinessEntity(userCreateDto.Organization, user.Id);
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
                }
                if (!string.IsNullOrEmpty(userCreateDto.OrganizationId))
                {
                    Guid.TryParse(userCreateDto.OrganizationId, out Guid orgId);
                    _organizationRoleService.AddUserToOrganization(new AddUserToOrganization()
                    {
                        OrganizationId = orgId,
                        OrganizationRoleId = _organizationRoleService.GetOrganizationRoles().FirstOrDefault(x => x.SystemIdentificator == OrganizationRoleValue.STUDENT).Id,
                        UserId = user.Id
                    });
                }
                Dictionary<string, string> replaceData = new Dictionary<string, string>
                {
                    { "activationLink", string.Format("{0}/?id={1}", _configuration.GetSection("ClientUrlActivate").Value, user.Id) }
                };
                if (sendActivateEmail)
                {
                    _sendMailService.SendMail(EduEmailValue.REGISTRATION_USER, userCreateDto.ClientCulture, new EmailAddress()
                    {
                        Email = userCreateDto.UserEmail,
                        Name = userCreateDto.Person.FullName
                    }, replaceData, Guid.Empty, ""
                    );
                }
                else
                {
                    _userService.ActivateUser(user.Id);
                }
            }
            return validate;
        }
        public Result ActivateUser(Guid userId)
        {
            _userService.ActivateUser(userId);
            return new Result();
        }
        private void ValidatePersonAddress(HashSet<AddressDto> addressesDto, Result validate)
        {
            List<Address> addresses = new List<Address>();
            foreach (AddressDto item in addressesDto)
            {
                addresses.Add(_addressConvertor.ConvertToBussinessEntity(item));
            }
            _userService.ValidatePersonAddresses(addresses, validate);
        }
        private Result ValidateUser(UpdateUserDto userCreateDto)
        {
            Result validate = new Result();
            ValidatePersonAddress(userCreateDto.Person.Address, validate);
            return validate;
        }
        private Result ValidateUser(AddUserDto userCreateDto)
        {
            Result validate = new Result();
            _userService.ValidateEmail(userCreateDto.UserEmail, Guid.Empty, validate);
            _userService.ValidatePassword(userCreateDto.UserPassword, userCreateDto.UserPassword2, validate);
            ValidatePersonAddress(userCreateDto.Person.Address, validate);
            _userService.ValidatePersonName(userCreateDto.Person.FirstName, userCreateDto.Person.LastName, validate);
            if (userCreateDto.CreateNewOrganization)
            {
                _organizationService.ValidateOrganizationName(userCreateDto.Organization.Name, validate);
                _organizationService.ValidateUri(userCreateDto.Organization.ContactInformation.WWW, validate);
                _organizationService.ValidateEmail(userCreateDto.Organization.ContactInformation.Email, validate);
                _organizationService.ValidatePhoneNumber(userCreateDto.Organization.ContactInformation.PhoneNumber, validate);
                _organizationService.ValidateDefaultCulture(userCreateDto.Organization.DefaultCulture, validate);
            }
            if (!string.IsNullOrEmpty(userCreateDto.OrganizationId))
            {
                Guid orgId = Guid.Empty;
                Guid.TryParse(userCreateDto.OrganizationId, out orgId);

                if (!_licenseService.ValidateLicence(orgId, new AdUserToOrganizationOperation()))
                {
                    throw new LicenseException();
                }
            }
            return validate;
        }

        public Result ChangePassword(ChangePasswordDto changePassword)
        {
            Result validate = ChangePasswordValidate(changePassword);
            if (validate.IsOk)
            {
                _userService.ChangePassword(changePassword.UserId, changePassword.NewUserPassword);
            }
            return validate;
        }
        private Result ChangePasswordValidate(ChangePasswordDto changePassword)
        {
            Result validate = new Result();
            _userService.ChangePasswordValidate(changePassword.UserId, changePassword.OldUserPassword, validate);
            _userService.ValidatePassword(changePassword.NewUserPassword, changePassword.NewUserPassword2, validate);
            return validate;
        }

        public Result ChangeUserToken(Guid userId)
        {
            _userService.SetUserToken(userId);
            return new Result();
        }

        public Result DeleteUser(Guid userId)
        {
            _userService.DeleteUser(userId);
            return new Result();
        }

        public GetUserDetailDto GetUserDetail(Guid id)
        {
            GetUserDetail userDetail = _userService.GetUserDetail(id);
            HashSet<GetUserAddress> getUserAddress = _userService.GetUserAddresses(userDetail.PersonId);
            return _userConvertor.ConvertToWebModel(userDetail, getUserAddress);
        }

        public LoginUserDto GetUserToken(GetUserTokenDto loginData)
        {
            LoginUser loginUser = _userService.GetUserToken(loginData.UserEmail, loginData.UserPassword);
            if (loginUser != null)
            {
                if (!string.IsNullOrEmpty(loginData.OrganizationId))
                {
                    Guid orgId = Guid.Empty;
                    Guid.TryParse(loginData.OrganizationId, out orgId);
                    if (_organizationService.GetMyOrganizations(loginUser.Id).FirstOrDefault(x => x.Id == orgId) == null)
                    {
                        return null;
                    }
                }
                return _userConvertor.ConvertToWebModel(loginUser);
            }

            return null;
        }
        public LoginUserDto LoginSocialNetwork(LoginSocialNetworkDto loginSocialNetwork)
        {
            if ((string.IsNullOrEmpty(loginSocialNetwork.UserEmail)) || (string.IsNullOrEmpty(loginSocialNetwork.Id)))
            {
                return null;
            }
            GetUserDetail detail = _userService.GetUserDetail(loginSocialNetwork.UserEmail);
            LoginUser loginUser = new LoginUser();
            if (detail == null)
            {
                string password = string.Format("{0}#{1}#{2}", loginSocialNetwork.Id, loginSocialNetwork.Type, loginSocialNetwork.UserEmail);
                AddUser(new AddUserDto()
                {
                    UserEmail = loginSocialNetwork.UserEmail,
                    UserPassword = password,
                    UserPassword2 = password,
                    Person = new PersonDto()
                    {
                        Address = new HashSet<AddressDto>(),
                        FirstName = loginSocialNetwork.FirstName,
                        LastName = loginSocialNetwork.LastName.Trim().Trim(',').Trim(),
                        SecondName = "",
                        AvatarUrl = loginSocialNetwork.Avatar
                    },
                    OrganizationId = loginSocialNetwork.OrganizationId
                }, false);
                detail = _userService.GetUserDetail(loginSocialNetwork.UserEmail);
            }
            if (!string.IsNullOrEmpty(loginSocialNetwork.OrganizationId))
            {
                Guid orgId = Guid.Empty;
                Guid.TryParse(loginSocialNetwork.OrganizationId, out orgId);
                if (_organizationService.GetMyOrganizations(detail.Id).FirstOrDefault(x => x.Id == orgId) == null)
                {
                    return null;
                }
            }
            if (loginSocialNetwork.Type == "GOOGLE")
            {
                _userService.SetGoogleId(detail.Id, loginSocialNetwork.Id, loginSocialNetwork.Avatar);
                loginUser = _userService.GetTokenByGoogleId(detail.Id, loginSocialNetwork.Id);
            }
            if (loginSocialNetwork.Type == "FACEBOOK")
            {
                _userService.SetFacebookId(detail.Id, loginSocialNetwork.Id, loginSocialNetwork.Avatar);
                loginUser = _userService.GetTokenByFacebookId(detail.Id, loginSocialNetwork.Id);
            }

            return _userConvertor.ConvertToWebModel(loginUser);
        }
        public Result UpdateUser(UpdateUserDto userUpdateDto)
        {
            Result result = ValidateUser(userUpdateDto);
            if (result.IsOk)
            {
                UpdateUser user = _userConvertor.ConvertToBussinessEntity(userUpdateDto);
                _userService.UpdateUser(user);
            }
            return result;
        }

        public void GeneratePasswordResetEmail(GeneratePasswordResetEmailDto generatePasswordResetEmailDto)
        {
            GetUserDetail userDetail = _userService.GetUserDetail(generatePasswordResetEmailDto.UserEmail);
            if (userDetail != null)
            {
                Guid id = _linkLifeTimeService.GenerateLinkLifeTime(userDetail.Id, 30);
                Dictionary<string, string> replace = new Dictionary<string, string>
                {
                    { "passwordResetLink", string.Format("{0}/?id={1}", _configuration.GetSection("ClientUrlResetPassword").Value, id) }
                };

                _sendMailService.SendMail(EduEmailValue.PASSWORD_RESET, generatePasswordResetEmailDto.ClientCulture, new EmailAddress()
                {
                    Email = userDetail.UserEmail
                }, replace, Guid.Empty, "");
            }
        }

        public Result SetNewPassword(SetNewPasswordDto setNewPasswordDto)
        {
            Result validate = new Result();
            _userService.ValidatePassword(setNewPasswordDto.Password1, setNewPasswordDto.Password2, validate);
            if (validate.IsOk)
            {
                _userService.SetNewPassword(setNewPasswordDto.LinkId, setNewPasswordDto.Password1);
            }
            return validate;
        }

        public List<GetMyTimeTableDto> GetMyTimeTable(Guid userId)
        {
            List<GetMyTimeTableDto> getUserDetailDtos = new List<GetMyTimeTableDto>();
            HashSet<GetMyOrganizations> organizations = _organizationService.GetMyOrganizations(userId);
            HashSet<GetMyCourse> myCourse = _courseStudentService.GetStudentCourse(userId, true);
            HashSet<GetMyCourse> myCourseLector = _courseLectorService.GetLectorCourse(userId);
            myCourse.UnionWith(myCourseLector);
            foreach (GetMyOrganizations item in organizations)
            {
                HashSet<GetMyCourse> courseInOrganization = myCourse.Where(x => x.OrganizationId == item.Id).ToHashSet();
                GetMyTimeTableDto timeTableItem = new GetMyTimeTableDto();
                HashSet<GetStudyHours> getStudyHours = _organizationService.GetStudyHours(item.Id).OrderBy(x => x.Position).ToHashSet();
                HashSet<TimeTableDto> timeTable = new HashSet<TimeTableDto>();
                HashSet<GetMyCourse> monday = courseInOrganization.Where(x => x.Monday).ToHashSet();
                HashSet<GetMyCourse> tuesday = courseInOrganization.Where(x => x.Tuesday).ToHashSet();
                HashSet<GetMyCourse> wednesday = courseInOrganization.Where(x => x.Wednesday).ToHashSet();
                HashSet<GetMyCourse> thursday = courseInOrganization.Where(x => x.Thursday).ToHashSet();
                HashSet<GetMyCourse> friday = courseInOrganization.Where(x => x.Friday).ToHashSet();
                HashSet<GetMyCourse> saturday = courseInOrganization.Where(x => x.Saturday).ToHashSet();
                HashSet<GetMyCourse> sunday = courseInOrganization.Where(x => x.Sunday).ToHashSet();

                timeTableItem.StudyHours = getStudyHours.Select(x => new WebModel.Organization.GetStudyHoursDto()
                {
                    ActiveFrom = x.ActiveFrom,
                    ActiveFromId = x.ActiveFromId,
                    ActiveTo = x.ActiveTo,
                    ActiveToId = x.ActiveToId,
                    Id = x.Id,
                    OrganizationId = x.OrganizationId,
                    Position = x.Position
                }).ToHashSet();
                timeTableItem.HaveStudyHours = getStudyHours.Count > 0;
                timeTableItem.OrganizationName = item.Name;
                PrepareTimeTable(monday, getStudyHours, timeTableItem, "TIME_TABLE_MONDAY");
                PrepareTimeTable(tuesday, getStudyHours, timeTableItem, "TIME_TABLE_TUESDAY");
                PrepareTimeTable(wednesday, getStudyHours, timeTableItem, "TIME_TABLE_WEDNESDAY");
                PrepareTimeTable(thursday, getStudyHours, timeTableItem, "TIME_TABLE_THURSDAY");
                PrepareTimeTable(friday, getStudyHours, timeTableItem, "TIME_TABLE_FRIDAY");
                PrepareTimeTable(saturday, getStudyHours, timeTableItem, "TIME_TABLE_SATURDAY");
                PrepareTimeTable(sunday, getStudyHours, timeTableItem, "TIME_TABLE_SUNDAY");
                getUserDetailDtos.Add(timeTableItem);
            }
            return getUserDetailDtos;

        }
        private void PrepareTimeTable(HashSet<GetMyCourse> day, HashSet<GetStudyHours> getStudyHours, GetMyTimeTableDto timeTableItem, string dayName)
        {
            TimeTableDto timeTableDto = new TimeTableDto
            {
                DayOfWeek = dayName
            };
            foreach (GetStudyHours item in getStudyHours)
            {
                string courseName = "";
                courseName = day.FirstOrDefault(x => x.TimeFromId == item.ActiveFromId && x.TimeToId == item.ActiveToId)?.CourseName;
                timeTableDto.CourseTerm.Add(courseName);
            }
            timeTableItem.TimeTable.Add(timeTableDto);
        }

        public HashSet<GetMyAttendanceDto> GetMyAttendance(Guid userId)
        {
            HashSet<GetMyAttendanceDto> getMyAttendanceDtos = new HashSet<GetMyAttendanceDto>();
            HashSet<GetMyCourse> myCourse = _courseStudentService.GetStudentCourse(userId, true);

            foreach (GetMyCourse course in myCourse)
            {
                HashSet<GetStudentAttendance> getStudentAttendances = _courseTermService.GetStudentAttendance(course.TermId).Where(x => x.CourseStudentId == course.CourseStudentId).ToHashSet();
                foreach (var item in getStudentAttendances)
                {
                    GetMyAttendance myAttendances = _courseTermService.GetMyAttendance(item.CourseStudentId, item.CourseTermDateId);
                    
                        getMyAttendanceDtos.Add(new GetMyAttendanceDto()
                        {
                            CourseName = course.CourseName,
                            IsActive = myAttendances == null ? false : myAttendances.IsActive,
                            Date = item.Date,
                            DayOfWeek = item.DayOfWeek,
                            TimeFrom = item.TimeFrom,
                            TimeTo = item.TimeTo
                        });
                    
                }
             
            }
            return getMyAttendanceDtos.OrderByDescending(x=>x.Date).ToHashSet();
        }
    }
}
