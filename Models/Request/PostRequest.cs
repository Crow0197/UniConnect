﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public partial class PostRequest
    {

        public string Content { get; set; }
        public DateTime? Timestamp { get; set; }
        public string UserId { get; set; }
        public int? GroupId { get; set; }
        public int? FileId { get; set; }

    }
}