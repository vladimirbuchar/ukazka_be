using Core.DataTypes;
using Core.Extension;
using EduRepository.UserRepository;
using Model.Functions.User;
using Model.Tables.Edu;
using Model.Tables.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.UserService
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            user.IsActive = false;
            _userRepository.SaveEntity(user);
            SetUserToken(user);
            return user;
        }
        public LoginUser GetUserToken(string userEmail, string password)
        {
            if (userEmail == null || password == null)
            {
                return null;
            }
            LoginUser user = _userRepository.GetUserToken(userEmail, password.GetHashString());
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void SetUserToken(User user)
        {
            Person person = user.Person;
            user.UserToken = string.Format("{0}{6}{1}{6}{2}{6}{3}{6}{4}{6}{5}{6}{7}{6}{8}{6}", user.Id, user.UserEmail, user.UserPassword, person.FirstName, person.LastName, person.SecondName, "#", DateTime.Now, user.SystemIdentificator).GetHashString().ReverseText();
            _userRepository.SaveEntity(user);
        }
        public void ActivateUser(Guid userId)
        {
            _userRepository.ActivateUser(userId);
        }

        public void DeleteUser(Guid userId)
        {
            _userRepository.DeleteEntity<User>(userId);
        }

        public GetUserDetail GetUserDetail(Guid id)
        {
            return _userRepository.GetUserDetail(id);
        }

        public void UpdateUser(UpdateUser user)
        {
            _userRepository.UpdateUser(user);
        }

        public void ChangePassword(Guid userId, string newPassword)
        {
            User user = _userRepository.GetEntity<User>(userId);
            if (user != null)
            {
                user.UserPassword = newPassword.GetHashString();
                _userRepository.SaveEntity(user);
            }
        }

        public void SetUserToken(Guid userId)
        {
            User user = _userRepository.GetEntity<User>(userId);
            SetUserToken(user);
        }
        public CheckUserEmailExist CheckUserEmailExist(string email)
        {
            return _userRepository.CheckUserEmailExist(email);
        }
        public void ValidatePersonName(string firstName, string lastName, Result validate)
        {
            if (firstName.IsNullOrEmptyWithTrim())
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "FIRST_NAME_IS_EMPTY"));
            }
            if (lastName.IsNullOrEmptyWithTrim())
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "LAST_NAME_IS_EMPTY"));
            }
        }

        public void ValidateEmail(string email, Guid id, Result validate)
        {
            email = email?.Trim();
            if (string.IsNullOrEmpty(email))
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "EMAIL_IS_EMPTY"));
            }
            CheckUserEmailExist user = CheckUserEmailExist(email);
            bool exist = user == null ? false : user?.Id != id;
            if (exist)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "EMAIL_EXIST", email));
            }
            if (!email.IsValidEmail())
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "EMAIL_IS_NOT_VALID", email));
            }
        }
        public void ValidatePassword(string password1, string password2, Result validate)
        {
            password1 = password1?.Trim();
            password2 = password2?.Trim();
            if (string.IsNullOrEmpty(password2) || string.IsNullOrEmpty(password1))
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "PASSWORD_IS_EMPTY"));
            }
            if (password1 != password2)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "PASSWORD_ARE_DIFFERENT"));
            }
        }
        public void ChangePasswordValidate(Guid userId, string oldPassword, Result validate)
        {
            User user = _userRepository.GetEntity<User>(userId);
            if (user.UserPassword != oldPassword.GetHashString())
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "OLD_PASSWORD_IS_BAD"));
            }
        }


        public HashSet<GetUserAddress> GetUserAddresses(Guid personId)
        {
            return _userRepository.GetUserAddress(personId);
        }

        public void ValidatePersonAddresses(List<Address> addresses, Result validate)
        {
            var duplicates = addresses.Select(x => x.AddressType.Id).GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();
            if (duplicates.Count > 0)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, "USER", "DUPLICATE_ADDRESS_TYPE"));
            }
        }

        public GetUserDetail GetUserDetail(string email)
        {
            return _userRepository.GetUserDetail(email);
        }

        public void AddUserByEmail(string email, UserRole userRole, string userPassword)
        {
            AddUserByEmail(email, userRole, userPassword, "", "");
        }
        public void AddUserByEmail(string email, UserRole userRole, string userPassword, string firstName, string lastName)
        {
            AddUser(new User()
            {
                UserEmail = email,
                Person = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SecondName = "",
                },
                UserRole = userRole,
                UserPassword = userPassword.GetHashString()
            });
        }

        public void SetFacebookId(Guid userId, string facebookId, string avatarUrl)
        {
            _userRepository.SetFacebookId(userId, facebookId, avatarUrl);
        }

        public void SetGoogleId(Guid userId, string googleId, string avatarUrl)
        {
            _userRepository.SetGoogleId(userId, googleId, avatarUrl);
        }

        public LoginUser GetTokenByFacebookId(Guid userId, string facebookId)
        {
            return _userRepository.GetTokenByFacebookId(userId, facebookId);
        }

        public LoginUser GetTokenByGoogleId(Guid userId, string googleId)
        {
            return _userRepository.GetTokenByGoogleId(userId, googleId);
        }

        public void SetNewPassword(Guid linkId, string password)
        {
            _userRepository.SetNewPassword(linkId, password.GetHashString());
        }
    }
}

