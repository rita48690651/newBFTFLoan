using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace newBFTFLoan.Models.EFModels
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Borrower> Borrowers { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Investment> Investments { get; set; }
        public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Repayment> Repayments { get; set; }
        public virtual DbSet<Resell> Resells { get; set; }
        public virtual DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrower>()
                .HasOptional(e => e.Certificate)
                .WithRequired(e => e.Borrower)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Borrower>()
                .HasMany(e => e.Loans)
                .WithRequired(e => e.Borrower)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Investment>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Investment>()
                .HasMany(e => e.Resells)
                .WithRequired(e => e.Investment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Investor>()
                .HasMany(e => e.Investments)
                .WithRequired(e => e.Investor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Investor>()
                .HasMany(e => e.Resells)
                .WithRequired(e => e.Investor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Loan>()
                .Property(e => e.Principal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Loan>()
                .HasOptional(e => e.Repayment)
                .WithRequired(e => e.Loan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Member>()
                .Property(e => e.IDNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Investors)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Repayment>()
                .Property(e => e.MonthlyRate)
                .HasPrecision(5, 5);

            modelBuilder.Entity<Repayment>()
                .Property(e => e.AmortizationRate)
                .HasPrecision(38, 35);

            modelBuilder.Entity<Repayment>()
                .Property(e => e.CurrentPayable)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Repayment>()
                .Property(e => e.CurrentPrincipalPayable)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Repayment>()
                .Property(e => e.CurrentInterestPayable)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Repayment>()
                .Property(e => e.RemainPrincipal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Resell>()
                .Property(e => e.Bid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Resell>()
                .Property(e => e.Ask)
                .HasPrecision(19, 4);

            modelBuilder.Entity<School>()
                .HasMany(e => e.Borrowers)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);
        }
    }
}
