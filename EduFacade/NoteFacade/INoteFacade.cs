using Core.DataTypes;
using Model.Functions.CourseTest;
using System;
using System.Collections.Generic;
using WebModel.CourseTest;
using WebModel.Note;
using WebModel.Organization;
using WebModel.Student;

namespace EduFacade.NoteFacade
{
    public interface INoteFacade : IBaseFacade
    {
        Result<Guid> AddNote(AddNoteDto addNoteDto, Guid userId);
        Result<Guid> SaveTableAsNote(SaveTableAsNoteDto saveTableAsNoteDto, Guid userId);
        void UpdateNote(UpdateNoteDto updateNoteDto);
        HashSet<GetMyNoteDto> GetMyNote(Guid userId);
        GetNoteDetailDto GetNoteDetail(Guid noteId);
        void DeleteNote(Guid noteId);
        Result SaveFile(SaveImageNoteDto saveImageNoteDto, Guid userId);
        void UpdateNoteImage(UpdateNoteImageDto updateNoteImageDto);

    }
}
