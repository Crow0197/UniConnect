﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repo.Ef
{
    [Table("Pg")]
    public partial class Pg
    {
        public Pg()
        {
            DropUsers = new HashSet<DropUser>();
            Moves = new HashSet<Move>();
            Statistics = new HashSet<Statistic>();
        }

        [Key]
        [Column("PgID")]
        public int PgId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Name { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }


        [InverseProperty(nameof(DropUser.Pg))]
        public virtual ICollection<DropUser> DropUsers { get; set; }
        [InverseProperty(nameof(Move.Pg))]
        public virtual ICollection<Move> Moves { get; set; }
        [InverseProperty(nameof(Statistic.Pg))]
        public virtual ICollection<Statistic> Statistics { get; set; }
    }
}