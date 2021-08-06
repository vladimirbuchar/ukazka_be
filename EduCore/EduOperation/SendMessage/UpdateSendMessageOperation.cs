using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class UpdateSendMessageOperation : BaseOperation
    {


        public UpdateSendMessageOperation() : base("UPDATE_SEND_MESSAHE")
        {
            OrganizationAdministrator = true;
        }
    }
}