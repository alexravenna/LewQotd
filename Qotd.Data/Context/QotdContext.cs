using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qotd.Domain;

namespace Qotd.Data.Context;

public class QotdContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Quote> Quotes => Set<Quote>();

    public QotdContext(DbContextOptions<QotdContext> options) : base(options)
    {
        //Database.EnsureCreated();
        //Database.Migrate();

        //Reverse Engienering
        //Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=LewQotd;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityframeworkCore.SqlServer -OutputDir Models
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SeedData();
    }
}