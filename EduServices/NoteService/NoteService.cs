using Core.DataTypes;
using Core.Extension;
using EduRepository.CodeBookRepository;
using EduRepository.CourseRepository;
using EduRepository.NoteRepository;
using Model.Functions.Course;
using Model.Functions.Note;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;

namespace EduServices.NoteService
{
    public class NoteService : BaseService, INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Guid AddNote(AddNote addNote)
        {
            return _noteRepository.AddNote(addNote);
        }

        public void DeleteNote(Guid noteId)
        {
            _noteRepository.DeleteEntity<Note>(noteId);
        }

        public HashSet<GetMyNote> GetMyNote(Guid userId)
        {
            return _noteRepository.GetMyNote(userId);
        }

        public GetNoteDetail GetNoteDetail(Guid noteId)
        {
            return _noteRepository.GetNoteDetail(noteId);
        }

        public void UpdateNote(UpdateNote updateNote)
        {
            _noteRepository.UpdateNote(updateNote);
        }
    }
}
