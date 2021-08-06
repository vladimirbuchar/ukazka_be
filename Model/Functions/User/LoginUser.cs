using System;

namespace Model.Functions.User
{
    public class LoginUser : SqlFunction
    {
        public Guid Id { get; set; }
        public string UserToken { get; set; }
        public string AvatarUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
