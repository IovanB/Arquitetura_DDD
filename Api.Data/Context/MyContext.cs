﻿using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id= Guid.NewGuid(),
                    Nome  = "Administrador",
                    Email = "admin@teste.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                });

        }
    }
}
