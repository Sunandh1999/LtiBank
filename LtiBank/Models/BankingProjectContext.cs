using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LtiBank.Models
{
    public partial class BankingProjectContext : DbContext
    {
        public BankingProjectContext()
        {
        }

        public BankingProjectContext(DbContextOptions<BankingProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Benificiary> Benificiaries { get; set; }
        public virtual DbSet<Custinfo> Custinfos { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=WELCOME\\MSSQLSERVER2019;Initial Catalog=BankingProject;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Accountno);

                entity.ToTable("account");

                entity.Property(e => e.Accountno)
                    .ValueGeneratedNever()
                    .HasColumnName("accountno");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.HasOne(d => d.RidNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_register");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Adminid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adminid");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Benificiary>(entity =>
            {
                entity.HasKey(e => e.Benaccountno);

                entity.ToTable("benificiary");

                entity.Property(e => e.Benaccountno)
                    .ValueGeneratedNever()
                    .HasColumnName("benaccountno");

                entity.Property(e => e.Accountno).HasColumnName("accountno");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.HasOne(d => d.AccountnoNavigation)
                    .WithMany(p => p.Benificiaries)
                    .HasForeignKey(d => d.Accountno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_benificiary_account");
            });

            modelBuilder.Entity<Custinfo>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("custinfo");

                entity.HasIndex(e => e.Mobile, "UQ__custinfo__A32E2E1C6A4DF0BD")
                    .IsUnique();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Aadhar).HasColumnName("aadhar");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middlename");

                entity.Property(e => e.Mobile).HasColumnName("mobile");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("occupation");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("register");

                entity.HasIndex(e => e.Accountno, "UQ__register__F2076ECC90F09C1B")
                    .IsUnique();

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Accountno).HasColumnName("accountno");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Transactionpass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("transactionpass");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Transactionno)
                    .HasName("PK_transaction");

                entity.ToTable("transactions");

                entity.Property(e => e.Transactionno).HasColumnName("transactionno");

                entity.Property(e => e.Accountno).HasColumnName("accountno");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Benaccountno).HasColumnName("benaccountno");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.HasOne(d => d.AccountnoNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Accountno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_account");

                entity.HasOne(d => d.BenaccountnoNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Benaccountno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_benificiary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
