using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class DeleteSendMessageOperation : BaseOperation
    {
        public DeleteSendMessageOperation() : base("DELETE_SEND_MESSAGE")
        {
            OrganizationAdministrator = true;
        }
    }
}