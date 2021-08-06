using EduServices.CodeBookService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Model.Functions.Course;
using Model.Functions.CourseStudent;
using Model.Functions.CourseTest;
using Model.Functions.Note;
using Model.Tables.CodeBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebModel.Course;
using WebModel.CourseTest;
using WebModel.Note;
using WebModel.Student;

namespace EduFacade.NoteFacade.Convertor
{
    public class NoteConvertor : INoteConvertor
    {
        private readonly string _fileRepositoryPath;
        public NoteConvertor(IConfiguration configuration)
        {
            _fileRepositoryPath = string.Format("{0}{1}", configuration.GetSection("FileServerUrl").Value, "note/");
        }
        public AddNote ConvertToBussinessEntity(AddNoteDto addNoteDto)
        {
            return new AddNote()
            {
                CourseLessonItem = addNoteDto.CourseLessonItem,
                NoteType = addNoteDto.NoteType,
                Text = addNoteDto.Text,
                NoteName = addNoteDto.NoteName
            };
        }

        public UpdateNote ConvertToBussinessEntity(UpdateNoteDto updateNoteDto)
        {
            return new UpdateNote()
            {
                NoteId = updateNoteDto.NoteId,
                Text = updateNoteDto.Text,
                NoteName = updateNoteDto.NoteName
            };
        }

        public HashSet<GetMyNoteDto> ConvertToWebModel(HashSet<GetMyNote> getMyNotes)
        {
            return getMyNotes.Select(x => new GetMyNoteDto()
            {
                Id = x.Id,
                NoteName =x.NoteName,
                NoteType =x.Value
            }).ToHashSet();
        }

        public GetNoteDetailDto ConvertToWebModel(GetNoteDetail getNoteDetail)
        {
            return new GetNoteDetailDto()
            {
                Id = getNoteDetail.Id,
                NoteName = getNoteDetail.NoteName,
                NoteType = getNoteDetail.Value,
                Text = getNoteDetail.Text,
                FilePath = string.Format("{0}{1}.png", _fileRepositoryPath,getNoteDetail.FileName)
            };
        }
    }
}
