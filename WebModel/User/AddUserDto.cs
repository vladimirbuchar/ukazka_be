using Core.Extension;
using WebModel.Organization;
using WebModel.Shared;

namespace WebModel.User
{
    public class AddUserDto : BaseDto, IBaseDtoWithClientCulture
    {
        public AddUserDto()
        {
            Organization = new AddOrganizationDto();
        }
        private string hashPassword;
        private string hashPassword2;
        public string UserPassword
        {
            get => hashPassword;
            set => hashPassword = value.GetHashString();
        }
        public string UserPassword2
        {
            get => hashPassword2;
            set => hashPassword2 = value.GetHashString();
        }
        public string UserEmail { get; set; }
        public PersonDto Person { get; set; } = new PersonDto();
        public string ClientCulture { get; set; }
        public bool CreateNewOrganization { get; set; }

        public AddOrganizationDto Organization { get; set; }
        public string OrganizationId { get; set; }

    }
}
