using Core.DataTypes;
using Core.Exceptions;
using Core.Extension;
using EduCore.EduOperation.UserInOrganization;
using EduFacade.SendMessageFacade.Convertor;
using EduServices.CertificateService;
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
using Model.Functions.CourseStudent;
using Model.Functions.Notification;
using Model.Functions.User;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.SendMessage;
using WebModel.Student;

namespace EduFacade.SendMessageFacade
{
    public class StudentGroupFacade : BaseFacade, IStudentGroupFacade
    {
        private readonly IStudentGroupConvertor _studentGroupConvertor;
        private readonly IStudentGroupService _studentGroupService;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;
        private readonly ILicenseService _licenseService;
        private readonly IRoleService _roleService;
        private readonly IOrganizationRoleService _organizationRoleService;
        private readonly INotificationService _notificationService;
        private readonly ISendMailService _sendMailService;
        private readonly IConfiguration _configuration;
        private readonly ICourseStudentService _courseStudentService;

        private readonly HashSet<NotificationType> _notificationTypes;


        public StudentGroupFacade(IStudentGroupService studentGroupService, IStudentGroupConvertor studentGroupConvertor, IUserService userService, IOrganizationService organizationService, ILicenseService licenseService, IRoleService roleService, IOrganizationRoleService organizationRoleService, INotificationService notificationService, ICodeBookService codeBooService, ISendMailService sendMailService, IConfiguration configuration, ICourseStudentService courseStudentService)
        {
            _studentGroupConvertor = studentGroupConvertor;
            _studentGroupService = studentGroupService;
            _userService = userService;
            _organizationService = organizationService;
            _licenseService = licenseService;
            _roleService = roleService;
            _organizationRoleService = organizationRoleService;
            _notificationService = notificationService;
            _notificationTypes = codeBooService.GetCodeBookItems<NotificationType>();
            _sendMailService = sendMailService;
            _configuration = configuration;
            _courseStudentService = courseStudentService;
        }

        public Result AddStudentGroup(AddStudentGroupDto addSendMessageDto)
        {
            Result result = new Result();
            _studentGroupService.ValidateName(addSendMessageDto.Name, result);
            if (result.IsOk)
            {
                Model.Functions.SendMessage.AddStudentGroup addStudentGroup = _studentGroupConvertor.CovertToBussinessEntity(addSendMessageDto);
                return new Result<Guid>()
                {
                    Data = _studentGroupService.AddStudentGroup(addStudentGroup)
                };

            }
            return result;
        }

        public Result AddStudentToGroup(AddStudentToGroupDto addStudentToGroupDto, Guid organizationId)
        {
            Result result = new Result();
            string email = addStudentToGroupDto.UserEmail;

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
                    _userService.AddUserByEmail(email, _roleService.GetUserRole(UserRoleValues.REGISTERED_USER), defaultPassword, addStudentToGroupDto.FirstName, addStudentToGroupDto.LastName);
                    user = _userService.GetUserDetail(email);

                    Guid studentId = _organizationRoleService.AddUserToOrganization(new AddUserToOrganization()
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
                    _sendMailService.SendMail(EduEmailValue.REGISTRATION_USER, addStudentToGroupDto.ClientCulture, new EmailAddress()
                    {
                        Email = email,
                        Name = ""
                    }, replaceData, Guid.Empty, "");
                }
                _studentGroupService.AddStudentToGroup(new Model.Functions.StudentGroup.AddStudentToGroup()
                {
                    UserId = _organizationRoleService.GetAllUserInOrganization(organizationId).FirstOrDefault(x => x.UserEmail == email).Id,
                    StudentGroupId = addStudentToGroupDto.StudentGroupId
                });
                HashSet<GetAllTermInGroup> getAllTermInGroups = _studentGroupService.GetAllTermInGroup(addStudentToGroupDto.StudentGroupId);
                foreach (GetAllTermInGroup item in getAllTermInGroups)
                {
                    _courseStudentService.AddStudentToCourseTerm(new AddStudentToCourseTerm()
                    {
                        CourseTermId = item.CourseTermId,
                        UserId = _organizationRoleService.GetAllUserInOrganization(organizationId).FirstOrDefault(x => x.UserEmail == email).Id
                    });
                }

            }
            else
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ADD_STUDENT_TO_COURSE", "EMAIL_IS_NOT_VALID", email, 0));
            }
            return result;
        }

        public void DeleteStudentFromGroup(Guid studentId, Guid studentGroupId)
        {
            HashSet<GetAllTermInGroup> getAllTermInGroups = _studentGroupService.GetAllTermInGroup(studentGroupId);
            HashSet<GetAllStudentInGroup> getAllStudentInGroups = _studentGroupService.GetAllStudentInGroup(studentGroupId);
            foreach (GetAllTermInGroup item in getAllTermInGroups)
            {
                HashSet<GetAllStudentInCourseTerm> getAllStudentInCourseTerms = _courseStudentService.GetAllStudentInCourseTerm(item.CourseTermId);
                foreach (GetAllStudentInCourseTerm student in getAllStudentInCourseTerms)
                {
                    bool delete = getAllStudentInGroups.FirstOrDefault(x => x.StudentId == student.StudentId) == null ? false : true;
                    if (delete)
                    {
                        _courseStudentService.DeleteStudentFromCourseTerm(student.Id);
                    }
                }
            }
            _studentGroupService.DeleteStudentFromGroup(studentId);
        }

        public void DeleteStudentGroup(Guid sendMessageId)
        {
            _studentGroupService.DeleteStudentGroup(sendMessageId);
        }

        public HashSet<GetAllStudentInGroupDto> GetAllStudentInGroup(Guid studenbtGroupId)
        {
            return _studentGroupConvertor.ConvertToWebModel(_studentGroupService.GetAllStudentInGroup(studenbtGroupId));
        }

        public GetStudentGroupDetailDto GetStudentGroupDetail(Guid studentGroupId)
        {
            return _studentGroupConvertor.ConvertToWebModel(_studentGroupService.GetStudentGroupDetail(studentGroupId));
        }

        public HashSet<GetStudentGroupInOrganizationDto> GetStudentGroupInOrganization(Guid organizationId)
        {
            return _studentGroupConvertor.ConvertToWebModel(_studentGroupService.GetStudentGroupInOrganization(organizationId));
        }

        public Result UpdateStudentGroup(UpdateStudentGroupDto updateSendMessageDto)
        {
            Result result = new Result();
            _studentGroupService.ValidateName(updateSendMessageDto.Name, result);
            if (result.IsOk)
            {
                Model.Functions.SendMessage.UpdateStudentGroup updateSendMessage = _studentGroupConvertor.CovertToBussinessEntity(updateSendMessageDto);
                _studentGroupService.UpdateStudentGroup(updateSendMessage);
            }
            return result;
        }
    }
}
