using Core.DataTypes;
using EduFacade.CourseTermFacade.Convertor;
using EduServices.CertificateService;
using EduServices.ClassRoomService;
using EduServices.CodeBookService;
using EduServices.CourseLectorService;
using EduServices.CourseStudentService;
using EduServices.CourseTermService;
using EduServices.OrganizationService;
using Model.Functions;
using Model.Functions.CourseLector;
using Model.Functions.CourseStudent;
using Model.Functions.CourseTerm;
using Model.Functions.UserInOrganization;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModel.Course;
using WebModel.CourseTerm;

namespace EduFacade.CourseTermFacade
{
    public class CourseTermFacade : BaseFacade, ICourseTermFacade
    {
        private readonly ICourseTermService _courseTermService;
        private readonly IClassRoomService _classRoomService;
        private readonly ICourseTermConvertor _courseTermConvertor;
        private readonly ICourseLectorService _courseLectorService;
        private readonly ICodeBookService _codeBookService;
        private readonly HashSet<TimeTable> _timeTables;
        private readonly IStudentGroupService _studentGroupService;
        private readonly ICourseStudentService _courseStudentService;
        private readonly IOrganizationService _organizationService;

        public CourseTermFacade(ICodeBookService codeBookService, IClassRoomService classRoomService, ICourseTermService courseTermService, ICourseTermConvertor courseTermConvertor, ICourseLectorService courseLectorService, IStudentGroupService studentGroupService, ICourseStudentService courseStudentService, IOrganizationService organizationService)
        {
            _courseTermService = courseTermService;
            _classRoomService = classRoomService;
            _courseTermConvertor = courseTermConvertor;
            _courseLectorService = courseLectorService;
            _codeBookService = codeBookService;
            _timeTables = _codeBookService.GetCodeBookItems<TimeTable>();
            _studentGroupService = studentGroupService;
            _courseStudentService = courseStudentService;
            _organizationService = organizationService;
        }

        private Result Validate(AddCourseTermDto addCourseTermDto)
        {
            Result validation = new Result();
            _courseTermService.ValidateCourseDate(addCourseTermDto.ActiveFrom, addCourseTermDto.ActiveTo, addCourseTermDto.RegistrationFrom, addCourseTermDto.RegistrationTo, validation);
            GetClassRoomDetail classRoomDetail = null;
            classRoomDetail = _classRoomService.GetClassRoomDetail(addCourseTermDto.ClassRoomId.GetValueOrDefault());

            _courseTermService.StudentValidation(addCourseTermDto.MinimumStudents, addCourseTermDto.MaximumStudents, classRoomDetail != null ? classRoomDetail.MaxCapacity : 0, validation);
            int priorityFrom = _timeTables.FirstOrDefault(x => x.Id == addCourseTermDto.TimeFromId).Priority;
            int priorityTo = _timeTables.FirstOrDefault(x => x.Id == addCourseTermDto.TimeToId).Priority;
            if (priorityTo < priorityFrom)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "END_TIME_IS_LESS_THAN_START_TIME"));
            }
            return validation;
        }

        private Result Validate(UpdateCourseTermDto updateCourseTermDto)
        {
            Result validation = new Result();
            _courseTermService.ValidateCourseDate(updateCourseTermDto.ActiveFrom, updateCourseTermDto.ActiveTo, updateCourseTermDto.RegistrationFrom, updateCourseTermDto.RegistrationTo, validation);
            GetClassRoomDetail classRoomDetail = _classRoomService.GetClassRoomDetail(updateCourseTermDto.ClassRoomId ?? Guid.Empty);
            _courseTermService.StudentValidation(updateCourseTermDto.MinimumStudents, updateCourseTermDto.MaximumStudents, classRoomDetail != null ? classRoomDetail.MaxCapacity : 0, validation);
            int priorityFrom = _timeTables.FirstOrDefault(x => x.Id == updateCourseTermDto.TimeFromId).Priority;
            int priorityTo = _timeTables.FirstOrDefault(x => x.Id == updateCourseTermDto.TimeToId).Priority;
            if (priorityTo < priorityFrom)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, "COURSE_TERM", "END_TIME_IS_LESS_THAN_START_TIME"));
            }
            return validation;
        }

        public Result AddCourseTerm(AddCourseTermDto addCourseTermDto, Guid organizationId)
        {
            if (addCourseTermDto.ClassRoomId == null)
            {
                addCourseTermDto.ClassRoomId = _classRoomService.GetOnlineClassRoom(organizationId);
            }
            Result result = Validate(addCourseTermDto);
            if (result.IsOk)
            {
                AddCourseTerm addCourseTerm = _courseTermConvertor.ConvertToBussinessEntity(addCourseTermDto);

                if (addCourseTerm.OrganizationStudyHourId != null)
                {
                    HashSet<GetStudyHours> getOrganizationSetting = _organizationService.GetStudyHours(organizationId);
                    addCourseTerm.TimeFromId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveFromId;
                    addCourseTerm.TimeToId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveToId;
                }

                Guid termGuid = _courseTermService.AddCourseTerm(addCourseTerm);
                foreach (string item in addCourseTermDto.Lector)
                {
                    _courseLectorService.AddCourseLector(new AddCourseLector()
                    {
                        CourseLector = Guid.Parse(item),
                        CourseTerm = termGuid
                    });
                }
                foreach (string item in addCourseTermDto.StudentGroup)
                {
                    _courseTermService.AddStudentGroupToTerm(new AddStudentGroupToTerm()
                    {
                        CourseTermId = termGuid,
                        StudentGroupId = Guid.Parse(item)
                    });
                }
                _courseTermService.GenerateTimeTable(addCourseTermDto.ActiveFrom.GetValueOrDefault(), addCourseTermDto.ActiveTo.GetValueOrDefault(), addCourseTermDto.TimeFromId, addCourseTermDto.TimeToId, new List<bool>()
                {
                    addCourseTermDto.Monday,addCourseTermDto.Tuesday,addCourseTermDto.Wednesday,addCourseTermDto.Thursday,addCourseTermDto.Friday,addCourseTermDto.Saturday,addCourseTermDto.Sunday
                }, termGuid, addCourseTermDto.Lector, addCourseTermDto.ClassRoomId.GetValueOrDefault());
                return new Result<Guid>()
                {
                    Data = termGuid
                };
            }
            return result;
        }

        public HashSet<GetAllTermInCourseDto> GetAllTermInCourse(Guid courseId)
        {
            return _courseTermConvertor.ConvertToWebModel(_courseTermService.GetAllTermInCourse(courseId));
        }

        public GetCourseTermDetailDto GetCourseTermDetail(Guid courseTermId)
        {
            GetCourseTermDetail getCourseTermDetail = _courseTermService.GetCourseTermDetail(courseTermId);
            GetCourseTermDetailDto getCourseTermDetailDto = _courseTermConvertor.ConvertToWebModel(getCourseTermDetail);
            getCourseTermDetailDto.Lector = _courseLectorService.GetAllLectorCourseTerm(courseTermId).Select(x => x.Id).ToHashSet();
            getCourseTermDetailDto.StudentGroup = _courseTermService.GetAllStudentGroupInTerm(courseTermId).Select(x => x.StudentGroupId).ToHashSet();
            return getCourseTermDetailDto;
        }

        public Result UpdateCourseTerm(UpdateCourseTermDto updateCourseTermDto, Guid organizationId, Guid userId)
        {
            if (updateCourseTermDto.ClassRoomId == null)
            {
                updateCourseTermDto.ClassRoomId = _classRoomService.GetOnlineClassRoom(organizationId);
            }
            Result validate = Validate(updateCourseTermDto);
            if (validate.IsOk)
            {
                HashSet<CourseTermLector> courseTermLectors = _courseLectorService.GetAllLectorCourseTerm(updateCourseTermDto.Id);
                foreach (CourseTermLector item in courseTermLectors)
                {
                    if (!updateCourseTermDto.Lector.Contains(Convert.ToString(item.Id)))
                    {
                        _courseLectorService.DeleteCourseTermLector(item.LectorId);
                    }
                }
                foreach (string item in updateCourseTermDto.Lector)
                {
                    if (!courseTermLectors.Select(x => x.Id).ToHashSet().Contains(Guid.Parse(item)))
                    {
                        _courseLectorService.AddCourseLector(new AddCourseLector()
                        {
                            CourseLector = Guid.Parse(item),
                            CourseTerm = updateCourseTermDto.Id
                        });
                    }
                }
                HashSet<GetAllStudentGroupInTerm> getAllStudentGroupInTerms = _courseTermService.GetAllStudentGroupInTerm(updateCourseTermDto.Id);
                HashSet<GetAllStudentInCourseTerm> getAllStudentInCourseTerms = _courseStudentService.GetAllStudentInCourseTerm(updateCourseTermDto.Id);
                foreach (GetAllStudentGroupInTerm item in getAllStudentGroupInTerms)
                {
                    if (!updateCourseTermDto.StudentGroup.Contains(Convert.ToString(item.StudentGroupId)))
                    {
                        HashSet<GetAllStudentInGroup> getAllStudentInGroups = _studentGroupService.GetAllStudentInGroup(item.StudentGroupId);
                        foreach (GetAllStudentInGroup x in getAllStudentInGroups)
                        {
                            Guid deleteId = getAllStudentInCourseTerms.FirstOrDefault(y => y.StudentId == x.StudentId).Id;
                            if (deleteId != null)
                            {
                                _courseStudentService.DeleteStudentFromCourseTerm(deleteId);
                            }
                        }
                        _courseTermService.DeleteStudentGroupFromTerm(item.Id);
                    }
                }
                foreach (string item in updateCourseTermDto.StudentGroup)
                {
                    if (!getAllStudentGroupInTerms.Select(x => x.StudentGroupId).ToHashSet().Contains(Guid.Parse(item)))
                    {
                        HashSet<GetAllStudentInGroup> getAllStudentInGroups = _studentGroupService.GetAllStudentInGroup(Guid.Parse(item));
                        foreach (GetAllStudentInGroup x in getAllStudentInGroups)
                        {
                            if (_courseStudentService.GetAllStudentInCourseTerm(updateCourseTermDto.Id).FirstOrDefault(y => y.StudentId == x.StudentId) == null)
                            {
                                _courseStudentService.AddStudentToCourseTerm(new Model.Functions.CourseStudent.AddStudentToCourseTerm()
                                {
                                    CourseTermId = updateCourseTermDto.Id,
                                    UserId = x.StudentId
                                });
                            }
                        }
                        _courseTermService.AddStudentGroupToTerm(new AddStudentGroupToTerm()
                        {
                            CourseTermId = updateCourseTermDto.Id,
                            StudentGroupId = Guid.Parse(item)
                        });

                    }
                }


                UpdateCourseTerm updateCourseTerm = _courseTermConvertor.ConvertToWebModel(updateCourseTermDto);

                if (updateCourseTerm.OrganizationStudyHourId != null)
                {
                    HashSet<GetStudyHours> getOrganizationSetting = _organizationService.GetStudyHours(organizationId);
                    updateCourseTerm.TimeFromId = getOrganizationSetting.FirstOrDefault(x => x.Id == updateCourseTerm.OrganizationStudyHourId).ActiveFromId;
                    updateCourseTerm.TimeToId = getOrganizationSetting.FirstOrDefault(x => x.Id == updateCourseTerm.OrganizationStudyHourId).ActiveToId;
                }

                GetCourseTermDetail getCourseTermDetail = _courseTermService.GetCourseTermDetail(updateCourseTerm.Id);
                _courseTermService.UpdateCourseTerm(updateCourseTerm);
                if (getCourseTermDetail.ActiveFrom != updateCourseTerm.ActiveFrom || getCourseTermDetail.ActiveTo != updateCourseTerm.ActiveTo || getCourseTermDetail.TimeFromId != updateCourseTerm.TimeFromId || getCourseTermDetail.TimeToId != updateCourseTerm.TimeToId
                    || getCourseTermDetail.Monday != updateCourseTerm.Monday || getCourseTermDetail.Tuesday != updateCourseTerm.Tuesday || getCourseTermDetail.Wednesday != updateCourseTerm.Wednesday
                    || getCourseTermDetail.Thursday != updateCourseTerm.Thursday || getCourseTermDetail.Friday != updateCourseTerm.Friday || getCourseTermDetail.Saturday != updateCourseTerm.Saturday
                    || getCourseTermDetail.Sunday != updateCourseTerm.Sunday
                    )
                {
                    HashSet<GetTimeTable> getTimeTables = _courseTermService.GetTimeTable(updateCourseTermDto.Id).Where(x => x.Date >= DateTime.Now).ToHashSet();
                    foreach (GetTimeTable item in getTimeTables)
                    {
                        _courseTermService.DeleteTimeTable(item.Id);
                    }
                    DateTime activeFrom = updateCourseTermDto.ActiveFrom.GetValueOrDefault().Date;
                    if (activeFrom < DateTime.Now.Date)
                    {
                        activeFrom = DateTime.Now.Date;
                    }
                    _courseTermService.GenerateTimeTable(activeFrom, updateCourseTermDto.ActiveTo.GetValueOrDefault(), updateCourseTermDto.TimeFromId, updateCourseTermDto.TimeToId, new List<bool>()
                    {
                        updateCourseTermDto.Monday,updateCourseTermDto.Tuesday,updateCourseTermDto.Wednesday,updateCourseTermDto.Thursday,updateCourseTermDto.Friday,updateCourseTermDto.Saturday,updateCourseTermDto.Sunday
                    }, updateCourseTermDto.Id, updateCourseTermDto.Lector, updateCourseTermDto.ClassRoomId.GetValueOrDefault());
                }
            }
            return validate;
        }

        public void DeleteCourseTerm(Guid courseTermId)
        {
            _courseTermService.DeleteCourseTerm(courseTermId);
        }
        public HashSet<GetTimeTableDto> GetTimeTable(Guid courseTermId)
        {
            return _courseTermConvertor.ConvertToWebModel(_courseTermService.GetTimeTable(courseTermId));
        }
        public void GenerateTimeTable(Guid courseTermId)
        {
            GetCourseTermDetail getCourseTermDetail = _courseTermService.GetCourseTermDetail(courseTermId);
            HashSet<GetTimeTable> getTimeTables = _courseTermService.GetTimeTable(courseTermId).Where(x => x.Date >= DateTime.Now).ToHashSet();
            foreach (GetTimeTable item in getTimeTables)
            {
                _courseTermService.DeleteTimeTable(item.Id);
            }
            DateTime activeFrom = getCourseTermDetail.ActiveFrom.Date;
            if (activeFrom < DateTime.Now.Date)
            {
                activeFrom = DateTime.Now.Date;
            }
            _courseTermService.GenerateTimeTable(activeFrom, getCourseTermDetail.ActiveTo.Date, getCourseTermDetail.TimeFromId, getCourseTermDetail.TimeToId, new List<bool>()
            {
                getCourseTermDetail.Monday,getCourseTermDetail.Tuesday,getCourseTermDetail.Wednesday,getCourseTermDetail.Thursday,getCourseTermDetail.Friday,getCourseTermDetail.Saturday,getCourseTermDetail.Sunday
            }, courseTermId, _courseLectorService.GetAllLectorCourseTerm(courseTermId).Select(x => x.Id.ToString()).ToList(), getCourseTermDetail.ClassRoomId);
        }

        public void CancelCourseTerm(Guid courseTermTimeTableId)
        {
            _courseTermService.CancelCourseTerm(courseTermTimeTableId);
        }
        public void RestoreCourseTerm(Guid courseTermTimeTableId)
        {
            _courseTermService.RestoreCourseTerm(courseTermTimeTableId);
        }
        public GetStudentAttendanceDto GetStudentAttendance(Guid courseTermId)
        {
            GetStudentAttendanceDto getStudentAttendanceDtos = new GetStudentAttendanceDto();
            HashSet<GetTimeTable> timeTable = _courseTermService.GetTimeTable(courseTermId).OrderBy(x => x.Date).ToHashSet();
            getStudentAttendanceDtos.TimeTable = timeTable;
            getStudentAttendanceDtos.Student = _courseStudentService.GetAllStudentInCourseTerm(courseTermId);
            HashSet<GetStudentAttendance> getStudentAttendances = _courseTermService.GetStudentAttendance(courseTermId);
            foreach (GetAllStudentInCourseTerm student in getStudentAttendanceDtos.Student)
            {
                Dictionary<Guid, bool> times = new Dictionary<Guid, bool>();
                foreach (GetTimeTable time in getStudentAttendanceDtos.TimeTable)
                {
                    getStudentAttendanceDtos.StudentAttendance.Add(new StudentAttendance()
                    {
                        TermId = time.Id,
                        StudentId = student.Id,
                        IsActive = getStudentAttendances.FirstOrDefault(x => x.CourseStudentId == student.Id && x.CourseTermDateId == time.Id) != null
                    });
                }
            }
            return getStudentAttendanceDtos;
        }

        public void SaveStudentAttendance(Guid studentId, Guid timeTableId, Guid courseTermId, bool isActive)
        {
            _courseTermService.SaveStudentAttendance(studentId, timeTableId, courseTermId, isActive);
        }

        public HashSet<GetStudentEvaluationDto> GetStudentEvaluation(Guid courseTermId)
        {
            return _courseTermConvertor.ConvertToWebModel(_courseTermService.GetStudentEvaluation(courseTermId));
        }

        public void AddStudentEvaluation(AddStudentEvaluationDto addStudentEvaluation)
        {
            _courseTermService.AddStudentEvaluation(_courseTermConvertor.ConvertToBussinessEntity(addStudentEvaluation));
        }
    }
}
