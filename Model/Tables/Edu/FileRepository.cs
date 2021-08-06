﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_FileRepository")]
    public class FileRepository : TableModel
    {
        public Guid ObjectOwner { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
    }
}