﻿using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Entity.Configurations;
using eCaiet.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace eCaiet.DAL.Entity
{
    public class EDbContext : DbContext
    {
        #region DbSet tables
        public DbSet<User> Users { get; set; }
        #endregion


        public EDbContext(DbContextOptions<EDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}