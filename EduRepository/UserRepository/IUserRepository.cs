using Model.Functions.User;
using System;
using System.Collections.Generic;

namespace EduRepository.UserRepository
{
    public interface IUserRepository : IBaseRepository
    {
        LoginUser GetUserToken(string email, string password);
        CheckUserEmailExist CheckUserEmailExist(string email);
        GetUserDetail GetUserDetail(Guid id);
        GetUserDetail GetUserDetail(string email);
        GetUserByAccessToken GetUserByAccessToken(string userAccessToken);
        HashSet<GetUserAddress> GetUserAddress(Guid personId);
        void UpdateUser(UpdateUser user);
        void SetFacebookId(Guid userId, string facebookId, string avatarUrl);
        void SetGoogleId(Guid userId, string googleId, string avatarUrl);
        LoginUser GetTokenByFacebookId(Guid userId, string facebookId);
        LoginUser GetTokenByGoogleId(Guid userId, string facebookId);
        void ActivateUser(Guid userId);
        void SetNewPassword(Guid linkId, string password);
    }
}
