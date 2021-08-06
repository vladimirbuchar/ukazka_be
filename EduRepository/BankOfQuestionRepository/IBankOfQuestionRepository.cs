using Model.Functions.BankOfQuestion;
using System;
using System.Collections.Generic;
namespace EduRepository.CourseRepository
{
    public interface IBankOfQuestionRepository : IBaseRepository
    {
        HashSet<GetBankOfQuestionInOrganization> GetBankOfQuestionInOrganization(Guid organizationId);
        GetBankOfQuestionDetail GetBankOfQuestionDetail(Guid courseId);
        Guid AddBankOfQuestion(AddBankOfQuestion addBankOfQuestion);
        void UpdateBankOfQuestion(UpdateBankOfQuestion updateBankOfQuestion);
    }
}
