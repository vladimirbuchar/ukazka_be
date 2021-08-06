﻿using Core.Extension;
using System;
using System.Collections.Generic;
using WebModel.Shared;

namespace WebModel.Answer
{
    public class GetAllChatItemDto : BaseDto
    {
        public GetAllChatItemDto()
        {
            Answers = new HashSet<GetAllChatItemDto>();
        }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid ParentId { get; set; }
        public Guid UserId { get; set; }
        public bool IsAvatarUrl { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public DateTime Date { get; set; }
        public bool IsAuthor { get; set; }
        public string FullName =>
            FirstName.IsNullOrEmptyWithTrim() && SecondName.IsNullOrEmptyWithTrim() && LastName.IsNullOrEmptyWithTrim() ? string.Empty :
            SecondName.IsNullOrEmptyWithTrim() ?
            string.Format("{0} {1}", FirstName.Trim(), LastName.Trim()) :
            string.Format("{0} {1} {2}", FirstName.Trim(), SecondName.Trim(), LastName.Trim());
        public HashSet<GetAllChatItemDto> Answers { get; set; }
    }
}
