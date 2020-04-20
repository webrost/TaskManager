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

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.131;Initial Catalog=T;User ID=sa;Password=saP@ssw0rd;Encrypt=False;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    .HasConstraintName("FK_Message");
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
                    .HasConstraintName("FK_Created");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_Task");
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
                    .HasConstraintName("FK_Boss");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Subordinate");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.LockedTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(1024);

                entity.Property(e => e.PhoneNumber).HasMaxLength(1024);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_User_CompanyId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("KK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
