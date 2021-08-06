using System;

namespace Model.Functions.UserInOrganization
{
    public class AddStudyHours
    {
        public Guid OrganizationId { get; set; }
        public Guid ActiveFromId { get; set; }
        public Guid ActiveToId { get; set; }
        public int Position { get; set; }
        public int LessonLength { get; set; }
    }
    public class UpdateStudyHours
    {
        public Guid Id { get; set; }
        public Guid ActiveFromId { get; set; }
        public Guid ActiveToId { get; set; }
        public int Position { get; set; }
    }
    public class GetStudyHours : SqlFunction
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid ActiveFromId { get; set; }
        public string ActiveFrom { get; set; }
        public Guid ActiveToId { get; set; }
        public string ActiveTo { get; set; }
        public int Position { get; set; }
    }
}
