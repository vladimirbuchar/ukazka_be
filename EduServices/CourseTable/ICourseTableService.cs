using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model.Functions.File;
using System;
using System.Collections.Generic;

namespace EduServices.FileUploadService
{
    public interface ICourseTableService : IBaseService
    {
        void UpdateActualTable(Guid courseTermid, string img);
        string GetActualTable(Guid courseTermid);
    }
}
