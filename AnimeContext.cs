﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebScraping
{
    public class AnimeContext : DbContext
    {
        public AnimeContext() { }

        public DbSet<Anime> animes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Database=db;Username=postegresql;Password=SYS");


    }
}