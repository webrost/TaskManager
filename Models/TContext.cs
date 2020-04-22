using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManager.Models
{
    public partial class TContext : DbContext
    {
        public TContext()
        {
        }

        public TContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Flat> Flat { get; set; }
        public virtual DbSet<FrontDoor> FrontDoor { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Papuas> Papuas { get; set; }
        public virtual DbSet<Residential> Residential { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=homesecurity.in.ua;Initial Catalog=homesecurity;User ID=homesecurity;Password=Demo!234567;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "homesecurity");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.ToTable("AspNetRoleClaims", "dbo");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.ToTable("AspNetRoles", "dbo");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "dbo");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("AspNetUserLogins", "dbo");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("AspNetUserRoles", "dbo");

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AspNetUserTokens", "dbo");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.ToTable("AspNetUsers", "dbo");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.Property(e => e.CarInfo).HasMaxLength(1024);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Text).HasMaxLength(2000);

                entity.Property(e => e.VisitorName).HasMaxLength(1024);

                entity.HasOne(d => d.Papuas)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.PapuasId)
                    .HasConstraintName("FK_ClaimPapuas");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("KEY_Company_Id")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(1024);

                entity.Property(e => e.SecretCode).HasMaxLength(1024);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("KEY_Company_Id")
                    .IsUnique();

                entity.Property(e => e.Data).HasColumnType("text");

                entity.Property(e => e.FileId).HasMaxLength(1024);

                entity.Property(e => e.FileName).HasMaxLength(1024);

                entity.Property(e => e.FileUniqueId).HasMaxLength(1024);

                entity.Property(e => e.MimeType).HasMaxLength(1024);

                entity.Property(e => e.Type).HasMaxLength(1024);

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("FK__Files__MessageId__123EB7A3");
            });

            modelBuilder.Entity<Flat>(entity =>
            {
                entity.Property(e => e.Number).HasMaxLength(1024);

                entity.Property(e => e.RoomCount).HasMaxLength(1024);

                entity.HasOne(d => d.FrontDoor)
                    .WithMany(p => p.Flat)
                    .HasForeignKey(d => d.FrontDoorId)
                    .HasConstraintName("FK_FlatFrontDoor");
            });

            modelBuilder.Entity<FrontDoor>(entity =>
            {
                entity.Property(e => e.Number).HasMaxLength(1024);

                entity.HasOne(d => d.House)
                    .WithMany(p => p.FrontDoor)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_FlatFronDoor");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.Number).HasMaxLength(1024);

                entity.HasOne(d => d.Residential)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.ResidentialId)
                    .HasConstraintName("FK_HouseResidential");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedTime).HasColumnType("datetime");

                entity.Property(e => e.FinishTime).HasColumnType("date");

                entity.Property(e => e.Text).HasColumnType("text");

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.HasOne(d => d.Created)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.CreatedId)
                    .HasConstraintName("FK__Message__Created__0E6E26BF");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__Message__TaskId__0F624AF8");
            });

            modelBuilder.Entity<Papuas>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(1024);

                entity.Property(e => e.Name).HasMaxLength(1024);

                entity.Property(e => e.Number).HasMaxLength(1024);

                entity.Property(e => e.Phone1).HasMaxLength(1024);

                entity.Property(e => e.Phone2).HasMaxLength(1024);

                entity.Property(e => e.RoomCount).HasMaxLength(1024);

                entity.Property(e => e.Surname).HasMaxLength(1024);

                entity.HasOne(d => d.Flat)
                    .WithMany(p => p.Papuas)
                    .HasForeignKey(d => d.FlatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PapuasFlat");
            });

            modelBuilder.Entity<Residential>(entity =>
            {
                entity.Property(e => e.District).HasMaxLength(1024);

                entity.Property(e => e.Name).HasMaxLength(1024);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.TechStatus).HasMaxLength(255);

                entity.Property(e => e.TechStatusChanged).HasColumnType("datetime");

                entity.Property(e => e.TelegramFrom).HasMaxLength(1024);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TaskCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Task__CreatedBy__0A9D95DB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Task__UserId__0B91BA14");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.LockedTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(1024);

                entity.Property(e => e.PhoneNumber).HasMaxLength(1024);

                entity.Property(e => e.TelegramChatId).HasMaxLength(1024);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__User__CompanyId__04E4BC85");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
