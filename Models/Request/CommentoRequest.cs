﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models
{
    public partial class CommentoRequest
    { 
     
        public string Content { get; set; }
        public DateTime? Timestamp { get; set; }
        public string UserId { get; set; }
        public int? PostId { get; set; }
    }
}