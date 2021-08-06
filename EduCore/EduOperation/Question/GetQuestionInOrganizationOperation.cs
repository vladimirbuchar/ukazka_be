using EduCore.DataTypes;

namespace EduCore.EduOperation.Question
{
    public class GetQuestionInOrganizationOperation : BaseOperation
    {
        public GetQuestionInOrganizationOperation() : base("GET_QUESTIONS_IN_BANK")
        {
            OrganizationAdministrator = true;
            CourseAdministrator = true;
            CourseEditor = true;
        }
    }
}