using System;
using DigicelApps.Models.DbConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigicelApps.Models
{
    public partial class DigicelAppContext : DbContext
    {
        public DigicelAppContext()
        {
        }

        public DigicelAppContext(DbContextOptions<DigicelAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            modelBuilder.ApplyConfiguration( new ApplicationConfiguration());          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
