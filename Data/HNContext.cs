﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace CriticalNotify.Data
{
    public class HNContext : DbContext
    {
        public static string ConnS;
        public HNContext()
        {
        }

        public HNContext(DbContextOptions<HNContext> options) : base(options)
        {
            var sqlServerOptionsExtension = options.FindExtension<SqlServerOptionsExtension>();
            if (sqlServerOptionsExtension != null)
            {
                ConnS = sqlServerOptionsExtension.ConnectionString;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnS);
        }

        public DbSet<病患檔> 病患檔 { get; set; }
        public DbSet<報告台結果檔> 報告台結果檔 { get; set; }
        public DbSet<危急值通報檔> hn危急值通報檔 { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

}