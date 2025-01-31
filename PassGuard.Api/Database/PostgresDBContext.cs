﻿using Microsoft.EntityFrameworkCore;
using PassGuard.Core.Models;

namespace PassGuard.Core.Database;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Username).IsRequired();
            entity.Property(a => a.Password).IsRequired();
            entity.Property(a => a.Salt);
            entity.Property(a => a.CreatedAt);
        });
    }
}