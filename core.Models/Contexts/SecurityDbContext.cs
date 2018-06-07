﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Models.Entities;
using Core.Models.Maps;
using core.Models.Entities;
using Core.Models.Entities.Relations;

namespace Core.Models.Contexts
{
    public class SecurityDbContext : IdentityDbContext<Person>
    {
        //private static bool _created = false;
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options)
        {
            // Create the database and schema if it doesn't exist
            // This is a temporary workaround to create database until Entity Framework database migrations
            // are supported in ASP.NET Core
            //if (!_created)
            //{
            //    Database.Migrate();//.ApplyMigrations();
            //    _created = true;
            //}

        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserMap());
            builder.ApplyConfiguration(new FriendshipMap());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Friendship> Friends { get; set; }
    }
}
