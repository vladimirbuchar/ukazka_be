using Core.DataTypes;
using EduFacade.NoteFacade.Convertor;
using EduServices.CodeBookService;
using EduServices.FileUploadService;
using EduServices.NoteService;
using Model.Functions.Note;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using WebModel.Note;
using System.Linq;
namespace EduFacade.NoteFacade
{
    public class NoteFacade : BaseFacade, INoteFacade
    {
        private readonly INoteService _noteService;
        private readonly INoteConvertor _noteConvertor;
        private readonly IFileUploadService _fileUploadService;
        private readonly HashSet<NoteType> _noteType;

        public NoteFacade(INoteService noteService, INoteConvertor noteConvertor, IFileUploadService fileUploadService, ICodeBookService codeBookService)
        {
            _noteService = noteService;
            _noteConvertor = noteConvertor;
            _fileUploadService = fileUploadService;
            _noteType = codeBookService.GetCodeBookItems<NoteType>();
        }

        public Result<Guid> AddNote(AddNoteDto addNoteDto, Guid userId)
        {
            AddNote addNote = _noteConvertor.ConvertToBussinessEntity(addNoteDto);
            addNote.UserId = userId;
            return new Result<Guid>()
            {
                Data = _noteService.AddNote(addNote)
            };

        }

        public void DeleteNote(Guid noteId)
        {
            _noteService.DeleteNote(noteId);
        }

        public HashSet<GetMyNoteDto> GetMyNote(Guid userId)
        {
            return _noteConvertor.ConvertToWebModel(_noteService.GetMyNote(userId));
        }

        public GetNoteDetailDto GetNoteDetail(Guid noteId)
        {
            return _noteConvertor.ConvertToWebModel(_noteService.GetNoteDetail(noteId));
        }

        public Result SaveFile(SaveImageNoteDto saveImageNoteDto, Guid userId)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(saveImageNoteDto.Img,"note");

            AddNote addNote = _noteConvertor.ConvertToBussinessEntity(saveImageNoteDto);
            addNote.UserId = userId;
            addNote.FileName = fileName;
            return new Result<Guid>()
            {
                Data = _noteService.AddNote(addNote)
            };
        }

        public Result<Guid> SaveTableAsNote(SaveTableAsNoteDto saveTableAsNoteDto, Guid userId)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(saveTableAsNoteDto.Img, "note");
            AddNote addNote = new AddNote()
            {
                CourseLessonItem = saveTableAsNoteDto.CourseLessonItem,
                FileName = fileName,
                NoteName = DateTime.Now.ToString(),
                NoteType = _noteType.FirstOrDefault(x => x.SystemIdentificator == NoteTypeValues.NOTE_TYPE_DRAW).Id,
                Text = "",
                UserId = userId
            };
            return new Result<Guid>()
            {
                Data = _noteService.AddNote(addNote)
            };

        }

        public void UpdateNote(UpdateNoteDto updateNoteDto)
        {
            _noteService.UpdateNote(_noteConvertor.ConvertToBussinessEntity(updateNoteDto));
        }

        public void UpdateNoteImage(UpdateNoteImageDto updateNoteImageDto)
        {
            Guid fileName = _fileUploadService.SaveFilePngFile(updateNoteImageDto.Img,"note");
            UpdateNote updateNote = _noteConvertor.ConvertToBussinessEntity(updateNoteImageDto);
            updateNote.FileName = fileName;
            _noteService.UpdateNote(updateNote);


        }
    }
}
