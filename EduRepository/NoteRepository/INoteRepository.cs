using Model.Functions.Answer;
using Model.Functions.Note;
using System;
using System.Collections.Generic;

namespace EduRepository.NoteRepository
{
    public interface INoteRepository : IBaseRepository
    {
        Guid AddNote(AddNote addNote);
        void UpdateNote(UpdateNote updateNote);
        HashSet<GetMyNote> GetMyNote(Guid userId);
        GetNoteDetail GetNoteDetail(Guid noteId);

    }
}
