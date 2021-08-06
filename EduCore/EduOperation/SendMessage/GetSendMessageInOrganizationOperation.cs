using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class GetSendMessageInOrganizationOperation : BaseOperation
    {
        public GetSendMessageInOrganizationOperation() : base("GET_SEND_MESSAGE_IN_ORGANIZATION")
        {
            OrganizationAdministrator = true;
        }
    }
}