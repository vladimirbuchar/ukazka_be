using System;
using WebModel.Shared;

namespace WebModel.Student
{
    public class AddStudentToCourseTermDto : BaseDto, IBaseDtoWithUserAccessToken, IBaseDtoWithClientCulture
    {
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid CourseTermId { get; set; }
        public string UserAccessToken { get; set; }
        public string ClientCulture { get; set; }
    }
}
