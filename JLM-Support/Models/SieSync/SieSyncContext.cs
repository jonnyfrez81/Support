using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JLM_Support.Models.SieSync
{
    public partial class SieSyncContext : DbContext
    {
        public SieSyncContext()
        {
        }

        public SieSyncContext(DbContextOptions<SieSyncContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<VouchersQueue> VouchersQueues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SieSync;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Created)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FortnoxId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FortnoxID");

                entity.Property(e => e.Message).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.DatabasId);

                entity.ToTable("User");

                entity.Property(e => e.DatabasId)
                    .HasMaxLength(50)
                    .HasColumnName("DatabasID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmailOrganisation).HasMaxLength(50);

                entity.Property(e => e.FortnoxAccessToken).HasMaxLength(50);

                entity.Property(e => e.Organisation).HasMaxLength(50);

                entity.Property(e => e.OrganisationNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FileID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FortnoxId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FortnoxID");

                entity.Property(e => e.Voucher1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Voucher");

                entity.Property(e => e.VoucherNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VouchersQueue>(entity =>
            {
                entity.ToTable("VouchersQueue");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FailMessage).IsUnicode(false);

                entity.Property(e => e.FileId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FileID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FortnoxId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FortnoxID");

                entity.Property(e => e.Voucher)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
