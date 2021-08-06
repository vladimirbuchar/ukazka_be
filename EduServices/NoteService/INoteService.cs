using Core.DataTypes;
using Model.Functions.Course;
using Model.Functions.Note;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.NoteService
{
    public interface INoteService : IBaseService
    {
        Guid AddNote(AddNote addNote);
        void UpdateNote(UpdateNote updateNote);
        HashSet<GetMyNote> GetMyNote(Guid userId);
        GetNoteDetail GetNoteDetail(Guid noteId);
        void DeleteNote(Guid noteId);
    }
}
