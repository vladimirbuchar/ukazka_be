using System;

namespace Model.Functions.Note
{
    public class AddNote
    {
        public string Text { get; set; }
        public Guid NoteType { get; set; }
        public Guid CourseLessonItem { get; set; }
        public Guid UserId { get; set; }
        public string NoteName { get; set; }
        public Guid FileName { get; set; }
    }
    public class UpdateNote
    {
        public Guid NoteId { get; set; }
        public string Text { get; set; }
        public string NoteName { get; set; }
        public Guid FileName { get; set; }


    }
    public class GetMyNote:SqlFunction
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string NoteName { get; set; }
    }
    public class GetNoteDetail : SqlFunction
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string NoteName { get; set; }
        public string Text { get; set; }
        public string FileName { get; set; }
    }
}
