using EduCore.DataTypes;

namespace EduCore.EduOperation.SendMessage
{
    public class DetailSendMessageOperation : BaseOperation
    {
        public DetailSendMessageOperation() : base("DETAIL_SEND_MESSAGE")
        {
            OrganizationAdministrator = true;
        }
    }
}