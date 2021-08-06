using Model.Functions.Answer;
using System;
using System.Collections.Generic;

namespace EduRepository.AnswerRepository
{
    public interface ICourseTableRepository : IBaseRepository
    {
        void UpdateActualTable(Guid courseTermid, string img);
        string GetActualTable(Guid courseTermid);

    }
}
