using Model.Functions.User;
using Model.Tables.Edu;
using System.Collections.Generic;
using WebModel.User;

namespace EduFacade.UserFacade.Convertors
{
    public interface IUserConvertor
    {
        User ConvertToBussinessEntity(AddUserDto createUserDto);
        UpdateUser ConvertToBussinessEntity(UpdateUserDto userUpdateDto);
        LoginUserDto ConvertToWebModel(LoginUser loginUser);
        GetUserDetailDto ConvertToWebModel(GetUserDetail getUserDetail, HashSet<GetUserAddress> getUserAddress);

    }
}