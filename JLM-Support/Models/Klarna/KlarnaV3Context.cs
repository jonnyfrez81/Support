using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class KlarnaV3Context : DbContext
    {
        public KlarnaV3Context()
        {
        }

        public KlarnaV3Context(DbContextOptions<KlarnaV3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountsConfiguration> AccountsConfigurations { get; set; }
        public virtual DbSet<AccountsType> AccountsTypes { get; set; }
        public virtual DbSet<DuplicatePayment> DuplicatePayments { get; set; }
        public virtual DbSet<DuplicatePaymentDetail> DuplicatePaymentDetails { get; set; }
        public virtual DbSet<FortnoxConfiguration> FortnoxConfigurations { get; set; }
        public virtual DbSet<KlarnaConfiguration> KlarnaConfigurations { get; set; }
        public virtual DbSet<KlarnaOrderLinesType> KlarnaOrderLinesTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentCorrection> PaymentCorrections { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VatsType> VatsTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=KlarnaV3;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<AccountsConfiguration>(entity =>
            {
                entity.ToTable("AccountsConfiguration");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AccountsType)
                    .WithMany(p => p.AccountsConfigurations)
                    .HasForeignKey(d => d.AccountsTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountsConfiguration_AccountsType");

                entity.HasOne(d => d.KlarnaOrderLinesType)
                    .WithMany(p => p.AccountsConfigurations)
                    .HasForeignKey(d => d.KlarnaOrderLinesTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountsConfiguration_KlarnaOrderLinesType");

                entity.HasOne(d => d.VatsType)
                    .WithMany(p => p.AccountsConfigurations)
                    .HasForeignKey(d => d.VatsTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountsConfiguration_VatsType");
            });

            modelBuilder.Entity<AccountsType>(entity =>
            {
                entity.ToTable("AccountsType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<DuplicatePayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DuplicatePayment");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .HasColumnName("email");

                entity.Property(e => e.OrderId).HasMaxLength(255);
            });

            modelBuilder.Entity<DuplicatePaymentDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CaptureId).HasMaxLength(255);

                entity.Property(e => e.Currency).HasMaxLength(8);

                entity.Property(e => e.Errors).HasMaxLength(1000);

                entity.Property(e => e.ExcludeFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FortNoxPaymentVoucherNumber).HasMaxLength(50);

                entity.Property(e => e.FortNoxPaymentVoucherSeries).HasMaxLength(10);

                entity.Property(e => e.FortnoxInvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.FortnoxPaymentNumber).HasMaxLength(50);

                entity.Property(e => e.IncludeFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MerchantReference1).HasMaxLength(255);

                entity.Property(e => e.MerchantReference2).HasMaxLength(255);

                entity.Property(e => e.OrderId).HasMaxLength(255);

                entity.Property(e => e.PaymentReference).HasMaxLength(255);

                entity.Property(e => e.PurchaseCountry).HasMaxLength(50);

                entity.Property(e => e.Reference).HasMaxLength(255);

                entity.Property(e => e.ShortOrderId).HasMaxLength(255);

                entity.Property(e => e.VatAmountOnFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VatAmountOnFeeCurrency).HasMaxLength(50);
            });

            modelBuilder.Entity<FortnoxConfiguration>(entity =>
            {
                entity.ToTable("FortnoxConfiguration");

                entity.HasIndex(e => e.UserId, "IX_FortnoxConfiguration_UserId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessToken).HasMaxLength(128);

                entity.Property(e => e.AccessTokenError).HasMaxLength(250);

                entity.Property(e => e.DatabaseNumber).HasMaxLength(50);

                entity.Property(e => e.LastSuccessfulCheckedOn).HasColumnType("datetime");

                entity.Property(e => e.OrganisationEmail).HasMaxLength(50);

                entity.Property(e => e.OrganisationName).HasMaxLength(50);

                entity.Property(e => e.OrganisationNumber).HasMaxLength(50);

                entity.Property(e => e.PaymentMethod).HasMaxLength(32);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.FortnoxConfiguration)
                    .HasForeignKey<FortnoxConfiguration>(d => d.UserId);
            });

            modelBuilder.Entity<KlarnaConfiguration>(entity =>
            {
                entity.ToTable("KlarnaConfiguration");

                entity.HasIndex(e => e.UserId, "IX_KlarnaConfiguration_UserId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApiKey).HasMaxLength(128);

                entity.Property(e => e.CurrenciesToProcess).HasMaxLength(250);

                entity.Property(e => e.FeeExcludesMoms).HasColumnName("FeeExcludesMOMS");

                entity.Property(e => e.FeeIncludesMoms).HasColumnName("FeeIncludesMOMS");

                entity.Property(e => e.MerchantId).HasMaxLength(128);

                entity.Property(e => e.Momspercent)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("MOMSPercent");

                entity.Property(e => e.PaymentReferenceType).HasMaxLength(128);

                entity.Property(e => e.SpecificPaymentsToProcess).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.KlarnaConfiguration)
                    .HasForeignKey<KlarnaConfiguration>(d => d.UserId);
            });

            modelBuilder.Entity<KlarnaOrderLinesType>(entity =>
            {
                entity.ToTable("KlarnaOrderLinesType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.HasIndex(e => e.UserId, "IX_Payment_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CaptureId).HasMaxLength(255);

                entity.Property(e => e.CapturedAt).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Currency).HasMaxLength(8);

                entity.Property(e => e.Errors).HasMaxLength(1000);

                entity.Property(e => e.ExcludeFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FortNoxPaymentVoucherNumber).HasMaxLength(50);

                entity.Property(e => e.FortNoxPaymentVoucherSeries).HasMaxLength(10);

                entity.Property(e => e.FortnoxInvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.FortnoxPaymentNumber).HasMaxLength(50);

                entity.Property(e => e.IncludeFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MerchantReference1).HasMaxLength(255);

                entity.Property(e => e.MerchantReference2).HasMaxLength(255);

                entity.Property(e => e.OrderId).HasMaxLength(255);

                entity.Property(e => e.PaymentReference).HasMaxLength(255);

                entity.Property(e => e.PurchaseCountry).HasMaxLength(50);

                entity.Property(e => e.Reference).HasMaxLength(255);

                entity.Property(e => e.ShortOrderId).HasMaxLength(255);

                entity.Property(e => e.VatAmountOnFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VatAmountOnFeeCurrency).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PaymentCorrection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Payment_Corrections");

                entity.Property(e => e.Currency).HasMaxLength(8);

                entity.Property(e => e.ExcludeFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IncludeFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Reference).HasMaxLength(128);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContactFirstName).HasMaxLength(50);

                entity.Property(e => e.ContactLastName).HasMaxLength(50);

                entity.Property(e => e.DownloadNewPayments).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.OrganisationName).HasMaxLength(50);

                entity.Property(e => e.OrganisationNumber).HasMaxLength(50);

                entity.Property(e => e.Reference).HasMaxLength(128);

                entity.Property(e => e.TestMode).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<VatsType>(entity =>
            {
                entity.ToTable("VatsType");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
