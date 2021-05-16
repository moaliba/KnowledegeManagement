using DomainModel;
using Microsoft.EntityFrameworkCore;
using ReadModels;
using System;

namespace DataSource
{
    public class ReadDbContext : DbContext, IReadDbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Team> Teams { get; set; }
    }
}
