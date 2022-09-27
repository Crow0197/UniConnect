﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repo.Ef
{
    public partial class GdrcontextContext :  IdentityDbContext<ApplicationUser>
    {


        public GdrcontextContext()
        {
        }

        public GdrcontextContext(DbContextOptions<GdrcontextContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        public virtual DbSet<Boss> Bosses { get; set; }
        public virtual DbSet<DropUser> DropUsers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Move> Moves { get; set; }
        public virtual DbSet<Pg> Pgs { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Typology> Typologies { get; set; }

        public virtual DbSet<StatisticBase> StatisticBases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


    }
}