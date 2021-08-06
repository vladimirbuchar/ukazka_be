using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class AddSendMessageOperation : BaseOperation
    {
        public AddSendMessageOperation() : base("ADD_SEND_MESSAGE")
        {
            OrganizationAdministrator = true;
        }

    }
}