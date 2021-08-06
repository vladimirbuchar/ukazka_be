using EduRepository.CodeBookRepository;
using EduRepository.CourseRepository;
using EduRepository.CourseTermRepository;
using EduRepository.OrganizationRepository;
using EduRepository.UserRepository;
using Model.Functions.Course;
using Model.Functions.CourseTerm;
using Model.Functions.Organization;
using Model.Functions.User;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.PrepareTextService
{
    public class PrepareTextService : BaseService, IPrepareTextService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly HashSet<Country> _countries;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseTermRepository _courseTermRepository;
        public PrepareTextService(IUserRepository userRepository, IOrganizationRepository organizationRepository, ICodeBookRepository codebookRepository, ICourseRepository courseRepository, ICourseTermRepository courseTermRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _countries = codebookRepository.GetCodeBookItems<Country>();
            _courseRepository = courseRepository;
            _courseTermRepository = courseTermRepository;
        }

        public string PrepareText(string text, Guid userId, Guid organizationId, Guid courseId, Guid courseTermId)
        {
            text = text.Replace("{actualDate}", DateTime.Now.ToString());
            if (userId != Guid.Empty)
            {
                GetUserDetail getUserDetail = _userRepository.GetUserDetail(userId);
                text = text.Replace("{fullName}", string.Format("{0} {1} {2}", getUserDetail.FirstName, getUserDetail.SecondName, getUserDetail.LastName));
            }
            if (organizationId != Guid.Empty)
            {
                GetOrganizationDetail getOrganizationDetail = _organizationRepository.GetOrganizationDetail(organizationId);
                GetOrganizationAddress getOrganizationAddress = _organizationRepository.GetOrganizationAddress(organizationId).FirstOrDefault(x => x.AddressTypeIdentificator == AddressTypeValues.REGISTERED_OFFICE_ADDRESS);
                text = text.Replace("{organizationAddressCountry}", _countries.FirstOrDefault(x => x.Id == getOrganizationAddress.CountryId).Name);
                text = text.Replace("{organizationAddressRegion}", getOrganizationAddress.Region);
                text = text.Replace("{organizationAddressCity}", getOrganizationAddress.City);
                text = text.Replace("{organizationAddressStreet}", getOrganizationAddress.Street);
                text = text.Replace("{organizationAddressHouseNumber}", getOrganizationAddress.HouseNumber);
                text = text.Replace("{organizationAddressHouseZip}", getOrganizationAddress.ZipCode);
            }
            if (courseId != Guid.Empty)
            {
                GetCourseDetail getCourseDetail = _courseRepository.GetCourseDetail(courseId);
                text = text.Replace("{courseName}", getCourseDetail.Name);
            }
            if (courseTermId != Guid.Empty)
            {
                GetCourseTermDetail getCourseTermDetail = _courseTermRepository.GetCourseTermDetail(courseTermId);
                text = text.Replace("{courseTerm}", string.Format("{0} {1}", getCourseTermDetail.ActiveFrom, getCourseTermDetail.ActiveTo));
            }

            return text;
        }


    }
}
