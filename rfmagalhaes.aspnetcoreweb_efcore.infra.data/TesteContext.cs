using Microsoft.EntityFrameworkCore;
using rfmagalhaes.aspnetcoreweb_efcore.domain;
using System;

namespace rfmagalhaes.aspnetcoreweb_efcore.infra.data
{
    public class TesteContext
        : DbContext
    {

        public TesteContext(DbContextOptions<TesteContext> options) : base(options) { }

        public DbSet<CodigoPostal> CodigoPostal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<CodigoPostal>();
            builder.ToTable("CodigoPostal");
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Id).ValueGeneratedOnAdd();

        }
    }
}
