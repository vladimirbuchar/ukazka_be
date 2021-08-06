using System;
using WebModel.Shared;

namespace WebModel.CodeBook
{
    public class GetCodeBookItemsDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string SystemIdentificator { get; set; }
        public bool Disabled { get; set; } = false;
    }
}
