using System;
using WebModel.Shared;

namespace WebModel.Note
{
    public class AddNoteDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public string Text { get; set; }
        public string UserAccessToken { get; set; }
        public Guid NoteType { get; set; }
        public Guid CourseLessonItem { get; set; }
        public string NoteName { get; set; }

    }
    public class SaveTableAsNoteDto: BaseDto, IBaseDtoWithUserAccessToken
    {
        public string Img { get; set; }
        public Guid CourseLessonItem { get; set; }
        public string UserAccessToken { get; set; }
    }
    public class UpdateNoteDto : BaseDto, IBaseDtoWithUserAccessToken
    {
        public Guid NoteId { get; set; }
        public string Text { get; set; }
        public string UserAccessToken { get; set; }
        public string NoteName { get; set; }
    }
    public class GetMyNoteDto: BaseDto
    {
        public Guid Id { get; set; }
        public string NoteType { get; set; }
        public string NoteName { get; set; }
    }
    public class GetNoteDetailDto: BaseDto
    {
        public Guid Id { get; set; }
        public string NoteType { get; set; }
        public string NoteName { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }
    }
    public class SaveImageNoteDto: AddNoteDto
    {
        public string Img { get; set; }
    }
    public class UpdateNoteImageDto: UpdateNoteDto
    {
        public string Img { get; set; }
    }
}
