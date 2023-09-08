﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UniConnect.Repo.EF.Models
{
    public partial class Post
    {
        public Post()
        {
            UserNavigation = new HashSet<AspNetUsers>();
            Commenti = new HashSet<Commento>(); // Aggiungi questa riga
        }

        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime? Timestamp { get; set; }
        public string UserId { get; set; }
        public int? FileId { get; set; }
        public int? GroupId { get; set; }

        public virtual FileStorage File { get; set; }
        public virtual Gruppo Group { get; set; }
        public virtual AspNetUsers User { get; set; }

        public virtual ICollection<AspNetUsers> UserNavigation { get; set; }
        public virtual ICollection<Commento> Commenti { get; set; } // Aggiungi questa riga
    }
}
