using Core.DataTypes;
using EduRepository.SendMessageRepository;
using Model.Functions.SendMessage;
using System;
using System.Collections.Generic;

namespace EduServices.CertificateService
{
    public class CourseMaterialService : BaseService, ICourseMaterialService
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository;
        public CourseMaterialService(ICourseMaterialRepository courseMaterialRepository)
        {
            _courseMaterialRepository = courseMaterialRepository;
        }

        public Guid AddCourseMaterial(AddCourseMaterial addCourseMaterial)
        {
            return _courseMaterialRepository.AddCourseMaterial(addCourseMaterial);
        }

        public void DeleteCourseMaterial(Guid courseMaterialId)
        {
            _courseMaterialRepository.DeleteEntity<Model.Tables.Edu.CourseMaterial>(courseMaterialId);
        }

        public GetCourseMaterialDetail GetCourseMaterialDetail(Guid courseMaterialId)
        {
            return _courseMaterialRepository.GetCourseMaterialDetail(courseMaterialId);
        }

        public HashSet<GetCourseMaterialInOrganization> GetCourseMaterialInOrganization(Guid organizationId)
        {
            return _courseMaterialRepository.GetCourseMaterialInOrganization(organizationId);
        }

        public HashSet<GetFiles> GetFiles(Guid courseMaterialId)
        {
            return _courseMaterialRepository.GetFiles(courseMaterialId);
        }

        public void UpdateCourseMaterial(UpdateCourseMaterial updateCourseMaterial)
        {
            _courseMaterialRepository.UpdateCourseMaterial(updateCourseMaterial);
        }

        public void ValidateName(string name, Result result)
        {
            if (string.IsNullOrEmpty(name))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_MATERIAL", "NAME_IS_EMPTY"));
            }
        }
    }
}
