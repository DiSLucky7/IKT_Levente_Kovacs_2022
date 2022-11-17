using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Sakk.Models
{
    public partial class sakkContext : DbContext
    {
        public sakkContext()
        {
        }

        public sakkContext(DbContextOptions<sakkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Figurak> Figuraks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=sakk;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Figurak>(entity =>
            {
                entity.ToTable("figurak");

                entity.HasIndex(e => e.Megnevezes, "Megnevezes")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(1)");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("longblob");

                entity.Property(e => e.LepesSzabaly)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Megnevezes)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TablaDb).HasColumnType("int(1)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
