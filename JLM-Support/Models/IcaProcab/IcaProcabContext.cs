using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JLM_Support.Models.IcaProcab
{
    public partial class IcaProcabContext : DbContext
    {
        public IcaProcabContext()
        {
        }

        public IcaProcabContext(DbContextOptions<IcaProcabContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblSetting> TblSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=IcaProcab;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<TblSetting>(entity =>
            {
                entity.ToTable("tblSettings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accesstoken)
                    .HasMaxLength(50)
                    .HasColumnName("accesstoken");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AuthorizationCode)
                    .HasMaxLength(50)
                    .HasColumnName("authorization_code");

                entity.Property(e => e.Companyname)
                    .HasMaxLength(100)
                    .HasColumnName("companyname");

                entity.Property(e => e.DatabaseId)
                    .HasMaxLength(50)
                    .HasColumnName("database_id");

                entity.Property(e => e.Moms0)
                    .HasMaxLength(50)
                    .HasColumnName("moms0");

                entity.Property(e => e.Moms12)
                    .HasMaxLength(50)
                    .HasColumnName("moms12");

                entity.Property(e => e.Moms25)
                    .HasMaxLength(50)
                    .HasColumnName("moms25");

                entity.Property(e => e.Moms6)
                    .HasMaxLength(50)
                    .HasColumnName("moms6");

                entity.Property(e => e.MomsXml0)
                    .HasMaxLength(10)
                    .HasColumnName("momsXml0");

                entity.Property(e => e.MomsXml12)
                    .HasMaxLength(10)
                    .HasColumnName("momsXml12");

                entity.Property(e => e.MomsXml25)
                    .HasMaxLength(10)
                    .HasColumnName("momsXml25");

                entity.Property(e => e.MomsXml6)
                    .HasMaxLength(10)
                    .HasColumnName("momsXml6");

                entity.Property(e => e.OreAdjAcc)
                    .HasMaxLength(10)
                    .HasColumnName("oreAdjAcc");

                entity.Property(e => e.Voucherseries)
                    .HasMaxLength(50)
                    .HasColumnName("voucherseries");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
