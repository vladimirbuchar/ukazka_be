using System;

namespace WebModel.Student
{
    public class GetManagedCourseDto
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public Guid OrganizationId { get; set; }
        public bool IsOrganizationOwner { get; set; }
        public bool IsOrganizationAdministrator { get; set; }
        public bool IsCourseAdministrator { get; set; }
        public bool IsCourseEditor { get; set; }



    }
}
