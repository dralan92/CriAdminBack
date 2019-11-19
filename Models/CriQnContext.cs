using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriAdmin.Models
{
    public class CriQnContext :DbContext
    {
        public CriQnContext(DbContextOptions<CriQnContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CriQn>(ConfigureCriQn);
           
        }

        private void ConfigureCriQn(EntityTypeBuilder<CriQn> builder )
        {
            builder.HasOne(q => q.Country)
                .WithMany()
                .HasForeignKey(q=>q.CountryFk);

            builder.HasOne(q => q.Tier)
                .WithMany()
                .HasForeignKey(q => q.TierFk);


        }

        public DbSet<CriQn> CriQn { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Tier> Tier { get; set; }
    }   
}
