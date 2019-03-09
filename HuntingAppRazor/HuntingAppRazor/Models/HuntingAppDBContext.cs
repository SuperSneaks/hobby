using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HuntingAppRazor.Models
{
    public partial class HuntingAppDBContext : DbContext
    {
        public HuntingAppDBContext()
        {
        }

        public HuntingAppDBContext(DbContextOptions<HuntingAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hunts> Hunts { get; set; }
        public virtual DbSet<Properties> Properties { get; set; }
        public virtual DbSet<Sightings> Sightings { get; set; }
        public virtual DbSet<Stands> Stands { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.PropertyAccess'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=HuntingAppDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Hunts>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.BucksSeen).HasColumnName("bucks_seen");

                entity.Property(e => e.DoesSeen).HasColumnName("does_seen");

                entity.Property(e => e.HuntEnd)
                    .HasColumnName("hunt_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.HuntStart)
                    .HasColumnName("hunt_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.SightDetails).HasColumnName("sight_details");

                entity.Property(e => e.StandUuid).HasColumnName("stand_uuid");

                entity.Property(e => e.UnknownSeen).HasColumnName("unknown_seen");

                entity.Property(e => e.UserUuid).HasColumnName("user_uuid");

                entity.HasOne(d => d.StandUu)
                    .WithMany(p => p.Hunts)
                    .HasForeignKey(d => d.StandUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hunts_Stands");

                entity.HasOne(d => d.Uu)
                    .WithOne(p => p.Hunts)
                    .HasForeignKey<Hunts>(d => d.Uuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hunts_User");
            });

            modelBuilder.Entity<Properties>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(10);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(10);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Sightings>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.BucksSeen).HasColumnName("bucks_seen");

                entity.Property(e => e.DoesSeen).HasColumnName("does_seen");

                entity.Property(e => e.HuntUuid).HasColumnName("hunt_uuid");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.SightDt)
                    .HasColumnName("sight_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UnknownSeen).HasColumnName("unknown_seen");

                entity.HasOne(d => d.HuntUu)
                    .WithMany(p => p.Sightings)
                    .HasForeignKey(d => d.HuntUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sightings_Hunts");
            });

            modelBuilder.Entity<Stands>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.BackImg)
                    .HasColumnName("back_img")
                    .HasColumnType("image");

                entity.Property(e => e.FrontImg)
                    .HasColumnName("front_img")
                    .HasColumnType("image");

                entity.Property(e => e.LeftImg)
                    .HasColumnName("left_img")
                    .HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyUuid).HasColumnName("property_uuid");

                entity.Property(e => e.RightImg)
                    .HasColumnName("right_img")
                    .HasColumnType("image");

                entity.HasOne(d => d.PropertyUu)
                    .WithMany(p => p.Stands)
                    .HasForeignKey(d => d.PropertyUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stands_Property");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("email_address")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(4000);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PropertyAccess>(entity => 
            {
                entity.Property(e => e.UserUuid).HasColumnName("user_uuid").ValueGeneratedNever();

                entity.Property(e => e.PropertyUuid).HasColumnName("property_uuid").ValueGeneratedNever();
            });
        }
    }
}
