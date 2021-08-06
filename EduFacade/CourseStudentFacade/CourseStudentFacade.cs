using Core.DataTypes;
using Core.Exceptions;
using Core.Extension;
using EduCore.EduOperation.UserInOrganization;
using EduFacade.CourseStudentFacade.Convertor;
using EduServices.CodeBookService;
using EduServices.CourseStudentService;
using EduServices.LicenseService;
using EduServices.NotificationService;
using EduServices.OrganizationRoleService;
using EduServices.OrganizationService;
using EduServices.RoleService;
using EduServices.SendMailService;
using EduServices.UserService;
using Microsoft.Extensions.Configuration;
using Model.Functions.Notification;
using Model.Functions.User;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Student;

namespace EduFacade.CourseStudentFacade
{
    public class CourseStudentFacade : BaseFacade, ICourseStudentFacade
    {
        private readonly ICourseStudentService _courseStudentService;
        private readonly ICourseStudentConvertor _courseStudentConvertor;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly INotificationService _notificationService;
        private readonly ICodeBookService _codeBooService;
        private readonly HashSet<NotificationType> _notificationTypes;
        private readonly IOrganizationService _organizationService;
        private readonly ISendMailService _sendMailService;
        private readonly IConfiguration _configuration;
        private readonly ILicenseService _licenseService;

        public CourseStudentFacade(ILicenseService licenseService, IConfiguration configuration, ISendMailService sendMailService, ICourseStudentService courseStudentService, ICourseStudentConvertor courseStudentConvertor, IUserService userService, IRoleService roleService, IOrganizationRoleService organizationRoleService, INotificationService notificationService, ICodeBookService codeBooService, IOrganizationService organizationService)
        {
            _courseStudentService = courseStudentService;
            _courseStudentConvertor = courseStudentConvertor;
            _userService = userService;
            _roleService = roleService;
            _organizationRoleService = organizationRoleService;
            _notificationService = notificationService;
            _codeBooService = codeBooService;
            _notificationTypes = _codeBooService.GetCodeBookItems<NotificationType>();
            _organizationService = organizationService;
            _sendMailService = sendMailService;
            _configuration = configuration;
            _licenseService = licenseService;
        }
        private Result Validate(AddStudentToCourseTermDto addStudentToCourseDto)
        {
            Result result = new Result();
            _courseStudentService.ValidateStudentCount(addStudentToCourseDto.CourseTermId, result);
            //_courseStudentService.IsTermStudent(addStudentToCourseDto.CourseTermId, addStudentToCourseDto.UserId, result);
            return result;
        }

        public Result AddStudentToCourseTerm(AddStudentToCourseTermDto addStudentToCourseTermDto, Guid organizationId)
        {
            Result result = Validate(addStudentToCourseTermDto);
            if (result.IsOk)
            {
                string email = addStudentToCourseTermDto.UserEmail;

                if (email.IsValidEmail())
                {
                    GetUserDetail user = _userService.GetUserDetail(email);
                    if (user == null)
                    {
                        string defaultPassword = _organizationService.GetOrganizationSetting(organizationId).UserDefaultPassword;
                        if (!_licenseService.ValidateLicence(organizationId, new AdUserToOrganizationOperation()))
                        {
                            throw new LicenseException();
                        }
                        _userService.AddUserByEmail(email, _roleService.GetUserRole(UserRoleValues.REGISTERED_USER), defaultPassword, addStudentToCourseTermDto.FirstName, addStudentToCourseTermDto.LastName);
                        user = _userService.GetUserDetail(email);

                        _organizationRoleService.AddUserToOrganization(new AddUserToOrganization()
                        {
                            OrganizationId = organizationId,
                            OrganizationRoleId = _organizationRoleService.GetOrganizationRoles().FirstOrDefault(x => x.SystemIdentificator == OrganizationRoleValue.STUDENT).Id,
                            UserId = user.Id
                        });
                        _notificationService.AddNotification(new AddNotification()
                        {
                            IsNew = true,
                            NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationTypeValues.INVITE_TO_ORGANIZATION).Id,
                            ObjectId = organizationId,
                            UserId = user.Id
                        });
                        Dictionary<string, string> replaceData = new Dictionary<string, string>
                            {
                                { "activationLink", string.Format("{0}/?id={1}", _configuration.GetSection("ClientUrlActivate").Value, user.Id) }
                            };
                        _sendMailService.SendMail(EduEmailValue.REGISTRATION_USER, addStudentToCourseTermDto.ClientCulture, new EmailAddress()
                        {
                            Email = email,
                            Name = ""
                        }, replaceData, organizationId, "");
                    }
                    if (_courseStudentService.GetStudentCourse(user.Id, false).FirstOrDefault(x => x.TermId == addStudentToCourseTermDto.CourseTermId) == null)
                    {

                        _courseStudentService.AddStudentToCourseTerm(new Model.Functions.CourseStudent.AddStudentToCourseTerm()
                        {
                            CourseTermId = addStudentToCourseTermDto.CourseTermId,
                            UserId = _organizationRoleService.GetAllUserInOrganization(organizationId).FirstOrDefault(x => x.UserEmail == email).Id
                        });
                        _notificationService.AddNotification(new AddNotification()
                        {
                            IsNew = true,
                            NotificationTypeId = _notificationTypes.FirstOrDefault(x => x.SystemIdentificator == NotificationTypeValues.ADD_STUDENT_TO_COURSE_TERM).Id,
                            ObjectId = addStudentToCourseTermDto.CourseTermId,
                            UserId = user.Id
                        });
                    }
                }
                else
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ADD_STUDENT_TO_COURSE", "EMAIL_IS_NOT_VALID", email, 0));
                }



            }
            return result;
        }

        public void DeleteStudentFromCourseTerm(Guid studentCourseTermId)
        {
            _courseStudentService.DeleteStudentFromCourseTerm(studentCourseTermId);
        }

        public HashSet<GetAllStudentInCourseTermDto> GetAllStudentInCourseTerm(Guid courseTermId)
        {
            return _courseStudentConvertor.ConvertToWebModel(_courseStudentService.GetAllStudentInCourseTerm(courseTermId));
        }

    }
}
