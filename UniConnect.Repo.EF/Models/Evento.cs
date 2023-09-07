﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UniConnect.Repo.EF.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Group = new HashSet<Gruppo>();
            User = new HashSet<AspNetUsers>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Gruppo> Group { get; set; }
        public virtual ICollection<AspNetUsers> User { get; set; }
    }
}