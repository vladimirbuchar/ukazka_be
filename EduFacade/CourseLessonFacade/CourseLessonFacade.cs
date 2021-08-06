using Core.DataTypes;
using EduFacade.CourseLessonFacade.Convertor;
using EduServices.CourseLessonService;
using EduServices.FileUploadService;
using Model.Functions.CourseLesson;
using Model.Functions.File;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.IO;
using WebModel.CourseLesson;

namespace EduFacade.CourseLessonFacade
{
    public class CourseLessonFacade : BaseFacade, ICourseLessonFacade
    {
        private readonly ICourseLessonService _courseLessonService;
        private readonly ICourseLessonConvertor _courseLessonConvertor;
        private readonly IFileUploadService _fileUploadService;
        public CourseLessonFacade(ICourseLessonService courseLessonService, ICourseLessonConvertor courseLessonConvertor, IFileUploadService fileUploadService)
        {
            _courseLessonService = courseLessonService;
            _courseLessonConvertor = courseLessonConvertor;
            _fileUploadService = fileUploadService;
        }

        public Result AddCourseLesson(AddCourseLessonDto addCourseLessonDto)
        {
            Result result = Validate(addCourseLessonDto);
            if (result.IsOk)
            {
                AddCourseLesson addCourseLesson = _courseLessonConvertor.ConvertToBussinessEntity(addCourseLessonDto);
                return new Result<Guid>()
                {
                    Data = _courseLessonService.AddCourseLesson(addCourseLesson)
                };
            }
            return result;
        }
        private Result Validate(AddCourseLessonDto addCourseLessonDto)
        {
            Result result = new Result();
            _courseLessonService.ValidateCourseLessonName(addCourseLessonDto.Name, result);
            return result;
        }

        public void UpdatePositionCourseLesson(UpdatePositionCourseLessonDto updatePositionCourseLesson)
        {
            int position = 0;
            foreach (string item in updatePositionCourseLesson.Ids)
            {
                _courseLessonService.UpdatePositionCourseLesson(new UpdatePositionCourseLesson()
                {
                    Id = Guid.Parse(item),
                    NewPosition = position
                });
                position++;
            }
        }

        public void DeleteCourseLesson(Guid courseLessonId)
        {
            _courseLessonService.DeleteCourseLesson(courseLessonId);
        }

        public HashSet<GetAllLessonInCourseDto> GetAllLessonInCourse(Guid courseId)
        {
            return _courseLessonConvertor.ConvertToWebModel(_courseLessonService.GetAllLessonInCourse(courseId));
        }
        public GetCourseLessonDetailDto GetCourseLessonDetail(Guid courseLessonId)
        {
            return _courseLessonConvertor.ConvertToWebModel(_courseLessonService.GetCourseLessonDetail(courseLessonId));
        }

        public Result UpdateCourseLesson(UpdateCourseLessonDto updateCourseLessonDto)
        {
            Result result = Validate(updateCourseLessonDto);
            if (result.IsOk)
            {
                UpdateCourseLesson updateCourseLesson = _courseLessonConvertor.ConvertToWebModel(updateCourseLessonDto);
                _courseLessonService.UpdateCourseLesson(updateCourseLesson);
            }
            return result;
        }
        private Result Validate(UpdateCourseLessonDto updateCourseLessonDto)
        {
            Result result = new Result();
            _courseLessonService.ValidateCourseLessonName(updateCourseLessonDto.Name, result);
            return result;
        }

        public void ImportCourseLessonFromPowerPoint(ImportCourseLessonFromPowerPointDto importCourseLessonFromPowerPointDto)
        {
            GetFileDetail getFileDetail = _fileUploadService.GetFileDetail(importCourseLessonFromPowerPointDto.FileId);
            Guid courseLessonId = _courseLessonService.AddCourseLesson(new AddCourseLesson()
            {
                MaterialId = importCourseLessonFromPowerPointDto.ObjectOwner,
                Name = Path.GetFileNameWithoutExtension(getFileDetail.OriginalFileName),
                Description = string.Empty,
                Type = CourseLessonType.COURSE_ITEM_POWER_POINT,
                PowerPointFile = string.Format("{0}/{1}", getFileDetail.ObjectOwner, getFileDetail.FileName)
            });
            /* List<PowerPointSlide> powerPointSlides = _fileUploadService.LoadPowerPointFile(getFileDetail.ObjectOwner.ToString(), getFileDetail.FileName);
            foreach (var slide in powerPointSlides)
            {
                _courseLessonItemService.AddCourseLessonItem(new Model.Functions.CourseLessonItem.AddCourseLessonItem()
                {
                    CourseLessonId = courseLessonId,
                    Name = slide.Name,
                    Html = string.Join("", slide.Text),
                    TemplateId = _courseLessonItemTemplates.FirstOrDefault(x=>x.SystemIdentificator == CourseLessonItemTemplateValues.POWER_POINT).Id,
                    Description = ""
                });
            }*/
        }
    }
}
