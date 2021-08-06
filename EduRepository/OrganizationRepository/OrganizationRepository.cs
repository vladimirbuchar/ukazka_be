using Core.Extension;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.License;
using Model.Functions.Organization;
using Model.Functions.Shared;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.OrganizationRepository
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository
    {
        private readonly string _elearningUrl;
        public OrganizationRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {
            _elearningUrl = configuration.GetSection("ElearningUrl").Value;
        }

        public Guid GetOrganizationIdByBranch(Guid branchId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByBranch", new List<SqlParameter>()
            {
                new SqlParameter("@branchId",branchId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationIdByClassRoom(Guid classRoomId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByClassRoom", new List<SqlParameter>()
            {
                new SqlParameter("@classRoomId",classRoomId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByCourse(Guid courseId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourse", new List<SqlParameter>()
            {
                new SqlParameter("@courseId",courseId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByTermId(Guid termId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourseTerm", new List<SqlParameter>()
            {
                new SqlParameter("@courseTermId",termId)
            }).FirstOrDefault().Id;
        }
        public Guid GetOrganizationByCourseLessonId(Guid courseLessonId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourseLesson", new List<SqlParameter>()
            {
                new SqlParameter("@courseLessonId",courseLessonId)
            }).FirstOrDefault().Id;
        }

        public HashSet<GetAllOrganizations> GetAllOrganizations()
        {
            return CallSqlFunction<GetAllOrganizations>("GetAllOrganizations").OrderBy(x => x.Priority).ToHashSet();
        }

        public HashSet<GetMyOrganizations> GetMyOrganizations(Guid userId)
        {
            List<SqlParameter> param = new List<SqlParameter>
            {
                new SqlParameter("@userId", userId)
            };
            return CallSqlFunction<GetMyOrganizations>("GetMyOrganization", param);
        }
        public GetOrganizationDetail GetOrganizationDetail(Guid organizationId)
        {
            List<SqlParameter> param = new List<SqlParameter>
            {
                new SqlParameter("@organizationId", organizationId)
            };
            return CallSqlFunction<GetOrganizationDetail>("GetOrganizationDetail", param).FirstOrDefault();
        }

        public HashSet<GetOrganizationAddress> GetOrganizationAddress(Guid organizationId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@organizationId", organizationId)
            };
            return CallSqlFunction<GetOrganizationAddress>("GetOrganizationAddress", parameters);
        }

        public GetLicenseByOrganization GetLicenseByOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetLicenseByOrganization>("GetLicenseByOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).FirstOrDefault();
        }

        public Guid GetOrganizationByUserInOrganization(Guid id)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByUserInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@id",id)
            }).FirstOrDefault().Id;
        }

        public Guid AddOrganization(AddOrganization addOrganization)
        {
            Guid organizationGuid = Guid.Empty;
            FAddress address = addOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.REGISTERED_OFFICE_ADDRESS);
            FAddress billingAddress = addOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.BILLING_ADDRESS);
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CanSendCourseInquiry", addOrganization.CanSendCourseInquiry),
                new SqlParameter("@LicenseIdentificator", addOrganization.LicenseIdentificator),
                new SqlParameter("@ContactInformationEmail", addOrganization.ContactInformationEmail),
                new SqlParameter("@ContactInformationPhoneNumber", addOrganization.ContactInformationPhoneNumber),
                new SqlParameter("@ContactInformationWWW", addOrganization.ContactInformationWWW),
                new SqlParameter("@BasicInformationName", addOrganization.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", addOrganization.BasicInformationDescription),
                new SqlParameter("@UserId", addOrganization.UserId),
                new SqlParameter("@OrganizationRoleIdentificator", addOrganization.OrganizationRoleIdentificator),
                new SqlParameter("@addressCountry",address.CountryId),
                new SqlParameter("@addressRegion",address.Region),
                new SqlParameter("@addressCity",address.City),
                new SqlParameter("@addressStreet",address.Street),
                new SqlParameter("@addressHouseNumber",address.HouseNumber),
                new SqlParameter("@addressZipCode",address.ZipCode),
                new SqlParameter("@addressTypeId",address.AddressTypeId),
                new SqlParameter("@addressCountryContact",billingAddress.CountryId),
                new SqlParameter("@addressRegionContact",billingAddress.Region),
                new SqlParameter("@addressCityContact",billingAddress.City),
                new SqlParameter("@addressStreetContact",billingAddress.Street),
                new SqlParameter("@addressHouseNumberContact",billingAddress.HouseNumber),
                new SqlParameter("@addressZipCodeContact",billingAddress.ZipCode),
                new SqlParameter("@addressTypeIdContact",billingAddress.AddressTypeId),
                new SqlParameter("@DefaultPassword",addOrganization.BasicInformationName.Trim().Replace(" ","").RemoveDiacritics()),
                new SqlParameter("@DefaultCulture",addOrganization.DefaultCulture),
                new SqlParameter("@ElearningUrl",string.Format("{0}{1}",_elearningUrl,Guid.NewGuid()))
            };

            CallSqlProcedure("CreateOrganization", sqlParameters, true, ref organizationGuid);
            return organizationGuid;

        }
        public void UpdateOrganization(UpdateOrganization updateOrganization)
        {
            FAddress address = updateOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.REGISTERED_OFFICE_ADDRESS);
            FAddress billingAddress = updateOrganization.Addresses.FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.BILLING_ADDRESS);
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@OrganizationId",updateOrganization.OrganizationId),
                new SqlParameter("@CanSendCourseInquiry", updateOrganization.CanSendCourseInquiry),
                new SqlParameter("@ContactInformationEmail", updateOrganization.ContactInformationEmail),
                new SqlParameter("@ContactInformationPhoneNumber", updateOrganization.ContactInformationPhoneNumber),
                new SqlParameter("@ContactInformationWWW", updateOrganization.ContactInformationWWW),
                new SqlParameter("@BasicInformationName", updateOrganization.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", updateOrganization.BasicInformationDescription),

                new SqlParameter("@addressCountry",address.CountryId),
                new SqlParameter("@addressRegion",address.Region),
                new SqlParameter("@addressCity",address.City),
                new SqlParameter("@addressStreet",address.Street),
                new SqlParameter("@addressHouseNumber",address.HouseNumber),
                new SqlParameter("@addressZipCode",address.ZipCode),
                new SqlParameter("@addressTypeId",address.AddressTypeId),
                new SqlParameter("@addressCountryContact",billingAddress.CountryId),
                new SqlParameter("@addressRegionContact",billingAddress.Region),
                new SqlParameter("@addressCityContact",billingAddress.City),
                new SqlParameter("@addressStreetContact",billingAddress.Street),
                new SqlParameter("@addressHouseNumberContact",billingAddress.HouseNumber),
                new SqlParameter("@addressZipCodeContact",billingAddress.ZipCode),
                new SqlParameter("@addressTypeIdContact",billingAddress.AddressTypeId),
            };
            CallSqlProcedure("UpdateOrganization", sqlParameters);
        }

        public HashSet<FindOrganization> FindOrganization(string findText)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@findText", findText)
            };
            return CallSqlFunction<FindOrganization>("FindOrganization", sqlParameters).OrderBy(x => x.Id).ToHashSet();
        }

        public Guid GetOrganizationByCourseLessonItemId(Guid courseLessonItemId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourseLessonItem", new List<SqlParameter>()
            {
                new SqlParameter("@courseLessonItemId",courseLessonItemId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestionId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByBankOfQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@BankOfQuestionId",bankOfQuestionId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationIdByQuestion(Guid questionId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationIdByQuestion", new List<SqlParameter>()
            {
                new SqlParameter("@BankOfQuestionId",questionId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByAnswer(Guid answerId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationIdByAnswer", new List<SqlParameter>()
            {
                new SqlParameter("@answerId",answerId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByStudent(Guid studentId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByStudent", new List<SqlParameter>()
            {
                new SqlParameter("@studentId",studentId)
            }).FirstOrDefault().Id;
        }

        public void SaveOrganizationSetting(SaveOrganizationSetting saveOrganizationSetting)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@OrganizationId", saveOrganizationSetting.OrganizationId),
                new SqlParameter("@UserDefaultPassword", saveOrganizationSetting.UserDefaultPassword),
                new SqlParameter("@LicenseId",saveOrganizationSetting.LicenseId),
                new SqlParameter("@DefaultCulture",saveOrganizationSetting.DefaultCulture),
                new SqlParameter("@UrlElearning",saveOrganizationSetting.UrlElearning),
                new SqlParameter("@FacebookLogin",saveOrganizationSetting.FacebookLogin),
                new SqlParameter("@GoogleLogin",saveOrganizationSetting.GoogleLogin),
                new SqlParameter("@PasswordReset",saveOrganizationSetting.PasswordReset),
                new SqlParameter("@Registration",saveOrganizationSetting.Registration),
                new SqlParameter("@LessonLength",saveOrganizationSetting.LessonLength),
                new SqlParameter("@BackgroundColor",saveOrganizationSetting.BackgroundColor),
                new SqlParameter("@TextColor",saveOrganizationSetting.TextColor),
                new SqlParameter("@UseCustomSmtpServer",saveOrganizationSetting.UseCustomSmtpServer),
                new SqlParameter("@SmtpServerPassword",saveOrganizationSetting.SmtpServerPassword),
                new SqlParameter("@SmtpServerPort",saveOrganizationSetting.SmtpServerPort),
                new SqlParameter("@SmtpServerUrl",saveOrganizationSetting.SmtpServerUrl),
                new SqlParameter("@SmtpServerUserName",saveOrganizationSetting.SmtpServerUserName),
                new SqlParameter("@GoogleApiToken",saveOrganizationSetting.GoogleApiToken)


            };
            CallSqlProcedure("SaveOrganizationSetting", sqlParameters);
        }

        public GetOrganizationSetting GetOrganizationSetting(Guid organizationId)
        {
            return CallSqlFunction<GetOrganizationSetting>("GetOrganizationSetting", new List<SqlParameter>()
            {
                {new SqlParameter("@OrganizationId",organizationId )}
            }).FirstOrDefault();
        }

        public Guid GetOrganizationByCertificateId(Guid certificateId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCertificateId", new List<SqlParameter>()
            {
                new SqlParameter("@certificateId",certificateId)
            }).FirstOrDefault().Id;
        }

        public HashSet<GetOrganizationCulture> GetOrganizationCulture(Guid organizationId)
        {
            return CallSqlFunction<GetOrganizationCulture>("GetOrganizationCulture", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).ToHashSet();
        }
        public bool CheckOrganizationUrl(string organizationUrl, Guid organizationId)
        {
            return CallSqlFunction<Count>("CheckOrganizationUrl", new List<SqlParameter>()
            {
                new SqlParameter("@organizationUrl",organizationUrl),
                new SqlParameter("@organizationId",organizationId)
            }).FirstOrDefault().RowsCount == 0;
        }

        public GetOrganizationSettingByUrl GetOrganizationSettingByUrl(string url)
        {
            return CallSqlFunction<GetOrganizationSettingByUrl>("GetOrganizationSettingByUrl", new List<SqlParameter>()
            {
                new SqlParameter("@url",url)
            }).FirstOrDefault();
        }

        public void AddStudyHour(AddStudyHours addStudyHours)
        {
            CallSqlProcedure("AddStudyHour", new List<SqlParameter>()
            {
                new SqlParameter("@OrganizationId", addStudyHours.OrganizationId),
                new SqlParameter("@ActiveFromId", addStudyHours.ActiveFromId),
                new SqlParameter("@ActiveToId", addStudyHours.ActiveToId),
                new SqlParameter("@Position", addStudyHours.Position),

            });
        }

        public void UpdateStudyHour(UpdateStudyHours updateStudyHours)
        {
            CallSqlProcedure("UpdateStudyHour", new List<SqlParameter>()
            {
                new SqlParameter("@Id", updateStudyHours.Id),
                new SqlParameter("@ActiveFromId", updateStudyHours.ActiveFromId),
                new SqlParameter("@ActiveToId", updateStudyHours.ActiveToId),
                new SqlParameter("@Position", updateStudyHours.Position),

            });
        }

        public HashSet<GetStudyHours> GetStudyHours(Guid organizationId)
        {
            return CallSqlFunction<GetStudyHours>("GetStudyHours", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).ToHashSet();
        }

        public Guid GetOrganizationBySendMessage(Guid sendMessageId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationBySendMessageId", new List<SqlParameter>()
            {
                new SqlParameter("@sendMessageId",sendMessageId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByStudentGroupId(Guid studentGroupId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByStudentGroupId", new List<SqlParameter>()
            {
                new SqlParameter("@studentGroupId",studentGroupId)
            }).FirstOrDefault().Id;
        }

        public Guid GetOrganizationByCourseMaterial(Guid courseMaterialId)
        {
            return CallSqlFunction<OrganizationId>("GetOrganizationByCourseMaterial", new List<SqlParameter>()
            {
                new SqlParameter("@courseMaterialId",courseMaterialId)
            }).FirstOrDefault().Id;
        }
    }
}

