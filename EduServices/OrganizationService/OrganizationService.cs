using Core.DataTypes;
using Core.Extension;
using EduRepository.CodeBookRepository;
using EduRepository.OrganizationRepository;
using Microsoft.Extensions.Configuration;
using Model.Functions.Organization;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.OrganizationService
{
    public class OrganizationService : BaseService, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly HashSet<Culture> _cultures;
        private readonly HashSet<TimeTable> _timeTables;
        private readonly string _elearningUrl;
        public OrganizationService(IOrganizationRepository organizationRepository, ICodeBookRepository codeBookRepository, IConfiguration configuration)
        {
            _organizationRepository = organizationRepository;
            _cultures = codeBookRepository.GetCodeBookItems<Culture>();
            _timeTables = codeBookRepository.GetCodeBookItems<TimeTable>();
            _elearningUrl = configuration.GetSection("ElearningUrl").Value;
        }

        public void DeleteOrganization(Guid organizationId)
        {
            _organizationRepository.DeleteEntity<Organization>(organizationId);
        }

        public HashSet<GetAllOrganizations> GetOrganizationList()
        {
            return _organizationRepository.GetAllOrganizations();
        }

        public GetOrganizationDetail GetOrganizationDetail(Guid organizationId)
        {
            return _organizationRepository.GetOrganizationDetail(organizationId);
        }
        public HashSet<GetOrganizationAddress> GetOrganizationAddress(Guid organizationId)
        {
            return _organizationRepository.GetOrganizationAddress(organizationId);
        }

        public void UpdateOrganization(UpdateOrganization updateOrganization)
        {
            _organizationRepository.UpdateOrganization(updateOrganization);
        }

        public HashSet<GetMyOrganizations> GetMyOrganizations(Guid userId)
        {
            return _organizationRepository.GetMyOrganizations(userId);
        }

        public void ValidateOrganizationName(string name, Result validate)
        {
            if (name.IsNullOrEmptyWithTrim())
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "ORGANIZATION_NAME_IS_EMPTY"));
            }
        }
        public void ValidateUri(string uri, Result validate)
        {
            if (!uri.IsNullOrEmptyWithTrim())
            {
                if (!uri.IsValidUri())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "URI_IS_NOT_VALID"));
                }
            }
        }
        public void ValidateEmail(string email, Result validate)
        {
            if (!email.IsNullOrEmptyWithTrim())
            {
                if (!email.IsValidEmail())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "EMAIL_IS_NOT_VALID"));
                }
            }
        }
        public void ValidatePhoneNumber(string phoneNumber, Result validate)
        {
            if (!phoneNumber.IsNullOrEmptyWithTrim())
            {
                if (!phoneNumber.IsValidPhoneNumber())
                {
                    validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "PHONE_NUMBER_IS_NOT_VALID"));
                }
            }
        }

        public Guid AddOrganization(AddOrganization addOrganization)
        {
            return _organizationRepository.AddOrganization(addOrganization);
        }

        public void SaveOrganizationSetting(SaveOrganizationSetting saveOrganizationSetting)
        {
            saveOrganizationSetting.UrlElearning = saveOrganizationSetting.UrlElearning.ToUrl();
            _organizationRepository.SaveOrganizationSetting(saveOrganizationSetting);
        }

        public GetOrganizationSetting GetOrganizationSetting(Guid organizationId)
        {
            return _organizationRepository.GetOrganizationSetting(organizationId);
        }

        public void ValidateDefaultCulture(Guid cultureId, Result result)
        {
            Culture culture = _cultures.FirstOrDefault(x => x.Id == cultureId);
            if (culture == null || culture.IsDefault)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "BAD_DEFAULT_CULTURE"));
            }
        }

        public HashSet<GetOrganizationCulture> GetOrganizationCulture(Guid organizationId)
        {
            return _organizationRepository.GetOrganizationCulture(organizationId);
        }

        public void ValidateOrganizationUrl(string url, Guid organizationId, Result result)
        {
            if (string.IsNullOrEmpty(url) || url == _elearningUrl)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "ELEARNIG_BAD_EMPTY_URL"));
            }
            if (!_organizationRepository.CheckOrganizationUrl(url, organizationId))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "ELEARNIG_URL_EXISTS"));
            }
            if (!url.IsValidUri())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "ELEARNIG_IS_NOT_VALID"));
            }

        }

        public GetOrganizationSettingByUrl GetOrganizationSettingByUrl(string url)
        {
            return _organizationRepository.GetOrganizationSettingByUrl(url);
        }

        public void ValidateLessonLength(int lessonLength, Result result)
        {
            if (lessonLength < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "LESSON_LENGTH"));
            }
        }

        public void AddStudyHour(AddStudyHours addStudyHours)
        {
            if (addStudyHours.ActiveFromId != Guid.Empty && addStudyHours.ActiveToId == Guid.Empty && addStudyHours.LessonLength > 0)
            {
                TimeTable timeTable = _timeTables.FirstOrDefault(x => x.Id == addStudyHours.ActiveFromId);
                if (timeTable != null)
                {
                    addStudyHours.ActiveToId = _timeTables.FirstOrDefault(x => x.Priority == (timeTable.Priority + (addStudyHours.LessonLength / 5))).Id;
                }

            }
            _organizationRepository.AddStudyHour(addStudyHours);
        }

        public void UpdateStudyHour(UpdateStudyHours updateStudyHours)
        {
            _organizationRepository.UpdateStudyHour(updateStudyHours);
        }

        public HashSet<GetStudyHours> GetStudyHours(Guid organizationId)
        {
            return _organizationRepository.GetStudyHours(organizationId).OrderBy(x => x.Position).ToHashSet(); ;
        }

        public void DeleteStudyHour(Guid studyHourId)
        {
            _organizationRepository.DeleteEntity<OrganizationStudyHour>(studyHourId);
        }

        public void ValidateSmtp(string server, string login, string password, string port, Result result)
        {
            if (string.IsNullOrEmpty(server))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "SMTP_SERVER"));
            }
            if (string.IsNullOrEmpty(login))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "SMTP_LOGIN"));
            }
            if (string.IsNullOrEmpty(password))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "SMTP_PASSWORD"));
            }
            if (string.IsNullOrEmpty(port))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "ORGANIZATION", "SMTP_PORT"));
            }
        }
    }
}
