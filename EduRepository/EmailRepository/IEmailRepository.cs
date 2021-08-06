using Model.Functions;

namespace EduRepository.EmailRepository
{
    public interface IEmailRepository : IBaseRepository
    {
        GetEmail GetEmail(string identificator);
    }
}
