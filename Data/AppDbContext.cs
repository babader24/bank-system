using System;
using System.Collections.Generic;
using Bank_Web_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Web_Project.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<LoginRegistration> LoginRegistrations { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportType> ReportTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = BankSystemAspDB ; Integrated Security = SSPI ; TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D160BFD99406EA");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("PK__Currency__14470B10E6F39812");
        });

        modelBuilder.Entity<LoginRegistration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__LoginReg__6EF58830C2F894E5");

            entity.HasOne(d => d.User).WithMany(p => p.LoginRegistrations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoginRegistration_User");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C037CDFBE0501");

            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.MessageDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ReceiverPerson).WithMany(p => p.Messages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_ReceiverPersonID");

            entity.HasOne(d => d.SenderUser).WithMany(p => p.Messages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_SenderUserID");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB85886370D8");

            entity.HasOne(d => d.Country).WithMany(p => p.People)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Country");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__D5BD48E573BADC4D");

            entity.Property(e => e.GeneratedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reports_User");
        });

        modelBuilder.Entity<ReportType>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__ReportTy__D5BD48E5669BE3A3");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A7ED9D485");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B4A36C0A4");

            entity.HasOne(d => d.Client).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Client");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_User");

            entity.HasOne(d => d.Currency).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Currency");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC226A0C91");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Person");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
