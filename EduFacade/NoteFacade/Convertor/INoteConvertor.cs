using Model.Functions.Course;
using Model.Functions.CourseStudent;
using Model.Functions.CourseTest;
using Model.Functions.Note;
using System.Collections.Generic;
using WebModel.Course;
using WebModel.CourseTest;
using WebModel.Note;
using WebModel.Student;

namespace EduFacade.NoteFacade.Convertor
{
    public interface INoteConvertor
    {
        AddNote ConvertToBussinessEntity(AddNoteDto addNoteDto);
        UpdateNote ConvertToBussinessEntity(UpdateNoteDto updateNoteDto);
        HashSet<GetMyNoteDto> ConvertToWebModel(HashSet<GetMyNote> getMyNotes);
        GetNoteDetailDto ConvertToWebModel(GetNoteDetail getNoteDetail);


    }

}
