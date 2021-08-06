using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class DetailStudentGroupOperation : BaseOperation
    {
        public DetailStudentGroupOperation() : base("DETAIL_STUDENT_GROUP")
        {
            OrganizationAdministrator = true;
        }
    }
    public class GetFilesOperation: BaseOperation
    {
        public GetFilesOperation() : base("GET_FILES")
        {
            OrganizationAdministrator = true;
        }
    }
    public class GetFilesStudentOperation: BaseOperation
    {
        public GetFilesStudentOperation():base("GET_FILES_STUDENT",true)
        {

        }
    }
}