using Model.Functions.User;
using WebModel.User;

namespace EduFacade.AuthFacade.Convertor
{
    public interface IAuthConvertor
    {
        GetUserByAccessTokenDto ConvertToWebModel(GetUserByAccessToken getUserByAccessToken);
    }
}
