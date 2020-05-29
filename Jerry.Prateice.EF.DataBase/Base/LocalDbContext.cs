using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Jerry.Prateice.EF.DataBase.Entities;
using Microsoft.Extensions.Logging;

namespace Jerry.Prateice.EF.DataBase
{
    public class LocalDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<T_Student> T_Student { get; set; }
        public DbSet<T_Class> T_Class { get; set; }
        public DbSet<T_ClassSubject> T_ClassSubject { get; set; }
        public DbSet<T_Teacher> T_Teacher { get; set; }
        public DbSet<T_Subject> T_Subject { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                @"Server=127.0.0.1;Port=3306;Database=prateice;Uid=root;Pwd=123456;",
                x => x.MigrationsAssembly("Jerry.Prateice.EF.Migrations")).UseLoggerFactory(MyLoggerFactory);
        }
    }
}