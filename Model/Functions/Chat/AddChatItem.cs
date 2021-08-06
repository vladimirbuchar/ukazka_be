using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Functions.Chat
{
    public class AddChatItem
    {
        public Guid UserId { get; set; }
        public Guid CourseTermId { get; set; }
        public Guid? ParentId { get; set; }
        public string Text { get; set; }
    }
    public class UpdateChatItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
    public class GetAllChatItem: SqlFunction
    {
        public GetAllChatItem()
        {
            Answers = new HashSet<GetAllChatItem>();
        }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid ParentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string AvatarUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public bool IsAuthor { get; set; }
        public HashSet<GetAllChatItem> Answers { get; set; }
    }
}
